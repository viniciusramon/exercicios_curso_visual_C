#include<18F4520.h>        //Aqui � incluso o header (*.h)  para o microcontrolador utilizado.

#device ADC = 10           //Define 10 bits para o resultado da convers�o AD

#use delay (clock=8000000) //Aqui definimos a frequ�ncia do cristal para c�lculo dos delays
#fuses HS, NOWDT, PUT, BROWNOUT, NOLVP //Configura��o dos fus�veis
#use RS232 (Baud=9600, xmit = PIN_C6, rcv = PIN_C7)

long int ad;      //Vari�vel de armazenamento da convers�o AD
char rec[10];     //Vetor para recep��o dos dados vindos pela serial
int1 adc = 0;     //Vari�vel de controle de retorno da convers�o AD
                  //pela serial

#INT_RDA             //Identifica��o da interrup��o por recep��o serial 
void trata_serial()  //Fun��o de tratamento da interrup��o
{
gets(rec);           //Recebe os dados vindos do aplicativo
/*Se o caractere armazenado no �ndice 0 do vetor 'rec' for 'I' e o caractere
armazenado no �ndice '1' do vetor 'rec' for 'N'...*/
if (rec[0] == 'I' && rec[1] == 'N')  
   {
   OUTPUT_HIGH(PIN_D0);             //Acende o LED1
   adc = 1;                         //Vari�vel de controle AD = 1
   }
   
/*Se o caractere armazenado no �ndice 0 do vetor 'rec' for 'F' e o caractere
armazenado no �ndice '1' do vetor 'rec' for 'N'...*/
if (rec[0] == 'F' && rec[1] == 'N')
   {
   OUTPUT_LOW(PIN_D0);              //Apaga o LED1
   adc = 0;                         //Vari�vel de controle AD = 0
   }
}

void main()         //Fun��o principal 
{         
SETUP_ADC_PORTS(AN0);   //Configurada a entrada anal�gica, somente a entrada RA0
SETUP_ADC(ADC_CLOCK_INTERNAL); //Configurado o conversor AD interno   
SET_ADC_CHANNEL(0);            //Configurado o canal de leitura 0   

ENABLE_INTERRUPTS(INT_RDA);   //Habilita a interrup��o pela recep��o serial
ENABLE_INTERRUPTS(GLOBAL);    //Habilita a interrup��o global
  
delay_us(500);

while(true)         //Loop principal
     {
     if (adc)
        { 
         ad = READ_ADC();                     //Faz a convers�o AD e a salva na vari�vel ad 
         printf("AN0=%04lu",ad);//Mostra a mensagem 'ADC =' + o valor da convers�o 
         delay_ms(100);                      //Atraso de 1 segundo
        }
     }

}
