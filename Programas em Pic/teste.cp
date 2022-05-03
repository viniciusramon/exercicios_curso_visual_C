#line 1 "C:/Users/Renan/Desktop/Exercicios Curso Visual C/Programas em Pic/teste.c"






void main() {

 CMCON = 0X07;
 ADCON0 = 0X00;
 ADCON1 = 0X06;

 TRISB = 0X80;
 PORTB = 0X00;

while (1) {
  RB0_bit  = 0X01;


}

}
