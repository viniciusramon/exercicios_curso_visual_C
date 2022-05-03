#include <p18F4520.h>
#include <usart.h>
#include <adc.h>
#include <delays.h>
#include <stdio.h>

// Frequencia do oscilador = 8MHz
// Ciclo de máquina  = 1/(Fosc/4) = 0,5us
#pragma config OSC = HS        	//Configura o oscilador a cristal 
#pragma config WDT = OFF  		//Desabilita o Watchdog Timer (WDT).
#pragma config PWRT = ON   		//Habilita o Power-up Timer (PWRT).
#pragma config BOREN = ON		//Habilita Brown-out reset 
#pragma config BORV = 1        	//Tensão do BOR é 4,33V.
#pragma config PBADEN = OFF 	//RB0,1,2,3 e 4 configurado como I/O digital.
#pragma config LVP = OFF       	//Desabilita o Low Voltage Program.

char rec[10];	     //Variável que receberá os caracteres vindos da serial
char adc = 0;

void trata_serial();  //Protótipo da função trata_serial

#pragma code int_pr = 0x08	//vetor de interrupção de alta prioridade
void int_pr(void)
{
     if (PIR1bits.RCIF)
	_asm GOTO trata_serial _endasm //Desvia para a função trata_serial()
}
#pragma code

void trata_serial()	//Função trata_serial
{
getsUSART(rec,9);	//Recebe uma string de 8 caracteres

/*Se o caractere armazenado no índice 0 do vetor 'rec' for 'I' e o caractere
armazenado no índice '1' do vetor 'rec' for 'N'...*/
if (rec[0] == 'I' && rec[1] == 'N')  
   {
   PORTDbits.RD0 = 1;             //Acende o LED1
   adc = 1;                         //Variável de controle AD = 1
   }
   
/*Se o caractere armazenado no índice 0 do vetor 'rec' for 'F' e o caractere
armazenado no índice '1' do vetor 'rec' for 'N'...*/
if (rec[0] == 'F' && rec[1] == 'N')
   {
   PORTDbits.RD0 = 0;              //Apaga o LED1
   adc = 0;                         //Variável de controle AD = 0
   }
PIR1bits.RCIF = 0;		//Limpa Flag da interrupção
INTCONbits.GIE = 1;		//Habilita Interrupção global
}


void main()
{
TRISD = 0x00;		//Direciona todos os pinos da PORTA D como saída
PORTD = 0x00;		//Coloca toda a porta D em zero

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
  ADC_1ANA);                  	//Configura o pino RA0 como canal analógico

INTCONbits.GIE = 1;			//Habilita Interrupção global
INTCONbits.PEIE = 1;     		//Habilita Interrupção de periféricos

SetChanADC(ADC_CH0);		//Seleciona o canal 0 para conversão

while(1)
        {
         if (adc)				//Se adc = 1
            {
             ConvertADC();		//Inicia a converesão analógica	
		  while(BusyADC());	//Aguarda o término da conversão
		  
		  //Envia pela serial a string contendo o valor da conversão AD	
             printf((const far rom char *)"AN0=%04u",ReadADC()); 
		  
             Delay1KTCYx(200);		//Delay de 100ms	
            }
        
        }

}