#include <p18F4520.h>
#include <usart.h>
#include <adc.h>
#include <delays.h>
#include <stdio.h>

// Frequencia do oscilador = 8MHz
// Ciclo de m�quina  = 1/(Fosc/4) = 0,5us
#pragma config OSC = HS        	//Configura o oscilador a cristal 
#pragma config WDT = OFF  		//Desabilita o Watchdog Timer (WDT).
#pragma config PWRT = ON   		//Habilita o Power-up Timer (PWRT).
#pragma config BOREN = ON		//Habilita Brown-out reset 
#pragma config BORV = 1        	//Tens�o do BOR � 4,33V.
#pragma config PBADEN = OFF 	//RB0,1,2,3 e 4 configurado como I/O digital.
#pragma config LVP = OFF       	//Desabilita o Low Voltage Program.

char rec[10];	     //Vari�vel que receber� os caracteres vindos da serial
char adc = 0;

void trata_serial();  //Prot�tipo da fun��o trata_serial

#pragma code int_pr = 0x08	//vetor de interrup��o de alta prioridade
void int_pr(void)
{
     if (PIR1bits.RCIF)
	_asm GOTO trata_serial _endasm //Desvia para a fun��o trata_serial()
}
#pragma code

void trata_serial()	//Fun��o trata_serial
{
getsUSART(rec,9);	//Recebe uma string de 8 caracteres

/*Se o caractere armazenado no �ndice 0 do vetor 'rec' for 'I' e o caractere
armazenado no �ndice '1' do vetor 'rec' for 'N'...*/
if (rec[0] == 'I' && rec[1] == 'N')  
   {
   PORTDbits.RD0 = 1;             //Acende o LED1
   adc = 1;                         //Vari�vel de controle AD = 1
   }
   
/*Se o caractere armazenado no �ndice 0 do vetor 'rec' for 'F' e o caractere
armazenado no �ndice '1' do vetor 'rec' for 'N'...*/
if (rec[0] == 'F' && rec[1] == 'N')
   {
   PORTDbits.RD0 = 0;              //Apaga o LED1
   adc = 0;                         //Vari�vel de controle AD = 0
   }
PIR1bits.RCIF = 0;		//Limpa Flag da interrup��o
INTCONbits.GIE = 1;		//Habilita Interrup��o global
}


void main()
{
TRISD = 0x00;		//Direciona todos os pinos da PORTA D como sa�da
PORTD = 0x00;		//Coloca toda a porta D em zero

OpenUSART(USART_TX_INT_OFF		//desabilita interrup��o de transmiss�o
			& USART_RX_INT_ON	//Habilita interrup��o de recep��o
			& USART_ASYNCH_MODE	//modo ass�ncrono
			& USART_EIGHT_BIT		//transmiss�o e recep��o em 8 bits
			& USART_BRGH_HIGH,	//Baud Rate em alta velocidade
			51);					//SPBRG p/ 9600 bps


//Configura o conversor AD
OpenADC(ADC_FOSC_8    	//Clock de convers�o AD igual  a
      						//Fad = FOSC/8 = 8MHz/8 = 1MHz
      						//Assim TAD = 1 / Fad = 1us
  & ADC_RIGHT_JUST       	//Resultado da convers�o ocupar� os bits menos
      						//significativos dos registradores ADRESH e 
      						//ADRESL
  & ADC_4_TAD,    			//Determina o tempo de convers�o de 10 bits
      						//Neste caso, 4*TAD = 4 * 1us = 4us.
  ADC_CH0     				//Seleciona o canal que ser� feita a convers�o
  & ADC_INT_OFF    			//Desabilita a interrup��o do ADC
  & ADC_VREFPLUS_VDD    	//Determina VDD como tens�o de refer�ncia
      						//positiva VREF+
  & ADC_VREFMINUS_VSS,   	//Determina VSS como tens�o de refer�ncia 
      						//negativa VREF-
  ADC_1ANA);                  	//Configura o pino RA0 como canal anal�gico

INTCONbits.GIE = 1;			//Habilita Interrup��o global
INTCONbits.PEIE = 1;     		//Habilita Interrup��o de perif�ricos

SetChanADC(ADC_CH0);		//Seleciona o canal 0 para convers�o

while(1)
        {
         if (adc)				//Se adc = 1
            {
             ConvertADC();		//Inicia a converes�o anal�gica	
		  while(BusyADC());	//Aguarda o t�rmino da convers�o
		  
		  //Envia pela serial a string contendo o valor da convers�o AD	
             printf((const far rom char *)"AN0=%04u",ReadADC()); 
		  
             Delay1KTCYx(200);		//Delay de 100ms	
            }
        
        }

}