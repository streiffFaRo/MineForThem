INCLUDE Utility.ink
EXTERNAL platz(ort)
EXTERNAL bait(bait)

-> main
=== main === 
Tag 4 - Angeln
Du entschliesst dich heute zum entspannen einen kleinen Angelausflug zu machen.
Mit einem guten Fang kannst du zusätzlich noch etwas Geld für die Familie verdienen.
Als erstes musst du dich für einen Angelplatz entscheiden.
Der Platz im Süden hat viele kleine Fische, dort kann man sicher etwas fangen, aber ob sich das lohnt.
Im Nordosten neben der Bahnstation gibt es einen Teich mit sehr grossen Fischen, die Frage ist nur ob einer anbeisst.
Sonst gibt es da noch im Westen einen Tümpel der Recht ausgewogen ist.
Wo möchtest du angeln gehen?
+[Süden]
-> Sueden
+[Nordosten]
-> Nordosten
+[Westen]
-> Westen

===Sueden===
~ platz("1")
Du hast dich für den vielbevölkerten Süden entschieden.
->Koeder

===Nordosten===
~ platz("3")
Du hast dich für den Teich mit den grossen Fischen im Nordosten entschieden.
->Koeder

===Westen===
~ platz("2")
Du machst dich auf den in Westen um dort zu angeln.
->Koeder

===Koeder===
Nun ist die Wahl des richtigen Köders wichtig.
Käse ist ein sehr einfacher und günstiger Köder.
Grillen sind ein solider Köder bei dem auch grosse Fische angelockt werden können.
Ein Kunstköder ist eine grunsätzlich eine sichere Wahl. Sie haben aber ihren Preis.
Für welchen Köder entscheidest du dich?
+[Käse 30c]
-> Kaese
+[Grillen $1]
-> Grillen
+[Kunstköder $4]
-> Kunstkoeder

===Kaese===
~ bait("1")
Du hast dich für den kostengünstigen Käse entschieden.
->Durchgang1

===Grillen===
~ bait("2")
Du hast dich für die Grillen entschieden.
->Durchgang1

===Kunstkoeder===
~ bait("3")
Du hast dich für den teuren Kunstköder entschieden.
->Durchgang1

===Durchgang1===
~Unity_Event("clearRound")
~Unity_Event("catch")
Du beginnst deinen Köder am Angelhaken zu befestigen und lehnst dich etwas zurück.
.
..
...
Es hat etwas angebissen!
Schnell versuchst du den Fisch einzuholen. Du kurbelst an der Angelschnur...
{Get_State("round") ==1: ->Win1} -> Lose1

===Win1===
Und das ist er! Es ist dir gelugen ihn an Land zu bringen.
Du schätzt seinen Wert auf {Get_State("price")}c.
->Durchgang2

===Lose1===
Der Fisch konnte sich vom Haken lösen.
Er ist entkommen!
->Durchgang2

===Durchgang2===
~Unity_Event("clearRound")
~Unity_Event("catch")
Du machst den nächsten Köder an den Haken und wartest auf das nächste Anzeichen, dass ein Fisch anbeisst.
.
..
...
Ein Fisch ist am Haken!
Du beginnst die Angelschnur einzuholen.
{Get_State("round") ==1: ->Win2} -> Lose2

===Win2===
Du hast es geschafft! Ein guter Fang.
Du schätzt seinen Wert auf {Get_State("price")}c.
->Durchgang3


===Lose2===
Doch als die Schnur aus dem Wasser ist, siehst du, dass sich bloss ein alter Siefel am Haken verfangen hat.
Der Köder ist dabei abgefallen.
->Durchgang3

===Durchgang3===
~Unity_Event("clearRound")
~Unity_Event("catch")
Einen Versuch willst du noch unternehmen. Du nimmst den letzten Köder und steckst ihn an.
.
..
...
Es zappelt!
Du beginnst an der Kurbel zu drehen.
{Get_State("round") ==1: ->Win3} -> Lose3

===Win3===
Dir gelingt es den Fisch erfolgreich an Land zu holen!
Du schätzt seinen Wert auf {Get_State("price")}c.
-> end

===Lose3===
Der Fisch sperrt sich und ziet an der Angelschnur.
Du versuchst dagegen zu halten.
Beim Verusch den Fisch zu bergen ist die Schnur gerissen.
Der Fisch ist entkommen!
-> end


=== end ===
Du beginnst deine Ausrüstung zusammen zu packen und dich auf den Heimweg zu machen.
~Unity_Event("endDay")
-->END




