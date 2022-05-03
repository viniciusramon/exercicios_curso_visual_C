
_main:
;Capitulo 8.c,7 :: 		void main() {
;Capitulo 8.c,9 :: 		CMCON = 0X07;
	MOVLW      7
	MOVWF      CMCON+0
;Capitulo 8.c,10 :: 		ADCON0 = 0X00;
	CLRF       ADCON0+0
;Capitulo 8.c,11 :: 		ADCON1 = 0X06;
	MOVLW      6
	MOVWF      ADCON1+0
;Capitulo 8.c,13 :: 		TRISB = 0X80;
	MOVLW      128
	MOVWF      TRISB+0
;Capitulo 8.c,14 :: 		PORTB = 0X00;
	CLRF       PORTB+0
;Capitulo 8.c,16 :: 		UART1_Init(9600);              // Initialize UART module at 9600 bps
	MOVLW      51
	MOVWF      SPBRG+0
	BSF        TXSTA+0, 2
	CALL       _UART1_Init+0
;Capitulo 8.c,17 :: 		Delay_ms(100);                 // Wait for UART module to stabilize
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
;Capitulo 8.c,19 :: 		UART1_Write_Text("START");       //   and send data via UART
	MOVLW      ?lstr1_Capitulo 8+0
	MOVWF      FARG_UART1_Write_Text_uart_text+0
	CALL       _UART1_Write_Text+0
;Capitulo 8.c,20 :: 		Delay_ms(10);
	MOVLW      26
	MOVWF      R12+0
	MOVLW      248
	MOVWF      R13+0
L_main1:
	DECFSZ     R13+0, 1
	GOTO       L_main1
	DECFSZ     R12+0, 1
	GOTO       L_main1
	NOP
;Capitulo 8.c,21 :: 		UART1_Write(13);       //   and send data via UART
	MOVLW      13
	MOVWF      FARG_UART1_Write_data_+0
	CALL       _UART1_Write+0
;Capitulo 8.c,22 :: 		UART1_Write(10);       //   and send data via UART
	MOVLW      10
	MOVWF      FARG_UART1_Write_data_+0
	CALL       _UART1_Write+0
;Capitulo 8.c,26 :: 		while (1) {                    // Endless loop
L_main2:
;Capitulo 8.c,28 :: 		if (UART1_Data_Ready()) {     // If data is received,
	CALL       _UART1_Data_Ready+0
	MOVF       R0+0, 0
	BTFSC      STATUS+0, 2
	GOTO       L_main4
;Capitulo 8.c,29 :: 		uart_rd = UART1_Read();     //   read the received data,
	CALL       _UART1_Read+0
	MOVF       R0+0, 0
	MOVWF      _uart_rd+0
;Capitulo 8.c,30 :: 		UART1_Write(uart_rd);
	MOVF       R0+0, 0
	MOVWF      FARG_UART1_Write_data_+0
	CALL       _UART1_Write+0
;Capitulo 8.c,31 :: 		}
L_main4:
;Capitulo 8.c,32 :: 		switch(uart_rd)
	GOTO       L_main5
;Capitulo 8.c,34 :: 		case 'y' : LED1 = 0X01; break;
L_main7:
	BSF        RB0_bit+0, 0
	GOTO       L_main6
;Capitulo 8.c,35 :: 		case 'k' : LED1 = 0X00; break;
L_main8:
	BCF        RB0_bit+0, 0
	GOTO       L_main6
;Capitulo 8.c,36 :: 		}
L_main5:
	MOVF       _uart_rd+0, 0
	XORLW      121
	BTFSC      STATUS+0, 2
	GOTO       L_main7
	MOVF       _uart_rd+0, 0
	XORLW      107
	BTFSC      STATUS+0, 2
	GOTO       L_main8
L_main6:
;Capitulo 8.c,37 :: 		} //END WHILE
	GOTO       L_main2
;Capitulo 8.c,38 :: 		} //END MAIN
	GOTO       $+0
; end of _main
