@ECHO OFF
CLS
REM ===========================================================================
REM   Build Z80 Forth
REM
REM   Assumes:
REM       You are in the source directory
REM       You have a path defined to the TASM.EXE on the C drive
REM       You have set up the SET TASMTABS=C:/TASM or such like
REM
REM ===========================================================================
REM SET TASMTABS=C:\APPS\!TASM\DOS\TASM
SET TASMTABS=P:\Z80\bin\tasm
SET TASMEXE=%TASMTABS%\TASM.EXE

REM For ROM
%TASMEXE% -80 -b -c -dROM FORTH.ASM FORTHROM.BIN FORTHROM.LST

REM For RAM
%TASMEXE% -80 -g0 FORTH.ASM FORTHRAM.HEX FORTHRAM.LST

PAUSE


