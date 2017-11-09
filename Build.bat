@ECHO OFF
CLS
REM ===========================================================================
REM   Build Z80 Forth
REM ===========================================================================
SET TASMTABS=P:\Z80\TASM32\
SET TASMEXE=%TASMTABS%TASM
SET TASMOPTS=-80 -b -c
SET SRCDIR=P:\Z80\Forth

REM For ROM
%TASMEXE% -80 -b -c -dMON %SRCDIR%\FORTHROM.Z80 %SRCDIR%\FORTHROM.bin %SRCDIR%\FORTHROM.lst

REM For RAM
REM %TASMEXE% -80 -g0 %SRCDIR%\FORTHROM.Z80 %SRCDIR%\FORTHRAM.hex %SRCDIR%\FORTHRAM.lst

PAUSE


