( Example 5 - How many times can you fold    )
( a 0.01 inch thick sheet of paper until     )
( it is 1 mile thick                         )
( based on exercise from ...                 )
( Problems for Computer Solution             )
( rachel8973@gmail.com                       )
( 14-Nov-2017                                )
COLD

: DBLUP DUP + ROT ;
: DBLALL DBLUP DBLUP DBLUP ;
: DIVCARRY /MOD ROT + 3 ROLL SWAP ;
: FOLDPAPER DBLALL 1200 DIVCARRY 5280 DIVCARRY ROT ROT .S ;
: PR_TITLE CR ." MILES  - FEET - INCHES/100" CR ." ---------------- " ;
: RUN 0 DO CR I 1+ .  FOLDPAPER LOOP ;

PR_TITLE 
0 0 1 30 RUN

