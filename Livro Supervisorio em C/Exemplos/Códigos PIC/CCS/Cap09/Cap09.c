#include<18F4520.h>        //Aqui é incluso o header (*.h)  para o microcontrolador utilizado.

#device ADC = 10           //Define 10 bits para o resultado da conversão AD

#use delay (clock=8000000) //Aqui definimos a frequência do cristal para cálculo dos delays
#fuses HS, NOWDT, PUT, BROWNOUT, NOLVP //Configuração dos fusíveis
#use RS232 (Baud=9600, xmit = PIN_C6, rcv = PIN_C7)

long int ad;      //Variável de armazenamento da conversão AD
char rec[10];     //Vetor para recepção dos dados vindos pela serial
int1 adc = 0;     //Variável de controle de retorno da conversão AD
                  //pela serial

#INT_RDA             //Identificação da interrupção por recepção serial 
void trata_serial()  //Função de tratamento da interrupção
{
gets(rec);           //Recebe os dados vindos do aplicativo
/*Se o caractere armazenado no índice 0 do vetor 'rec' for 'I' e o caractere
armazenado no índice '1' do vetor 'rec' for 'N'...*/
if (rec[0] == 'I' && rec[1] == 'N')  
   {
   OUTPUT_HIGH(PIN_D0);             //Acende o LED1
   adc = 1;                         //Variável de controle AD = 1
   }
   
/*Se o caractere armazenado no índice 0 do vetor 'rec' for 'F' e o caractere
armazenado no índice '1' do vetor 'rec' for 'N'...*/
if (rec[0] == 'F' && rec[1] == 'N')
   {
   OUTPUT_LOW(PIN_D0);              //Apaga o LED1
   adc = 0;                         //Variável de controle AD = 0
   }
}

void main()         //Função principal 
{         
SETUP_ADC_PORTS(AN0);   //Configurada a entrada analógica, somente a entrada RA0
SETUP_ADC(ADC_CLOCK_INTERNAL); //Configurado o conversor AD interno   
SET_ADC_CHANNEL(0);            //Configurado o canal de leitura 0   

ENABLE_INTERRUPTS(INT_RDA);   //Habilita a interrupção pela recepção serial
ENABLE_INTERRUPTS(GLOBAL);    //Habilita a interrupção global
  
delay_us(500);

while(true)         //Loop principal
     {
     if (adc)
        { 
         ad = READ_ADC();                     //Faz a conversão AD e a salva na variável ad 
         printf("AN0=%04lu",ad);//Mostra a mensagem 'ADC =' + o valor da conversão 
         delay_ms(100);                      //Atraso de 1 segundo
        }
     }

}
