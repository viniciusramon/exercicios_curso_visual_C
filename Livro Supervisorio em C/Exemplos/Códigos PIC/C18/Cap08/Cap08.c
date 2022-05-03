#include <p18F4520.h>
#include <usart.h>
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

char rec[4];	     //Vari�vel que receber� os caracteres vindos da serial
char i;				//vari�vel de �ndice para a vari�vel 'rec'

void trata_serial();  //Prot�tipo da fun��o trata_serial

void trata_serial()
{
//Se o dado recebido pela serial for 'LL1'
if ((rec[0]=='L') && (rec[1] == 'L') && (rec[2] == '1'))
    PORTDbits.RD0 = 1;   //Acende o LED

//Se o dado recebido pela serial for 'DL1'
if ((rec[0]=='D') && (rec[1] == 'L') && (rec[2] == '1'))
   PORTDbits.RD0 = 0;     //Apaga o LED
}


void main()
{
TRISD = 0x00;		//Direciona todos os pinos da PORTA D como sa�da
PORTD = 0x00;		//Coloca toda a porta D em zero

OpenUSART(USART_TX_INT_OFF		//desabilita interrup��o de transmiss�o
			& USART_RX_INT_OFF	//desabilita interrup��o de recep��o
			& USART_ASYNCH_MODE	//modo ass�ncrono
			& USART_EIGHT_BIT		//transmiss�o e recep��o em 8 bits
			& USART_BRGH_HIGH,	//Baud Rate em alta velocidade
			51);					//SPBRG p/ 9600 bps




while(1)
        {
        //Aguarda a chegada de um caractere no buffer de recep��o serial
        while(!DataRdyUSART());		
        
        //Armazena o caractere no vetor rec com �ndice i 
        rec[i] = getcUSART();

        putcUSART(rec[i]); 		//Retorna o caractere pela serial

        if (rec[i] == 0x0d)			//Se o caractere for igual a 'CR'
           	{
		trata_serial();			//Desvia para a fun��o trata_serial()
            i = 0;					//Zera a vari�vel de �ndice (i)
		}
        else						//Se o caractere for diferente de 'CR'
           i++;						//Incrementa a vari�vel de �ndice.
        }

}

			