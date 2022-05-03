#include<18F4520.h>           //Inclui arquivo header do PIC 18F4520
#device ADC = 10              //Define 10 bits para o resultado da convers�o AD
#use delay (clock=8000000)    /*Defini��o da frequ�ncia do cristal para c�lculo 
                              ..dos delays*/
#fuses HS, NOWDT, PUT,BROWNOUT, NOLVP  //Configura��o dos bits de controle

//Defini��es para a comunica��o serial
#use RS232 (Baud=9600, xmit = PIN_C6, rcv = PIN_C7)

#include "LCD4B.c"          //Inclui arquivo de fun��es do LCD
 
int32 ad0, ad1;             //vari�veis para armazenamento da convers�o
int32 ADC0, ADC1;
int l1=0, l2=0, l3=0, l4=0; //vari�veis de controle para os leds

/******************************************************************************
vari�veis de controle:
vent = ventoinha;
aq = aquecedor;
cont = controle de �ndice para recep��o serial;
tempo = informa��o de tempo em 2 segundos
chg = controle para visualiza��o dos dados no LCD.
*******************************************************************************/
int vent = 0, aq=0, cont=0, tempo=0, chg = 0;

int1 tmp = 0;     /*vari�vel de controle de tempo em 2 segundos para
                    alterar��o das informa��es no LCD*/
int rec[5];       //Vari�vel de recep��o de dados pela serial

#INT_RDA          //Diretiva de identfica��o p/ int. pela recep��o serial
void rec_serial() //Fun��a de tratamento da recep��o de dados
{
rec[cont] = getc();     /*L� o dado vindo pela serial e o armazena em
                          rec na posi��o (�ndice) informado por cont*/ 

if (rec[cont] == 0x0D)  //Verifica se o dado recebido � igual a CR (0x0D)
   {
   //Liga Leds 1, 2 , 3, 4 e Aquecimento   
   if (rec[0]=='L' && rec[1]=='G')  //Verifica se os primeiros caracteres s�o 'LG'
      {
      if (rec[2] == '1')            //Verifica se o terceiro caractere � '1'
         {
         l1 = 1;                    //controle de leds l1 = 1
         output_bit(PIN_D0,l1);     //Acende Led conectado ao pino RD0
         }
      if (rec[2] == '2')            //Verifica se o terceiro caractere � '2'
         {
         l2 = 1;                    //controle de leds l2 = 1
         output_bit(PIN_D1,l2);     //Acende Led conectado ao pino RD1
         }
      if (rec[2] == '3')            //Verifica se o terceiro caractere � '3'
         {
         l3 = 1;                    //controle de leds l3 = 1
         output_bit(PIN_D2,l3);     //Acende Led conectado ao pino RD2 
         }
      if (rec[2] == '4')            //Verifica se o terceiro caractere � '4'
         {
         l4 = 1;                    //controle de leds l4 = 1
         output_bit(PIN_D3,l4);     //Acende Led conectado ao pino RD3
         }  
      if (rec[2] == 'A')            //Verifica se o terceiro caractere � 'A'
         {
         aq = 1;                    //controle de aquecimento aq = 1
         output_bit(PIN_C1,aq);     //Liga o circuito de aquecimento em RC1
         }     
      }
      
   //Desliga Leds 1, 2, 3 e 4   
   if (rec[0]=='D' && rec[1]=='G')  //Verifica se os primeiros caracteres s�o 'DG'
      {
      if (rec[2] == '1')            //Verifica se o terceiro caractere � '1'
         {
         l1 = 0;                    //controle de leds l1 = 0
         output_bit(PIN_D0,l1);     //Apaga Led conectado ao pino RD0
         }
      if (rec[2] == '2')            //Verifica se o terceiro caractere � '2'
         {
         l2 = 0;                    //controle de leds l2 = 0
         output_bit(PIN_D1,l2);     //Apaga Led conectado ao pino RD1
         }
      if (rec[2] == '3')            //Verifica se o terceiro caractere � '3'
         {
         l3 = 0;                    //controle de leds l3 = 0
         output_bit(PIN_D2,l3);     //Apaga Led conectado ao pino RD2
         }
      if (rec[2] == '4')            //Verifica se o terceiro caractere � '4'
         {
         l4 = 0;                   //controle de leds l4 = 0 
         output_bit(PIN_D3,l4);     //Apaga Led conectado ao pino RD3
         }       
      } 
      
   /*Ap�s recebido todos os dados da serial, faz a limpeza de toda a
   vari�vel rec e retorna o controle de �ndices cont em 0*/
   for(cont = 0; cont < 5; cont++) rec[cont] = '\0'; 
   cont = 0;  
   }
else
   /*Se ainda n�o foram recebidos todos os dados de controle, incrementa
   a vari�vel de �ndice cont*/
    cont++;   
}

#INT_TIMER0       //Diretiva de indetifica��o da int. do Timer 0
void Trata_t0()   //Fun��o para tratamento do Timer 0
{
tempo++;          //Incrementa a vari�vel tempo a cada 25ms
if (tempo >= 80)  //Se tempo >= 80 <=> 2 segundos?
    {
    tmp = 1;      //Vari�vel de controle de tempo 2 seg vai para 1
    tempo = 0;    //Retorna a vari�vel tempo em 0
    }
SET_TIMER0(61);   //Retorna o valor inicial ao Timer 0
}

//Formato do protocolo = AN0:0000:TMP:0000:00000000
void escreve_serial()      //Fun��o de envio do protocolo para a serial
{
printf("AN0:%04lu",ad0);   //Envia dados de convers�o A/D para exibir tens�o
printf(":");               //Controle do protocolo
printf("TMP:%04lu",ad1);   //Envia dados de convers�o A/D para exibir temperatura
printf(":");               //Controle do protocolo
/******************************************************************************
Envia dados referentes ao circuito de aquecimento, ventoinha e leds
0: desligado
1: ligado
******************************************************************************/
printf("%d%d00%d%d%d%d",aq, vent, l1, l2, l3, l4); 
//printf(":");               //Controle do protocolo
}

//void limpa_leds()    //Fun��o 
//{
//output_low(PIN_D4);
//output_low(PIN_D5);
//output_low(PIN_D6);
//output_low(PIN_D7);
//}
 
void main()                   //Fun��o principal 
{
//Configura as entradas anal�gicas AN0 a AN3
SETUP_ADC_PORTS(AN0_TO_AN3);    
//Utiliza o clock interno para tempo de aquisi��o 
SETUP_ADC(ADC_CLOCK_Internal);

output_low(PIN_C1);   //Desliga circuito de aquecimento
output_low(PIN_C2);   //Desliga circuito da Ventoinha

//Habilita interrup��o global
Enable_Interrupts(GLOBAL);
//Habilita interrup��o por recep��o de dados na serial
Enable_Interrupts(INT_RDA);
//Habilita interrup��o pelo overflow do Timer 0
ENABLE_INTERRUPTS(INT_TIMER0);
/*Configura Timer 0 para incremento pelo ciclo de m�quina
Prescaler de 1:256 e modo de opera��o em 8 bits*/
SETUP_TIMER_0(RTCC_INTERNAL | RTCC_DIV_256 | RTCC_8_BIT);
//Inicia o Timer 0 com o valor 61 - Interrup��o a cada 25ms
SET_TIMER0(61);

lcd_ini();  //Inicia o LCD

//Escreve as mensagens iniciais no LCD
printf(lcd_escreve,"\f  SUPERVISORIO");
printf(lcd_escreve,"\nVISUAL C#/ACEPIC");

output_D(0x00);            //Faz toda a porta D = 0

l1 = input_state(PIN_D0);  //armazena em l1 o estado do pino RD0
l2 = input_state(PIN_D1);  //armazena em l2 o estado do pino RD1
l3 = input_state(PIN_D2);  //armazena em l3 o estado do pino RD2
l4 = input_state(PIN_D3);  //armazena em l4 o estado do pino RD3

/*Faz a limpeza de toda a vari�vel rec e faz o controle
  de �ndices cont em 0*/
for(cont = 0; cont < 5; cont++) rec[cont] = '\0'; 
cont = 0;

while(true)                            //Loop principal
   { 
   if (!input(PIN_B0))     //Se chave conectada ao pino RB0 for pressionada 
      {
      output_high(PIN_C1); //Liga circuito de aquecimento
      aq = 1;              //Faz controle de aquecimento aq = 1
      }
  
   SET_ADC_CHANNEL(0);     //Configura o canal de leitura 0
   delay_us(100);          //Tempo de ajuste do canal (necess�rio) 
   ad0 = READ_ADC();       //Faz a convers�o AD e a salva na vari�vel ad0
   
   SET_ADC_CHANNEL(3);     //Configura o canal de leitura 3
   delay_us(100);          //Tempo de ajuste do canal (necess�rio) 
   ad1 = READ_ADC();       //Faz a convers�o AD e a salva na vari�vel ad0
   
   ADC0 = (ad0 * 500) /1023; //C�lculo da convers�o AD para o LCD (Tens�o)
   ADC1 = (ad1 * 500) /1023; //C�lculo da convers�o AD para o LCD (temperatura)     
   
   if (ad1>=81)            //Se ad1 >= 81 (aprox. 40 graus)
   {
      output_low(PIN_C1);  //Desliga circuito de aquecimento
      output_High(PIN_C2); //Liga circuito da ventoinha
      aq = 0;              //Faz controle de aquecimento aq = 0
      vent = 1;            //Faz controle da ventoinha vent = 1
   }
   
   if (ad1<=60)            //Se ad1 <= 60 (aprox. 27 graus)
   {
      output_low(PIN_C2);  //Desliga circuito da ventoinha
      vent = 0;            //Faz controle da ventoinha vent = 0;
   }
      
   escreve_serial();       //Envia dados pela serial
   
   if (tmp)                //Se tmp = 1 (a cada 2 segundos)
       {
       chg++;              //incrementa a vari�vel chg
       if (chg==1)         //se chg = 1
           {
           //Exibe tens�o e temperatura no LCD
           printf(lcd_escreve,"\fAN0 : %lu,%02lu V", ADC0/100, ADC0%100);
           printf(lcd_escreve,"\nTEMP: %lu%cC",ADC1,0xDF);
           }
       if (chg==2)         //Se tmp = 2
           {
           /*Exibe as informa��es dos circuitos de aquecimento e
           ventoinha*/
           printf(lcd_escreve,"\fAQ: %d    VENT: %d",aq,vent);
           }   
      if (chg==3)          //Se tmp = 3
           {
           //Exibe as informa��es do estado dos LEDS
           printf(lcd_escreve,"\fL1: %d   L2: %d",l1,l2);
           printf(lcd_escreve,"\nL3: %d   L4: %d",l3,l4);
           chg = 0;        //Faz chg = 0
           }
       //limpa_leds();    
       tmp = 0;            //Retorna tmp em 0
       }     
           
   delay_ms(300);          //Atraso de 100ms
   }
}    
