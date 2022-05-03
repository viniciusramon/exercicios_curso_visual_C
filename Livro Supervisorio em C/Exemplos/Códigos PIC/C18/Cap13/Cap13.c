#include <p18F4520.h> 	//Inclui arquivo header do PIC18F4520
#include <usart.h>		//Biblioteca de funções para comunicação serial	
#include <adc.h>		//Biblioteca de funções para conversão A/D
#include <delays.h>		//Biblioteca de funções de atraso
#include <stdio.h>		//Biblioteca de funções geral
#include <timers.h>		//Biblioteca de funções para os Timers
#include "lcd_4b.h"		//Inclui arquivo de funções do LCD

// Frequencia do oscilador = 8MHz
// Ciclo de máquina  = 1/(Fosc/4) = 0,5us
#pragma config OSC = HS        	//Configura o oscilador a cristal 
#pragma config WDT = OFF  		//Desabilita o Watchdog Timer (WDT).
#pragma config PWRT = ON   	//Habilita o Power-up Timer (PWRT).
#pragma config BOREN = ON		//Habilita Brown-out reset 
#pragma config BORV = 1        	//Tensão do BOR é 4,33V.
#pragma config PBADEN = OFF 	//RB0,1,2,3 e 4 configurado como I/O digital.
#pragma config LVP = OFF       	//Desabilita o Low Voltage Program.

long int ad0, ad1;				//variáveis para armazenamento da conversão A/D
long int ADC0, ADC1;	
char rec[10];	     				//variável de recepção de dados pela serial
char buff[20];					//buffer para escrita no LCD
char l1=0, l2=0, l3=0, l4=0;		//variáveis de controle para os leds
/******************************************************************************
variáveis de controle:
vent = ventoinha;
aq = aquecedor;
cont = controle de índice para recepção serial;
tempo = informação de tempo em 2 segundos
chg = controle para visualização dos dados no LCD.
*******************************************************************************/
char vent = 0, aq = 0, tempo=0, tmp=0, chg=0;

void trata_serial();  			//Protótipo da função trata_serial
void trata_TIMER0(); 		//Protótipo da função trata_TIMER0()

#pragma code int_pr = 0x08	//vetor de interrupção de alta prioridade
void int_pr(void)			//função de indentificação da interrupção ocorrida
{
     if (PIR1bits.RCIF)			//Se interrupção por recepção na serial
	_asm GOTO trata_serial _endasm //Desvia para a função trata_serial()
     if (INTCONbits.TMR0IF)	//Se interrupção pelo overflow no Timer0
     _asm GOTO trata_TIMER0 _endasm	//Desvia para a função trata_TIMER0()
}
#pragma code

#pragma interrupt trata_serial	//Diretiva de identificação p/ int. pela recepção serial
void trata_serial()				//Função trata_serial
{
getsUSART(rec,4);				//Recebe uma string de 5 caracteres

//Liga Leds 1, 2 , 3, 4 e Aquecimento 
if (rec[0] == 'L' && rec[1] == 'G') 	//Verifica se os primeiros caracteres são 'LG'
   {
    if (rec[2] == '1')					//Verifica se o terceiro caractere é '1'
       {
        PORTDbits.RD0 = 1;             	//Acende Led conectado ao pino RD0
        l1 = 1;                         		//controle de leds l1 = 1	
       } 
 
    if (rec[2] == '2')					//Verifica se o terceiro caractere é '2'
       {
        PORTDbits.RD1 = 1;     		//Acende Led conectado ao pino RD1        
        l2 = 1;                         		//controle de leds l2 = 1	
       } 

    if (rec[2] == '3')					//Verifica se o terceiro caractere é '3'
       {
        PORTDbits.RD2 = 1;             	//Acende Led conectado ao pino RD2
        l3 = 1;                         		//controle de leds l3 = 1	
       } 

    if (rec[2] == '4')					//Verifica se o terceiro caractere é '4'
       {
        PORTDbits.RD3 = 1;            	//Acende Led conectado ao pino RD3
        l4 = 1;                         		//controle de leds l4 = 1	
       } 

    if (rec[2] == 'A')					//Verifica se o terceiro caractere é 'A'
       {
        PORTCbits.RC1 = 1;             	//Liga o circuito de aquecimento em RC1
        aq = 1;                         		//controle de aquecimento aq = 1
       } 
   }

if (rec[0] == 'D' && rec[1] == 'G')  	//Verifica se os primeiros caracteres são 'DG'
   {
    if (rec[2] == '1')					//Verifica se o terceiro caractere é '1'
       {
        PORTDbits.RD0 = 0;            	//Acende Led conectado ao pino RD0
        l1 = 0;                         		//controle de leds l1 = 0	
       } 

    if (rec[2] == '2')					//Verifica se o terceiro caractere é '1'
       {
        PORTDbits.RD1 = 0;            	//Acende Led conectado ao pino RD1
        l2 = 0;                         		//controle de leds l2 = 0
       } 

    if (rec[2] == '3')					//Verifica se o terceiro caractere é '1'
       {
        PORTDbits.RD2 = 0;        		//Acende Led conectado ao pino RD2     
        l3 = 0;                         		//controle de leds l3 = 0
       } 

    if (rec[2] == '4')					//Verifica se o terceiro caractere é '1'
       {
        PORTDbits.RD3 = 0;      		//Acende Led conectado ao pino RD3       
        l4 = 0;                         		//controle de leds l4 = 0
       } 
   }

PIR1bits.RCIF = 0;					//Limpa Flag da interrupção serial

}

#pragma interrupt trata_TIMER0		//Diretiva de identificação p/ int. do Timer 0
void trata_TIMER0() 				//Função trata_TIMER0
{
tempo++; 			//Incrementa a variável tempo a cada 25ms
if (tempo>=80) 		//Se tempo >= 40 <=> 2 segundos
	{
	tempo = 0;		//Retorna a variável tempo em 0
      tmp = 1; 		//variável de controle de tempo 2 seg vai para 1
     }
INTCONbits.TMR0IF = 0; //Limpa o flag da interrupção do timer 0

WriteTimer0(61); 		//Retoma o valor inicial do Timer 0
}


void main()				//Função principal
{
TRISBbits.RB0 = 1;		//Direciona o pino RB0 com entrada

TRISCbits.RC1 = 0;		//Direciona o pino RC1 como saída
TRISCbits.RC2 = 0;		//Direciona o pino RC2 como saída	
PORTCbits.RC1 = aq;		//Desliga o circuito de aquecimento
PORTCbits.RC2 = vent;	//Desliga o circuito da ventoinha

TRISD = 0x00;			//Direciona todos os pinos da PORTA D como saída
PORTD = 0x00;			//Coloca toda a porta D em zero

OpenUSART(USART_TX_INT_OFF		//desabilita interrupção de transmissão
			& USART_RX_INT_ON	//Habilita interrupção de recepção
			& USART_ASYNCH_MODE	//modo assíncrono
			& USART_EIGHT_BIT		//transmissão e recepção em 8 bits
			& USART_BRGH_HIGH,	//Baud Rate em alta velocidade
			51);					//SPBRG p/ 9600 bps


//Configura o conversor AD
OpenADC(ADC_FOSC_8    	//Clock de conversão AD igual  a
      						//Fad = FOSC/8 = 8MHz/8 = 1MHz
      						//Assim TAD = 1 / Fad = 1us
  & ADC_RIGHT_JUST       	//Resultado da conversão ocupará os bits menos
      						//significativos dos registradores ADRESH e 
      						//ADRESL
  & ADC_4_TAD,    			//Determina o tempo de conversão de 10 bits
      						//Neste caso, 4*TAD = 4 * 1us = 4us.
  ADC_CH0     				//Seleciona o canal que será feita a conversão
  & ADC_INT_OFF    			//Desabilita a interrupção do ADC
  & ADC_VREFPLUS_VDD    	//Determina VDD como tensão de referência
      						//positiva VREF+
  & ADC_VREFMINUS_VSS,   	//Determina VSS como tensão de referência 
      						//negativa VREF-
  ADC_4ANA);                  	//Configura os pinos RA0, RA1, RA2 e RA3 como canais analógicos

OpenTimer0( TIMER_INT_ON 		//Habilita a interrupção do Timer 0
                  &T0_8BIT 			//Modo de operação 8 bits
                  &T0_SOURCE_INT 	//Clock pelo ciclo de máquina
                  &T0_PS_1_256); 	//prescaler 1:256

WriteTimer0(61); 			//Valor Inicial para o timer 0

INTCONbits.GIE = 1;			//Habilita Interrupção global
INTCONbits.PEIE = 1;     		//Habilita Interrupção de periféricos

lcd_inicio();					//inicia o LCD

//Escreve as mensagens iniciais no LCD
sprintf(buff,(const far rom char *)"\f  SUPERVISORIO  ");
lcd_escreve(buff);
Delay1KTCYx(4);
sprintf(buff,(const far rom char *)"\nVISUAL C#/ACEPIC"); 
lcd_escreve(buff);

while(1)					//Loop principal
        {
             if (PORTBbits.RB0 == 0)		//Se chave conectada ao pino RB0 for pressionada
                {
                 PORTCbits.RC1 = 1;		//Liga circuito de aquecimento	
                 aq = 1;					//Faz controle de aquecimento aq = 1
                } 
                 
             SetChanADC(ADC_CH0);	//Seleciona o canal 0 para conversão 
             Delay10TCYx(20);			//Tempo de ajuste do canal
             ConvertADC();				//Inicia a conversão analógica	
		  while(BusyADC());			//Aguarda o término da conversão
		  ad0 = ReadADC();			//Salva o resultado da conversão em ad0

             

             SetChanADC(ADC_CH3);	//Seleciona o canal 0 para conversão
             Delay10TCYx(20);			//Tempo de ajuste do canal
             ConvertADC();				//Inicia a conversão analógica	
		  while(BusyADC());			//Aguarda o término da conversão
		  ad1 = ReadADC(); 			//Salva o resultado da conversão em ad0

              
             printf("AN0:%04lu:",ad0);   //Envia dados de conversão A/D para exibir tensão
             
             printf("TMP:%04lu:",ad1);   //Envia dados de conversão A/D para exibir temperatura
             
		/******************************************************************************
		Envia dados referentes ao circuito de aquecimento, ventoinha e leds
		0: desligado
		1: ligado
		******************************************************************************/
             printf("%d%d00%d%d%d%d",aq, vent, l1, l2, l3, l4); 	  
           

            if (ad1>=81)            	//Se ad1 >= 81 (aprox. 40 graus)
                {
                 PORTCbits.RC1 = 0;  //Desliga circuito de aquecimento
                 PORTCbits.RC2 = 1; 	//Liga circuito da ventoinha
                 aq = 0;                  //Faz controle de aquecimento aq = 0
                 vent = 1;            	//Faz controle da ventoinha vent = 1
                }
   
            if (ad1<=60)            	//Se ad1 <= 60 (aprox. 29 graus)
               {
                PORTCbits.RC2 = 0;  //Desliga circuito da ventoinha
                vent = 0;            	//Faz controle da ventoinha vent = 0;
               }

             ADC0 = (ad0 * 500) /1023; //Cálculo da conversão AD para o LCD (Tensão)
             ADC1 = (ad1 * 500) /1023; //Cálculo da conversão AD para o LCD (temperatura)

             if (tmp)				//Se tmp = 1 (a cada 2 segundos)
                {
                 chg++;				//incrementa a variável chg
                 if (chg==1)			//se chg = 1
                    {
				//Exibe tensão e temperatura no LCD
                      sprintf(buff,"\fAN0 : %lu,%02lu V    ", ADC0/100, ADC0%100);
                      lcd_escreve(buff);
                      Delay1KTCYx(4);
                      sprintf(buff,"\nTEMP: %lu%cC      ",ADC1,0xDF); 
                      lcd_escreve(buff);               
                    } 
                  if (chg==2)			//se chg = 2
                    {
				/*Exibe as informações dos circuitos de aquecimento e
           			ventoinha*/
                      sprintf(buff,"\fAQ: %d    VENT: %d",aq,vent);
                      lcd_escreve(buff);                                 
                    } 
                  if (chg==3)			//se chg = 3
                    {
				//Exibe as informações do estado dos LEDS
                      sprintf(buff,"\fL1: %d   L2: %d   ",l1,l2);
                      lcd_escreve(buff);
                      Delay1KTCYx(4);
                      sprintf(buff,"\nL3: %d   L4: %d   ",l3,l4); 
                      lcd_escreve(buff);
                      chg = 0;     	//Faz chg = 0          
                    }  
                 tmp = 0;		//Retorna tmp em 0
                }                

             Delay10KTCYx(60);		//Delay de 300ms
             
      }

}