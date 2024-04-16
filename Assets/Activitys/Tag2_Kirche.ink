INCLUDE Utility.ink
EXTERNAL spenden(amount)

-> main
=== main === 
Tag 2 - Kirche
Du bereitest dich vor zur Messe zu gehen.
Du weisst, dass Dolores gerne mit dir gehen möchste, vielleicht wäre es auch besser etwas mit deinem Freund aus der Mine zu unternehmen, oder soll ich doch alleine gehen?
Mit wem möchstest du gehen?
+[Familie]
-> MitFam
+[Freund]
-> MitFreu
+[Alleine]
-> Alleine

===MitFam===
~Unity_Event("happyFamily")
Du bittest deine Familie dich zu begleiten
Dolores findet das eine ganz wundervolle Idee.
->Messe

===MitFreu===
~Unity_Event("metFriend")
Du bittest deinen Freund dich zu begleiten
Er freut sich über deine Anfrage und sagt zu.
->Messe

===Alleine===
~Unity_Event("unhappyFamily")
Du entscheidest dich dazu alleine zur Messe zu gehen.
Dolores ist enttäuscht, dass du alleine gehst.
->Messe

===Messe===
In der Kirche predigt der Priester vom Geiz, dem man entsagen muss.
Er legt jedem nahe seine Arbeit fromm zu verrichten und andere, die mehr haben nicht zu beneiden.
Du denkst an deine Arbeit und an die Minengesellschaft, welche doch so viel mehr hat und dir nur einen Hungerlohn überlässt.
Wie kann das gerecht sein?
Nun stimmt der Priester zu einem gemeinsamen Gebet an. Was tust du?
+[Beten]
-> Beten
+[Schweigen]
-> Schweigen
+[An Familie denken]
-> Denken

===Beten===
~Add_State("segen",1)
Du entschliesst dich dem Gebet zu folgen mit der Hoffnung, dass Gott deine Bitte erhört.
{MitFam:->BetenFam}
{MitFreu:->BetenFreu}
->Spenden

===BetenFam===
Auch Dolores spricht das Gebet und schaut mit einem Lächeln zu dir rüber.
->Spenden

===BetenFreu===
Dein Freund sitzt nur da und starrt den Priester wortlos an. An was er wohl denkt?
->Spenden

===Schweigen===
Du entschliesst dich zu schweigen. Was bringt das schon? Nur du kannst dir helfen.
{MitFam:->SchweigenFam}
{MitFreu:->SchweigenFreu}
->Spenden
===SchweigenFam===
Dolores spricht das Gebet und als sie bemerkt, dass du schweigst wirft sie dir einen Vorwurfsvollen Blick zu.
->Spenden
===SchweigenFreu===
Dein Freund sitzt wie du nur da und starrt den Priester wortlos an. An was er wohl denkt?
->Spenden

===Denken===
Du entschliesst dich dan deine Familie zu denken. An das was dir etwas bedeutet. Denn sie sind der Grund warum du diese Arbeit auf dich nimmst.
{MitFreu:->DenkenFreu}
->Spenden

===DenkenFreu===
Dein Freund sitzt nur da und starrt den Priester wortlos an. An was er wohl denkt?
->Spenden

===Spenden===
Am Ende der Messe informiert der Hohe Geistliche über die Termine der nächsten Messen und ruft zu Spenden zu Gunsten der Kirche auf.
Du begibst dich zum Ausgang und siehst die Kollekte in die, die Leute vor dir Geld werfen.
Nun stehst du vor der Kollekte, was tust du?
+[10c Spenden]
-> 10c
+[50c Spenden]
-> 50c
+[Nicht Spenden]
-> NichtSpenden

===10c===
~ spenden("10")
Du entschliesst dich 10c in die Kollekte zu werfen.
{MitFam:->EpilogFam}
{MitFreu:->EpilogFreu}
->EpilogAllein

===50c===
~ spenden("50")
Du entschliesst dich 50c in die Kollekte zu werfen.
{MitFam:->EpilogFam}
{MitFreu:->EpilogFreu}
->EpilogAllein

===NichtSpenden===
Du entschliesst dich an der Kollekte vorbei zu gehen ohne etwas zu spenden.
{MitFam:->EpilogFam}
{MitFreu:->EpilogFreu}
->EpilogAllein

===EpilogFam===
Dolores bedankt sich nochmals bei dir, dass du mit ihr zur Messe gegangen bist.
{Get_State("segen") ==2: ->Segen}->end

===EpilogFreu===
Dein Freund bedankt sich nochmals, dass du mit ihm etwas unternommen hast.
{Get_State("segen") ==2: ->Segen}->end

===EpilogAllein===
Du verlässt die Kirche.
{Get_State("segen") ==2: ->Segen}->end

===Segen===
Du fühlst dich nach der Messe bereits schon viel besser.
Es scheint so als ob deine Gebete erhört wurden.
Du kannst morgen mit mehr Energie denn je an die Arbeit gehen.
~Unity_Event("segnung")
~Unity_Event("endDay")
-->END

=== end ===
Du denkst noch den ganzen Abnend an die Messe.
Morgen wird bestimmt alles besser.
~Unity_Event("endDay")
-->END

