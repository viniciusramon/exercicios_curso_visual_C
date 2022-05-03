#define LED1 RB0_bit
#define LED2 RB1_bit
#define LED3 RB2_bit

char uart_rd;

void main() {

     CMCON = 0X07;
     ADCON0 = 0X00;
     ADCON1 = 0X06;
     
     TRISB = 0X80;
     PORTB = 0X00;

  UART1_Init(9600);              // Initialize UART module at 9600 bps
  Delay_ms(100);                 // Wait for UART module to stabilize

  UART1_Write_Text("START");       //   and send data via UART
  Delay_ms(10);
  UART1_Write(13);       //   and send data via UART
  UART1_Write(10);       //   and send data via UART



while (1) {                    // Endless loop

   if (UART1_Data_Ready()) {     // If data is received,
     uart_rd = UART1_Read();     //   read the received data,
     UART1_Write(uart_rd);
     }
switch(uart_rd)
 {
case 'y' : LED1 = 0X01; break;
case 'k' : LED1 = 0X00; break;
 }
} //END WHILE
} //END MAIN
