( Example 4 - Calculating a table of MPH     )
( based on measured mile in seconds          )
( based on exercise from ...                 )
( Problems for Computer Solution             )
( rachel8973@gmail.com                       )
( 14-Nov-2017                                )

COLD

40 CONSTANT MINTIME
70 CONSTANT MAXTIME

( Print out a D number with 2 decimal places )
HEX
: .2dp <# # # 2E HOLD #S #> TYPE ;
DECIMAL

( u -- d )
( Calculate the speed as scaled integer and  )
( fraction to two decimal places             ) 
: SPEED 3600 100 ROT */ 0 .2dp CR ;

( -- )
( Print a header )
: PR_HDR CR CR ." Time (s), Speed (mph) " CR ." --------,-------------" CR ; 

( -- )
( Print out a table of speeds )
: MK_TABLE PR_HDR MAXTIME 1+ MINTIME DO I DUP . ." ," SPEED LOOP ;

MK_TABLE
