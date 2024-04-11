INCLUDE Utility.ink
EXTERNAL category(number)


-> main
=== main === 
~Unity_Event("clearRound")
Tag 5 - Schiessen
Du besuchst den heutigen Schiesswettbewerb im Dorf.
Es gibt drei Preiskategorie, in der ersten ist der Einsatz bei 50c, der Gewinn beträgt $2.
Die Zweite Kategorie kostet $2 und der beste Schütze erhält $5
Bei der Kategorie mit den besten Schützen, kostet die Teilnahme $5 und der Hauptgewinn beträgt $10.
In welcher Preiskategorie möchtest du teilnehmen?
+[1. Kategorie]
-> Eins
+[2. Kategorie]
-> Zwei
+[3. Kategorie]
-> Drei

===Eins===
~ category("1")
Du lässt dich für die erste Kategorie einschreiben.
->Wettbewerb

===Zwei===
~ category("2")
Du lässt dich für die zweite Kategorie einschreiben.
->Wettbewerb

===Drei==
~ category("3")
Du lässt dich für die dritte Kategorie einschreiben.
->Wettbewerb


===Wettbewerb===
~Unity_Event("checkPlan")
Jeder Schütze begibt sich zu seinem Stand.
Vor dir liegt ein Revolver, noch ungeladen.
Zu Treffen sind 6 Dosen, welche gut 25m von den Schützen entfernt sind.
Der Schiessmeister beginnt nun mit dem Austeilen der Munition und gibt das Wettschiessen frei.
{Get_State("knowsPlan") ==1: ->knowsPlan} -> NotKnowsPlan

===knowsPlan===
Du denkst an den Plan deines Freundes.
Wenn dann wäre jetzt die Möglichkeit die Munition zu stehlen.
Nur eine Patrone wäre nötig für den Plan.
Wie entscheidest du dich?
+[Patrone stehlen]
-> Stehlen
+[Nicht stehlen]
-> NichtStehlen

===Stehlen===
~Unity_Event("stealRound")
Du steckst eine Patrone unauffällig in deine Hosentsche.
Keiner vermutet etwas.
Du beginnst auf die Dosen zu schiessen als ob nichts wäre.
{Get_State("round") ==1: ->Win} -> Lose

===NichtStehlen===
Du denkst kurz darüber nach sie zu nehmen, doch dann besinnst du dich wieder.
Du beginnst du die Dosen zu schiessen und fokusierst dich aufs Gewinnen.
{Get_State("round") ==1: ->Win} -> Lose

===NotKnowsPlan===
{Get_State("round") ==1: ->Win} -> Lose

===Win===
Du hast die meisten Dosen getroffen und damit in deiner Kategorie gewonnen!
Damit hast du den Preis von ${Get_State("price")} erhalten!
->WayHome

===Lose===
Du hast nicht genug Dosen getroffen. Du hast in deiner Kategorie verloren.
->WayHome

===WayHome===
Du gehst nach dem Schiessen wieder nach Hause.
Auf dem Wege zu deiner Familie beginnst du über deine Familie, deine Arbeit und deine Entscheidungen nachzudenken.
{NichtStehlen: ->Snitch} ->end

===Snitch===
~Unity_Event("snitched")
Du denkst an deinen Freund.
Du denkst daran wie er dich in diesen Plan reinreden wollte.
Vielleicht ist er gefährlich...
Vielleicht muss man ihn stoppen...
Vielleicht musst DU ihn stoppen...
Vielleicht musst du ihm beim Sheriff melden.
Wirst du deinen Freund verraten?
+[Verraten]
-> Verraten
+[Schweigen]
-> Schweigen

===Verraten===
Du entschliesst dich auf dem Weg nach hause noch zum Sheriff zu gehen.
Du schilderst ihm die Geschehnisse und den verbrecherischen Plan deines Freundes.
Der Sheriff glaubt dir sofort und beruhig dich: "Keine Sorge guter Mann, ich werde mich darum kümmern."
Du verlässt dann das Sheriffsbüro und fragst dich, ob das wohl das Richtige war...
->end

===Schweigen===
Du entschliesst dich nichts zu sagen. Dein Freund mag diesen Plan haben, doch du siehst dich nicht als Verräter.
Ob das wohl das Richtige war...
->end

=== end ===
~Unity_Event("endDay")
-->END

