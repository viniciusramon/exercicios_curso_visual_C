
_main:
	CLRF       main_valorAD_L0+0
;Capitulo 9.c,3 :: 		void main() {
;Capitulo 9.c,10 :: 		UART1_Init(9600);              // Initialize UART module at 9600 bps
	MOVLW      51
	MOVWF      SPBRG+0
	BSF        TXSTA+0, 2
	CALL       _UART1_Init+0
;Capitulo 9.c,11 :: 		Delay_ms(100);                 // Wait for UART module to stabilize
	MOVLW      2
	MOVWF      R11+0
	MOVLW      4
	MOVWF      R12+0
	MOVLW      186
	MOVWF      R13+0
L_main0:
	DECFSZ     R13+0, 1
	GOTO       L_main0
	DECFSZ     R12+0, 1
	GOTO       L_main0
	DECFSZ     R11+0, 1
	GOTO       L_main0
	NOP
;Capitulo 9.c,13 :: 		CMCON = 0x07;                 // Desabilita os comparadores
	MOVLW      7
	MOVWF      CMCON+0
;Capitulo 9.c,14 :: 		ADCON0 = 0x01;                // Desabilita os conversores AD
	MOVLW      1
	MOVWF      ADCON0+0
;Capitulo 9.c,15 :: 		ADCON1 = 0x0E;                // Tornar todo ADC digital
	MOVLW      14
	MOVWF      ADCON1+0
;Capitulo 9.c,16 :: 		TRISA  = 0xFF;              // PORTA is input  ANSELH = 0;                 // Configure other AN pins as digital I/O
	MOVLW      255
	MOVWF      TRISA+0
;Capitulo 9.c,17 :: 		TRISC  = 0x3F;              // Pins RC7, RC6 are outputs
	MOVLW      63
	MOVWF      TRISC+0
;Capitulo 9.c,18 :: 		TRISB  = 0;                 // PORTB is output
	CLRF       TRISB+0
;Capitulo 9.c,20 :: 		while(1)
L_main1:
;Capitulo 9.c,22 :: 		temp_res1 = ADC_Read(0);   // Get 10-bit results of AD conversion
	CLRF       FARG_ADC_Read_channel+0
	CALL       _ADC_Read+0
;Capitulo 9.c,25 :: 		Delay_ms(200);
	MOVLW      3
	MOVWF      R11+0
	MOVLW      8
	MOVWF      R12+0
	MOVLW      119
	MOVWF      R13+0
L_main3:
	DECFSZ     R13+0, 1
	GOTO       L_main3
	DECFSZ     R12+0, 1
	GOTO       L_main3
	DECFSZ     R11+0, 1
	GOTO       L_main3
;Capitulo 9.c,28 :: 		valorAD++;
	INCF       main_valorAD_L0+0, 1
;Capitulo 9.c,29 :: 		IntToStr(valorAd, txt);
	MOVF       main_valorAD_L0+0, 0
	MOVWF      FARG_IntToStr_input+0
	CLRF       FARG_IntToStr_input+1
	MOVLW      main_txt_L0+0
	MOVWF      FARG_IntToStr_output+0
	CALL       _IntToStr+0
;Capitulo 9.c,30 :: 		UART1_Write_Text(txt);       //   and send data via UART
	MOVLW      main_txt_L0+0
	MOVWF      FARG_UART1_Write_Text_uart_text+0
	CALL       _UART1_Write_Text+0
;Capitulo 9.c,32 :: 		}  //END WHILE
	GOTO       L_main1
;Capitulo 9.c,33 :: 		} //END MAIN
	GOTO       $+0
; end of _main
