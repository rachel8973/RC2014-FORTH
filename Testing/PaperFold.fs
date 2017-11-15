( Example 5 - How many times can you fold    )
( a 0.01 inch thick sheet of paper until     )
( it is 1 mile thick                         )
( based on exercise from ...                 )
( Problems for Computer Solution             )
( rachel8973@gmail.com                       )
( 14-Nov-2017                                )
COLD

( n1 n2 n3 -- n1 n2 n3 )
: DBLUP DUP + ROT ;

( n1 n2 n3 -- n1 n2 n3 )
: DBLALL DBLUP DBLUP DBLUP ;

( n1 n2 n3 -- n1 n2 n3 )
: DIVCARRY /MOD ROT + 3 ROLL SWAP ;

( n1 n2 n3 -- n1 n2 n3 )
: FOLDPAPER DBLALL 1200 DIVCARRY 5280 DIVCARRY ROT ROT .S ;

( -- )
: PR_TITLE CR ." MILES  - FEET - INCHES/100" CR ." ---------------- " ;

( The stack is initialised with 3 numbers )
( representing the thickness of the paper )
( n1 n2 n3 n4 -- print table of results )
: RUN 0 DO CR I 1+ .  FOLDPAPER LOOP ;


PR_TITLE 
0 0 1 30 RUN

