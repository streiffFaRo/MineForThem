INCLUDE Utility.ink
EXTERNAL poker(betAmount)

->main
=== main ===
~Unity_Event("visitedPoker")
You meet up with a few friends from the mining company for a poker night.
You are on the upper floor of the saloon. The atmosphere is very cheerful.
Dolores is not in favour of your game nights, but it is a way to earn a little more money for the family.
You sit down at the table and think about how much you want to bet.
~Add_State("round",0)
Round 1: Choose a stake!
+[25c]
-> r1_25c
+[50c]
-> r1_50c
+[1$]
-> r1_1d

=== r1_25c ===
~ poker("25")
You've chosen a micrious insert!
.
..
...
{Get_State("round") ==1: ->r1g} -> r1v

=== r1_50c ===
~ poker("50")
You have chosen a normal insert!
.
..
...
{Get_State("round") ==1: ->r1g} -> r1v

=== r1_1d ===
~ poker("100")
You have chosen a high insert!
.
..
...
{Get_State("round") ==1: ->r1g} -> r1v

=== r1g ===
You won {Get_State("roundChange")}c with two jacks in your hand!
~Unity_Event("clearRound")
->r2

=== r1v ===
With a 6 and a 7 in your hand, it wasn't enough to win this round. You lost {Get_State("roundChange")}c!
->r2

=== r2 ===
Round 2: Choose a stake!
+[25c]
-> r2_25c
+[50c]
-> r2_50c
+[1$]
-> r2_1d

=== r2_25c ===
~ poker("25")
You've chosen a micrious stake!
.
..
...
{Get_State("round") ==1: ->r2g} -> r2v

=== r2_50c ===
~ poker("50")
You have chosen a normal stake!
.
..
...
{Get_State("round") ==1: ->r2g} -> r2v

=== r2_1d ===
~ poker("100")
You have chosen a high stake!
.
..
...
{Get_State("round") ==1: ->r2g} -> r2v

=== r2g ===
You won this round with a full house and took {Get_State("roundChange")}c!
~Unity_Event("clearRound")
->r3

=== r2v ===
Because you only had a 2 and a 9, you lost this round {Get_State("roundChange")}c!
->r3

=== r3 ===
Last Round: Choose a stake!
+[25c]
-> r3_25c
+[50c]
-> r3_50c
+[1$]
-> r3_1d

=== r3_25c ===
~ poker("25")
You've chosen a micrious stake!
.
..
...
{Get_State("round") ==1: ->r3g} -> r3v

=== r3_50c ===
~ poker("50")
You have chosen a normal stake!
.
..
...
{Get_State("round") ==1: ->r3g} -> r3v

=== r3_1d ===
~ poker("100")
You have chosen a high stake!
.
..
...
{Get_State("round") ==1: ->r3g} -> r3v

=== r3g ===
Two pairs have brought you victory. You have taken {Get_State("roundChange")}c this round!
~Unity_Event("clearRound")
->Epilog

=== r3v ===
You have lost with your straight against a flush and have left {Get_State("roundChange")}c behind!
->Epilog

=== Epilog ===
The evening is over and you make your way home again.
~Unity_Event("endDay")
-->END

