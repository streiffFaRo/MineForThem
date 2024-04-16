INCLUDE Utility.ink
EXTERNAL ordoredDrink(drink)
EXTERNAL saloon(betAmount)


-> main
=== main === 
~Unity_Event("checkVisit")
~Unity_Event("metFriend")
Hallo, das ist Tag1 - Saloon
Wie geht es dir?
Lass uns erstmal etwas bestellen.
Was trinkst du gerne? Ich gebe dir einen aus!
+[Wasser]
-> Wasser
+[Bier]
-> Bier
+[Whiskey]
-> Whiskey

=== Wasser ===
~ ordoredDrink("Wasser")
Ihr sezt euch hin und dir wird ein kühles Wasser gebracht.
{Get_State("visited") ==1: ->visitedPoker} -> Spiel

=== Bier ===
~ ordoredDrink("Bier")
Ihr sezt euch hin und dir wird ein kühles Bier gebracht.
{Get_State("visited") ==1: ->visitedPoker} -> Spiel

=== Whiskey ===
~ ordoredDrink("Whiskey")
Ihr sezt euch hin und dir wird ein Glas Whiskey gebracht.
{Get_State("visited") ==1: ->visitedPoker} -> Spiel


===visitedPoker===
Dein Freund: "Ich habe dich gestern beim Poker Spielen gesehen. Ich muss dich warnen, das kann ein dunkler Weg sein."
Dein Freund: "Ich versuche dir nur zu helfen. Ich habe schon viele Leute gesehen die ihr elendes Ende fanden in dieser Stadt."
Dein Freund: "Ich hoffe du wirst keiner von ihnen werden."
->Spiel

===Spiel
Lust auf ein kleines Trinkspielchen?
+[Annehmen ($1)]
-> Eins
+[Annehmen ($3)]
-> Drei
+[Ablehnen]
-> Ablehnen

=== Eins ===
~ saloon("1")
Gut, lass uns um $1 spielen.
{Get_State("round") ==1: ->Gewonnen} -> Verloren

=== Drei ===
~ saloon("3")
Gut, lass uns um $3 spielen.
{Get_State("round") ==1: ->Gewonnen} -> Verloren

=== Ablehnen ===
Das ist nichts für mich, ich lehne ab.
->WieGehts

=== Gewonnen ===
Du trinkst und trinkst bis dein Freund nicht mehr kann. Du hast gewonnen!
~Unity_Event("clearRound")
->WieGehts

=== Verloren ===
Du trinkst und trinkst bis du nicht mehr kannst. Du hast verloren!

->WieGehts

=== WieGehts
Wie auch immer. Wie geht es dir jetzt?
+[Gut]
-> Gut
+[Passabel]
-> Passabel
+[Schlecht]
-> Schlecht

=== Gut ===
Mir geht es gut. Ich schlage mich so durch und Arbeit ist nicht leicht zu finden.
->end

=== Passabel ===
Naja, es geht gerade so. Die Arbeit ist hart aber ich komme noch klar.
->end

=== Schlecht ===
Es war das beste was ich gefunden habe. Ich brauche Geld für meine Familie.
->end

=== end ===
Also ich kann dir offen sagen, dass ich nun nach drei Monaten völlig fertig bin. Die Minengesellschaft verdient durch unsere Arbeit ein Vermögen und wir haben nicht genug um ein Vernünftiges Leben zu führen.
Ich versuche einen Weg zu finden dem zu entgehen.
~Unity_Event("endDay")
-->END

