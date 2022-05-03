

void main() {

  char uart;
  char temp_res1 = 0;
  char txt[7];
  char valorAD=0;
  
  UART1_Init(9600);              // Initialize UART module at 9600 bps
  Delay_ms(100);                 // Wait for UART module to stabilize

  CMCON = 0x07;                 // Desabilita os comparadores
  ADCON0 = 0x01;                // Desabilita os conversores AD
  ADCON1 = 0x0E;                // Tornar todo ADC digital
  TRISA  = 0xFF;              // PORTA is input  ANSELH = 0;                 // Configure other AN pins as digital I/O
  TRISC  = 0x3F;              // Pins RC7, RC6 are outputs
  TRISB  = 0;                 // PORTB is output

while(1)
{
    temp_res1 = ADC_Read(0);   // Get 10-bit results of AD conversion


    Delay_ms(200);


    valorAD++;
    IntToStr(valorAd, txt);
    UART1_Write_Text(txt);       //   and send data via UART
    
}  //END WHILE
} //END MAIN
