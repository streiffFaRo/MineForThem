INCLUDE Utility.ink
EXTERNAL poker(betAmount)

->main
=== main ===
Du triffst dich mit ein paar Freunden der Minengesellschaft zum Pokerabend
Die wird ein Stuhl angeboten und du setzt dich hin
Dolores beführwortet deine Spielabende nicht, aber es ist eine möglichkeit mit ein wenig Geschick etwas mehr Geld für die Familie zu verdienen.

-> r1
=== r1 === 
Hallo, ich bin ein Test text.
~Add_State("round",0)
Welches Vieh willst du?
+[25c]
-> r1_25c
+[50c]
-> r1_50c
+[1$]
-> r1_1d

=== r1_25c ===
~ poker("25")
Du hast mikrigen Einsatz gewählt gewählt!
{Get_State("round") ==1: ->r1g} -> r1v

=== r1_50c ===
~ poker("50")
Du hast einen normalen Einsatz gewählt!
{Get_State("round") ==1: ->r1g} -> r1v

=== r1_1d ===
~ poker("100")
Du hast einen hohen Einsatz gewählt!
{Get_State("round") ==1: ->r1g} -> r1v

=== r1g ===
Du hast {Get_State("roundChange")}c gewonnen!
~Unity_Event("clearRound")
->r2

=== r1v ===
Du hast {Get_State("roundChange")}c verloren!
->r2


=== r2 ===
Runde 2
Hier sind die Choices
+[25c]
-> r2_25c
+[50c]
-> r2_50c
+[1$]
-> r2_1d

=== r2_25c ===
~ poker("25")
Du hast mikrigen Einsatz gewählt gewählt!
{Get_State("round") ==1: ->r2g} -> r2v

=== r2_50c ===
~ poker("50")
Du hast einen normalen Einsatz gewählt!
{Get_State("round") ==1: ->r2g} -> r2v

=== r2_1d ===
~ poker("100")
Du hast einen hohen Einsatz gewählt!
{Get_State("round") ==1: ->r2g} -> r2v

=== r2g ===
Du hast {Get_State("roundChange")}c gewonnen!
~Unity_Event("clearRound")
->r3

=== r2v ===
Du hast {Get_State("roundChange")}c verloren!
->r3

=== r3 ===
Runde 3
Hier sind die Choices
+[25c]
-> r3_25c
+[50c]
-> r3_50c
+[1$]
-> r3_1d

=== r3_25c ===
~ poker("25")
Du hast mikrigen Einsatz gewählt gewählt!
{Get_State("round") ==1: ->r3g} -> r3v

=== r3_50c ===
~ poker("50")
Du hast einen normalen Einsatz gewählt!
{Get_State("round") ==1: ->r3g} -> r3v

=== r3_1d ===
~ poker("100")
Du hast einen hohen Einsatz gewählt!
{Get_State("round") ==1: ->r3g} -> r3v

=== r3g ===
Du hast {Get_State("roundChange")}c gewonnen!
~Unity_Event("clearRound")
->Epilog

=== r3v ===
Du hast {Get_State("roundChange")}c verloren!
->Epilog

=== Epilog ===
Gutes Spiel
->end
=== end ===
~Unity_Event("endDay")
-->END

