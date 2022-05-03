#define LED1 RB0_bit
#define LED2 RB1_bit
#define LED3 RB2_bit



void main() {

     CMCON = 0X07;
     ADCON0 = 0X00;
     ADCON1 = 0X06;

     TRISB = 0X80;
     PORTB = 0X00;

while (1) {                    // Endless loop
    LED1 = 0X01;


} //END WHILE

}
