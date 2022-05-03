
_main:
;teste.c,7 :: 		void main() {
;teste.c,9 :: 		CMCON = 0X07;
	MOVLW      7
	MOVWF      CMCON+0
;teste.c,10 :: 		ADCON0 = 0X00;
	CLRF       ADCON0+0
;teste.c,11 :: 		ADCON1 = 0X06;
	MOVLW      6
	MOVWF      ADCON1+0
;teste.c,13 :: 		TRISB = 0X80;
	MOVLW      128
	MOVWF      TRISB+0
;teste.c,14 :: 		PORTB = 0X00;
	CLRF       PORTB+0
;teste.c,16 :: 		while (1) {                    // Endless loop
L_main0:
;teste.c,17 :: 		LED1 = 0X01;
	BSF        RB0_bit+0, 0
;teste.c,20 :: 		} //END WHILE
	GOTO       L_main0
;teste.c,22 :: 		}
	GOTO       $+0
; end of _main
