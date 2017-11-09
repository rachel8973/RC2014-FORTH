@ECHO OFF
CLS
REM ===========================================================================
REM   Build Z80 Forth
REM ===========================================================================
SET TASMTABS=P:\Z80\TASM32\
SET TASMEXE=%TASMTABS%TASM
SET TASMOPTS=-80 -b -c
SET SRCDIR=P:\Z80\Forth

%TASMEXE% %SRCDIR%\FORTHROM.Z80 %SRCDIR%\FORTHROM.bin %SRCDIR%\FORTHROM.lst

PAUSE


