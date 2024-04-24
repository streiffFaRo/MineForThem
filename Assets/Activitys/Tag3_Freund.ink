INCLUDE Utility.ink


-> main
=== main === 
Tag3 - Freund
Du folgst der Einladung deines Freundes.
Auf dem Weg zu seinem Haus fragst du dich um was es ihm wohl geht.
Dein Freund freut sich sehr dich zu sehen. Er begrüss dich herzlich und bietet dir etwas zu trinken an.
Dein Freund:" Wie steht es um dich nun, da du weisst wie die Arbeit ist?"
+[Passabel]
-> Passabel
+[Schlecht]
-> Schlecht
+[Schrecklich]
-> Schrecklich

===Passabel===
Du: "Naja es geht so, ich bin auf die Arbeit angewiesen. Ich mache das für meine Familie."
->AnsichtFreund

===Schlecht===
Du: "Es geht mir nicht gut. Die Arbeit ist anstrengend und die Bezahlung ist schlecht aber ich mache das für meine Familie."
->AnsichtFreund

===Schrecklich===
Du: "Es geht mir schrecklich. Ich kann nicht mehr. Wenn das Geld wenigstens genug wäre. Aber ich muss das für meine Familie machen."
->AnsichtFreund

===AnsichtFreund===
"Ich kann verstehen, dass du das für deine Familie machst. Ich arbeite nun schon seit drei Monaten in der Mine und du kannst dir vorstellen wie die Arbeit sich auf mich ausgewirkt hat."
"Was würdest du davon halten, wenn ich dir sage, dass wir möglicherweise einen Weg haben um an Geld zu kommen und es dem Vorarbeiter heimzuzahlen."
+[Interessiert]
-> Interesse
+[Nicht Interessiert]
-> NichtInteresse
+[Schweigen]
-> Schweigen

===Interesse===
"Das hört sich gut an, aber wie soll das gehen?"
"Ich habe mitbekommen, dass der Vorarbeiter in seinem Büro immer die Tageseinnahmen verwahrt."
->Plan
===NichtInteresse===
"Das hört sich nicht gut an. Ich arbeite lieber in der Mine als bei solchen zwielichtigen Aktionen mitzumachen."
"Hör mir doch erstmal zu, es wird für dich nicht so gefährlich sein, wie für mich."
"Ich habe mitbekommen, dass der Vorarbeiter in seinem Büro immer die Tageseinnahmen verwahrt."
->Plan

===Schweigen===
"..."
"Hör mir doch erstmal zu, es wird für dich nicht so gefährlich sein, wie für mich."
"Ich habe mitbekommen, dass der Vorarbeiter in seinem Büro immer die Wocheneinnahmen verwahrt."
->Plan

===Plan===
~Unity_Event("plan")
"Der Vorarbeiter weiss bereits, dass ich etwas gegen ihn plane. Ich habe das Gefühl manchmal von Leuten der Minengesellschaft überwacht zu werden."
"In zwei Tagen wird im Dorf ein Schiesswettbewerb abgehalten. Wenn du daran teilnimmst, steck dir einfach eine Kugel ein."
"Gib mir diese dann am nächsten Morgen und ich erledige den Rest."
"Mit dem Schlüssel des Vorarbeiters kann ich sein Büro plündern. Ich werde dir deinen gerechten Anteil geben."
"Du brauchst keine Angst zu haben, sie werden mich suchen und damit kann ich leben. Du musst nur deinen Anteil verstecken und kannst ein gutes Leben führen. Weg von der Mine."
"Was sagst du? Wirst du mir helfen?"
+[Helfen]
-> Helfen
+[Nicht Helfen]
-> NichtHelfen
+[Schweigen]
-> Schweigen2

===Helfen===
"Gut, ich werde dir die Munition besorgen."
"Wundervoll. Ich wusste du bist der Richtige dafür."
-> end

===NichtHelfen===
"Nein, sowas kann ich nicht verantworten."
"Schade. Ich habe gehofft, dass du mir helfen würdest. Ich bitte dich es dir nochmal zu überlegen. Ich brauch diese Munition."
-> end

===Schweigen2===
"..."
"Ich bitte dich es dir nochmal zu überlegen. Ich brauch diese Munition. ich glaube an dich!"
-> end

=== end ===
Nachdem ihr eure Getränke ausgetrunken habt und du dich zum gehen bereit machst begleitet er dich noch zur Tür.
"Ich bedanke mich für deinen Besuch. Ich glaube daran, dass du das Richtige tun wirst."
Nun weisst du, dass in zwei Tagen eine schwere Entscheidung auf dich warten wird.
Stiehlst du die Munition um mit einem Freund den Vorarbeiter beiseite zu schaffen und an das Geld zu kommen...
Oder bleibst du auf dem Rechten Weg und arbeitest weiter zu miserablen Bedingungen in der Mine?
~Unity_Event("endDay")
-->END

