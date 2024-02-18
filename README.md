# RC2014-FORTH

I forked original project and corrected one obvious mistake (`,` instead of `'`).

Than I realised I can't compile it, because digging out TASM and trying to run it in a virtual machine is just too much for me.
So I ported this to GNU AS.

Surprisinly, I found two differences that are not easy to explain.

```
--- /dev/fd/63  2024-02-18 16:04:46.994421948 +0000
+++ /dev/fd/62  2024-02-18 16:04:46.994421948 +0000
@@ -289,7 +289,7 @@
 00001200: 8d0b 6b0a 4f0a f407 3a06 6b0a f407 7106  ..k.O...:.k...q.
 00001210: 200d 270a 3708 7106 c204 270a 3a06 3708   .'.7.q...'.:.7.
 00001220: 7106 c204 c546 4f52 54c8 e511 2c0d 1a12  q....FORT...,...
-00001230: 8120 34fe 0000 8b44 4546 494e 4954 494f  . 4....DEFINITIO
+00001230: 81a0 34fe 0000 8b44 4546 494e 4954 494f  ..4....DEFINITIO
 00001240: 4ed3 2412 b406 3708 3a06 4508 7106 c204  N.$...7.:.E.q...
 00001250: c1a8 3612 b406 c401 2900 3d0f be05 c204  ..6.....).=.....
 00001260: 8451 5549 d450 12b4 062b 07fe 0771 0682  .QUI.P...+...q..
@@ -339,7 +339,7 @@
 00001520: 8d45 4d50 5459 2d42 5546 4645 52d3 1515  .EMPTY-BUFFER...
 00001530: b406 6607 7607 af05 8c0a f20e c204 8642  ..f.v..........B
 00001540: 5546 4645 d220 15b4 0655 15c2 0485 424c  UFFE. ...U....BL
-00001550: 4f43 cb3e 15b4 06c4 01b1 ff13 1429 083a  OC.>.........).:
+00001550: 4f43 cb3e 15b4 06c4 0128 0013 1429 083a  OC.>.....(...).:
 00001560: 064b 0586 07e4 1366 074b 05c2 0483 522f  .K.....f.K....R/
 00001570: d74d 15b4 0609 093a 06d9 01c2 04b4 06be  .M.....:........
 00001580: 05be 05be 05c2 0485 464c 5553 c86d 15b4  ........FLUS.m..
```

## Difference 1
At line `0x1230`.

Original listing says:
```
2769   1230 81 20       	.BYTE	81h," "+80h
```

I *guess* it's an undefined behaviour of concatenating string with number.

After my changes it's: *(offset because GAS is numbering within section, not from 0)*
```
 3044 10dd 81 A0       		.BYTE	81h,' '+80h
```

## Difference 2
At line `0x1550`

Original listing says:
```
0031   0144             DISK_START:	.EQU	0A000h		;Pseudo disk buffer start
0032   0144             DISK_END:	.EQU	0F000h		;Pseudo disk buffer end
0033   0144             BLOCK_SIZE:	.EQU	0200h		;Pseudo disk block size
...
3240   1559 B1 FF       	.WORD	DISK_END/BLOCK_SIZE-DISK_START/BLOCK_SIZE
```

I changed it a bit, but even before I was getting different value:
```
  31                 	DISK_START:	.EQU	0A000h		;Pseudo disk buffer start
  32                 	DISK_END:	.EQU	0F000h		;Pseudo disk buffer end
  33                 	BLOCK_SIZE:	.EQU	0200h		;Pseudo disk block size
...
  36                 	MAX_DISK_BLOCKS = (DISK_END-DISK_START)/BLOCK_SIZE
...
 3565 1406 28 00       		.WORD	MAX_DISK_BLOCKS ;Max number of blocks
```
I think 40 blocks is the correct value (instead of some negative number...).
The only explanation I can think of is that TASM doesn't have arithmetic operations precedence.

Original files are in the [original](original) directory.
Original README follws.

---

I know NOTHING about FORTH but I just want something simple to mess around with.

I found a simple FORTH buried in a ZIP file on the Z80 info site at ...

http://www.z80.info/zip/z80asm.zip

I have no idea of it's origin but from snooping around it seems to be fig-forth-79 or based on that.

https://archive.org/details/FigFORTHGlossary

I combined it with Grant Searles initialisation and referenced the routines for the TXA and RXA where necessary.

Built with  ... TASM -80 -b -c -dROM FORTH.Z80 FORTHROM.bin FORTHROM.lst ... For ROM binary

or 

Built with ... TASM -80 -g0 FORTH.Z80 FORTHRAM.hex FORTHRAM.lst ... For RAM Hex file to run from Monitor

After some messing around and realising that I need to AND 7F to knock off the top bit of the characters
as it uses this as an end of word marker.
