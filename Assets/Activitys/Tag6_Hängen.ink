INCLUDE Utility.ink

-> main

===main===
Als ich auf den Marktplatz ging sah ich es schon - ein Galgen.
Ist er für mich gedacht oder mache ich mir nur zu viel Stress? Ich habe nur meine Pflicht als gesetzestreuer Bürger erfüllt.
Sollte ich vielleicht meine Familie nehmen und fliehen?
Was tust du?
+[Fliehen]
-> Flucht
+[Zum Sheriff]
-> Sheriff

===Flucht===
Du gehst du deiner Familie und fliehst in die nächste Stadt. 
~Unity_Event("escaped")
->END

===Sheriff===
Du gehst mit einem mulmigen Gefühl im Magen zum Sheriff.
Er begrüsst dich mit:"Ach, Ihr seid es. Gut Euch zu sehen, es wird Euch freuen zu hören, dass wir den Verräter den Ihr uns gemeldet habt festnehmen konnten."
Weiter sagt er:"Meine Männer werden ihn gleich fertig machen für seine gerechte Strafe."
Er bemerkt:"Sag, geht es Euch nicht gut? Ihr seht etwas mitgenommen aus."
+[Schlecht gegessen]
->schlecht
+[Alles gut]
->gut

===schlecht===
"Ich glaube ich habe etwas schlechtes gegessen"
->kommen

===gut===
"Nein bei mir ist alles gut."
->kommen

===kommen
Der Sheriff:"Ach wie auch immer, hier kommt er."
Du blickst in die leeren Augen deines Freundes als er zum Galgen geführt wird.
Als er dich sieht runzelt er die Stirn, bringt aber kein Wort heraus.
Die Leute des Sheriffs legen ihm den Strick um den Nacken und einer begibt sich zum Hebel, der das Urteil vollstrecken wird.
Mittlerweile hat sich eine kleine Menge vor dem Galgen versammelt.
Der Sheriff:"Gute Leute, dieser Schuft hat versucht die Minengesellschaft, welche die Stadt und so uns alle unterstütz zu hintergehen."
Weiter spricht er:"Aufgrund des versuchen Verrats und dem geplanten Mord eines Vorarbeiters verurteile ich ihn hiermit zum Tode! Ausführen!"
Der Hebel wird gezogen und die Platform, welche deinen Freund noch gehalten hat fällt weg.
Du verlässt den Platz und auf dem Heimweg fragst du dich ob es das Richtige war, dass du getan hast.
~Unity_Event("snitched")
-->END





