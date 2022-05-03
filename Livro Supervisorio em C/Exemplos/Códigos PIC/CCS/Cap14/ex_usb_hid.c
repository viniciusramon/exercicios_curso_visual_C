#include <18F4550.h>
#device ADC=10;
#fuses HSPLL,NOWDT,NOPROTECT,NOLVP,NODEBUG,USBDIV,PLL2,CPUDIV1,VREGEN
#use delay(clock=48000000)

#use rs232(baud=9600, xmit=PIN_C6, rcv=PIN_C7)

//Define ao firmware que será utilizado o código de manipulação HID.
#DEFINE USB_HID_DEVICE  TRUE

/*Define a habilitação do endpoint de transmissão e aloca espaço na memória para os bytes de trasmissão*/
#define USB_EP1_TX_ENABLE  USB_ENABLE_INTERRUPT      

#define USB_EP1_TX_SIZE    5        //aloca 5 bytes para transmissão


/*Define a habilitação do endpoint de recepção e aloca espaço na memória para os bytes de recepção*/
#define USB_EP1_RX_ENABLE  USB_ENABLE_INTERRUPT      

#define USB_EP1_RX_SIZE    8        //aloca 8 bytes para recepção

/////////////////////////////////////////////////////////////////////////////
//
// Inclusão da biblioteca CCS USB
//
/////////////////////////////////////////////////////////////////////////////

#include <pic18_usb.h>         //Microchip 18Fxx5x para o usb.c

#include <usb_desc_hid_ACEPIC.h>  //Configuração da USB e Descritor do Dispositivo
#include <usb.c>              /*Manipula as configurações USB e obtem o 
                          relatório do descritor*/

#include "LCD4B.c"

/////////////////////////////////////////////////////////////////////////////
//
// Configura os pinos de entrada e saída
//
/////////////////////////////////////////////////////////////////////////////
#define L1 PIN_D0
#define L2 PIN_D1
#define L3 PIN_D2
#define L4 PIN_D3
#define RB0 PIN_B0
#define RB1 PIN_B1
#define RB2 PIN_B2
#define RA4 PIN_A4
#define VENT PIN_C2
#define AQC PIN_C1
#define LED_ON output_high
#define LED_OFF output_low

int status = 0b00000000;
#bit s_L1 = status.0      //Bit de estado para o Led L1
#bit s_L2 = status.1      //Bit de estado para o Led L2
#bit s_L3 = status.2      //Bit de estado para o Led L3
#bit s_L4 = status.3      //Bit de estado para o Led L4
#bit s_AQC = status.4      //Bit de estado para o ccto. de aquecimento
#bit s_VENT = status.5      //Bit de estado para o ccto. de ventilação

int8 in_data[8];         //Buffer para os dados recebidos pela USB

/////////////////////////////////////////////////////////////////////////////
// Variáveis para a conversão analógica digital 
/////////////////////////////////////////////////////////////////////////////
int32 valor_adc01;
int32 valor_adc03;

/////////////////////////////////////////////////////////////////////////////
// usb_debug_task()
// Quando chamado periodicamente, exibe informações de enumeração e conexão.
/////////////////////////////////////////////////////////////////////////////
void usb_debug_task(void) {
   static int8 last_connected;
   static int8 last_enumerated;
   int8 new_connected;
   int8 new_enumerated;

   new_connected=usb_attached();
   new_enumerated=usb_enumerated();

   last_connected=new_connected;
   last_enumerated=new_enumerated;
}

void main() {
   int8 out_data[20];      //Buffer para os dados enviados
   int8 send_timer=0;      //Variável de controle de tempo
   int8 send_adc_Timer=0;      //Variável de controle de tempo para ADC

   lcd_ini();         //Inicialização do LCD
   
   Output_D(0x00);      //Faz toda a porta D = 0  
   
   
   //Escreve mensagens de inicialização no LCD
   printf(lcd_escreve,"\fACEPIC PRO V 2.1");
   printf(lcd_escreve,"\n    USB - HID");
         
   usb_init();         //Faz inicialização da USB
   
   setup_adc_ports(AN0_TO_AN3);    //Configura Portas 0 e 3 para ADC

   setup_adc(ADC_CLOCK_INTERNAL);   //Configura clock interno para ADC
   
   while (TRUE) {
      usb_task();         //Verifica tarefas USB
      usb_debug_task();      //Verifica tarefas USB - Debug
      if (usb_enumerated())    //Se dispositivo conectado corretamente à USB
         {
         if (!send_timer)    //Verifica se variável = 0
            {
            send_timer=250;            //Retorna o valor 250 à variável send_timer
            send_adc_timer++;          //Incrementa a variável send_adc_timer
            if (send_adc_timer>=4)     //Envia os valores ADC em aprox. 1 segundo
               {
                set_adc_channel(0);      //Seleciona o canal analógico 0
                delay_us(100);             //Atraso de 100us
                valor_adc01 = read_adc();  /*Lê o canal 0 e armazena o valor em 
                                 valor_adc01*/
            
                set_adc_channel(3);        //Seleciona o canal analógico 3
                delay_us(100);             //Atraso de 100us
                valor_adc03 = read_adc();  /*Lê o canal 3 e armazena o valor em 
                               valor_adc03*/

                send_adc_timer=0;          //zera a variável send_adc_timer
                
                if (valor_adc03 >= 81)    //Se adc03 Maior que aprox. 40 graus
                  {
                     output_low(AQC);   //Desliga ccto. aquecimento
                     output_high(VENT);   //Liga ccto. ventilação
                     s_AQC = 0;      //status Aquecimento   
                     s_VENT = 1;      //status ventilação
                  }
                if (valor_adc03 <= 60)   //Se adc03 menor que aprox. 30 graus
                   {
                     output_low(VENT);   //Desliga ccto. ventilação
                     s_VENT = 0;      //status ventilação
                   }

            //Escreve mensagens no LCD       
            printf(lcd_escreve,"\fAN0 = %04ld mV", (valor_adc01*5000)/1023);
            printf(lcd_escreve,"\nTMP = %02ld %cC", (valor_adc03*500)/1023,0XDF); 
            } 
            
   //Valores a serem armazenados nas posições 0 a 10 do vetor out_data
   out_data[0]= valor_adc01>>8;   //Armazena a parte alta da variável valor_adc01
   out_data[1]=(int) valor_adc01;   //Armazena a parte baixa da variável valor_adc01
   out_data[2]= valor_adc03>>8;   //Armazena a parte alta da variável valor_adc03   
   out_data[3]=(int) valor_adc03; //Armazena a parte baixa da variável valor_adc03
   out_data[4]= status;      //Armazena o status dos leds e Aqc e vent.
            
//////////////////////////////////////////////////////////////////////////////////
//Envia o vetor out_data à USB 
/////////////////////////////////////////////////////////////////////////////////  
   if (usb_put_packet(1, out_data, 5, USB_DTS_TOGGLE));           
   }

   if (usb_kbhit(1))       //verifica se existe algum dado vindo da USB
      {
      //Recebe 8 bytes e armazena na variável in_data   
      usb_get_packet(1, in_data, 8);
            
      //Verifica se os índices 0 e 1 da variável in_data formam a string 'LD'
      if (in_data[0] == 'L' && in_data[1] == 'D')
         {
          switch(in_data[2])   //Verifica o índice 2 da variável in_data 
                {
                case '1': Output_toggle(L1);   //Caso seja 1
                          s_L1 = ~s_L1;       //altera estado do Led L1
                          break;
                case '2': Output_toggle(L2);   //Caso seja 2   
                          s_L2 = ~s_L2;      //altera estado do Led L2
                          break;
                case '3': Output_toggle(L3);   //Caso seja 3
                          s_L3 = ~s_L3;       //altera estado do Led L3
                          break;
                case '4': Output_toggle(L4);   //Caso seja 4
                          s_L4 = ~s_L4;      //altera estado do Led L4
                          break;
                case 'A': Output_High(AQC);   //Caso seja A
                          s_AQC = 1;      //altera estado do ccto. aquec
                          break;
                }
         }
      }
      if (!input(RB0))          //Se chave B0 for pressionada
          {
          output_high(AQC);      //Liga ccto. de aquecimento
          s_AQC = 1;         //Altera estado do ccto. de aquec.
          }
      send_timer--;      //Decrementa a variável sent_timer
      delay_ms(1);      //Atraso de 1ms
   }
 }
}

