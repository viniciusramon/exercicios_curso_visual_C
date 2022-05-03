/*******************************************************************************
*                     Kit de desenvolvimento ACEPIC PRO V2.1                   *
*                      ACEPIC Tecnologia e Treinamento LTDA                    *
*                               www.acepic.com.br                              * 
*                                                                              *
*Objetivo: Teste Serial                                                        *
*Obs.:     Ligar chave 2 do DIP DP2                                            *
********************************************************************************/
#include<18F4520.h> 
#use delay (clock=8000000)        
#fuses HS, NOWDT, PUT, BROWNOUT, NOLVP 
#use RS232 (Baud=9600, xmit = PIN_C6, rcv = PIN_C7)

#use FAST_IO(D)

char rec[4];   //Variável que receberá os caracteres vindos da serial
int i=0;       //variável de índice para a variável 'rec'

void trata_serial()
{
//Se o dado recebido pela serial for 'LL1'
if ((rec[0]=='L') && (rec[1] == 'L') && (rec[2] == '1'))
   OUTPUT_HIGH(PIN_D0);    //Acende o LED

//Se o dado recebido pela serial for 'DL1'
if ((rec[0]=='D') && (rec[1] == 'L') && (rec[2] == '1'))
   OUTPUT_LOW(PIN_D0);     //Apaga o LED
}


void main()
{
SET_TRIS_D(0X00);       //Direciona todos os pinos da PORTA D como saída
OUTPUT_D(0X00);         //Coloca toda a PORTA D em 0

while(true)
        {
        rec[i] = getc();         //Aguardo o caractere e o coloca na variável rec[i]   
        printf("%c",rec[i]);     //Retorna o caractere pela serial
        
        if (rec[i] == 0x0D)      //Se o caractere for igual ao 'CR'
          {
           trata_serial();       //Desvia para a função trata_serial()
           i=0;                  //Zera a variável de índice (i)
          }  
        else
           i++;                  //Se o caractere for diferente de 'CR'
                                 //Incrementa a variável de índice
        }
}
