#line 1 "C:/Users/Renan/Desktop/Exercicios Curso Visual C/Programas em Pic/Capitulo 9/Capitulo 9.c"


void main() {

 char uart;
 char temp_res1 = 0;
 char txt[7];
 char valorAD=0;

 UART1_Init(9600);
 Delay_ms(100);

 CMCON = 0x07;
 ADCON0 = 0x01;
 ADCON1 = 0x0E;
 TRISA = 0xFF;
 TRISC = 0x3F;
 TRISB = 0;

while(1)
{
 temp_res1 = ADC_Read(0);


 Delay_ms(200);


 valorAD++;
 IntToStr(valorAd, txt);
 UART1_Write_Text(txt);

}
}
