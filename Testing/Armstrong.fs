( Armstrong Numbers    )
( rachel8973@gmail.com )
( An Armstrong number is a number that is equal )
( to then sum of the digits each raised to the  )
( power of the number of digits                 )
( e.g                                           )
( 1^3 + 5^3 + 3^3 = 153                         )  

( Order 3 )

COLD
: CUBE DUP DUP * * ;
: TRIOSPLT 100 /MOD SWAP 10 /MOD SWAP ;
: TRIOCUBESUM CUBE SWAP CUBE 3 ROLL CUBE + + ;
: ARMCHK DUP DUP TRIOSPLT TRIOCUBESUM - ABS ;
: ARMPRNT ARMCHK 0= IF . ."  ... is an Armstrong Number" CR ELSE DROP THEN ;

: RUN CR CR 1000 111 DO I ARMPRNT LOOP ;

( Order 4 )
 
COLD
: QUAD DUP DUP DUP * * * ;
: QUADSPLT 1000 /MOD SWAP 100 /MOD SWAP 10 /MOD SWAP ;
: 4QUADSUM QUAD SWAP QUAD 3 ROLL QUAD 4 ROLL QUAD + + + ;
: ARMCHK DUP DUP QUADSPLT 4QUADSUM - ABS ;
: ARMPRNT ARMCHK 0= IF . ."  ... is an Armstrong Number" CR ELSE DROP THEN ;

: RUN CR CR 10000 1111 DO I ARMPRNT LOOP ;
