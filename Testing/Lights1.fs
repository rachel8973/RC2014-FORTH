( Example 3 - Using the RC2014 IO Board      )
( An adaption of the Traffic Lights example  )
( from chapter 26 of theJupiter Ace Manual.  )
( rachel8973@gmail.com                       )
( 10-Nov-2017                                )

( WRITES TO IO Board - port 0) 
( data --  ) 
: CHANGE 0 P! ;

( SET COLOURS )
128 CONSTANT RED
 64 CONSTANT AMBER
 32 CONSTANT GREEN
RED AMBER OR CONSTANT RED_AMBER

( Wait - Max input 32768)
( delay -- delay )
: WAIT DUP 0 DO DUP DROP LOOP ;

( A definition which creates a command )
( create new words based on parameters )
: LIGHT CREATE C, DOES> C@ CHANGE WAIT ;

RED LIGHT S_RED
AMBER LIGHT S_AMBER
RED_AMBER LIGHT S_REDAMB
GREEN LIGHT S_GREEN

( delay -- delay )
: SEQUENCE S_RED S_REDAMB S_GREEN S_AMBER ;

( Run Forever )
: RUNLIGHTS BEGIN SEQUENCE 0 UNTIL ;

10000 RUNLIGHTS