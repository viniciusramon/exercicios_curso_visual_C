#line 1 "C:/Users/Renan/Desktop/Exercicios Curso Visual C/Programas em Pic/Capitulo 8/Capitulo 8.c"




char uart_rd;

void main() {

 CMCON = 0X07;
 ADCON0 = 0X00;
 ADCON1 = 0X06;

 TRISB = 0X80;
 PORTB = 0X00;

 UART1_Init(9600);
 Delay_ms(100);

 UART1_Write_Text("START");
 Delay_ms(10);
 UART1_Write(13);
 UART1_Write(10);



while (1) {

 if (UART1_Data_Ready()) {
 uart_rd = UART1_Read();
 UART1_Write(uart_rd);
 }
switch(uart_rd)
 {
case 'y' :  RB0_bit  = 0X01; break;
case 'k' :  RB0_bit  = 0X00; break;
 }
}
}
