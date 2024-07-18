INCLUDE Utility.ink
EXTERNAL spenden(amount)

-> main
=== main === 
You get ready to go to mass.
You know that Dolores would like to go with you, maybe it would be better to go with your friend from the mine, Davy, or do you want to go alone?
Who would you like to go to church with?
+[Dolores]
-> MitFam
+[Davy]
-> MitFreu
+[Alone]
-> Alleine

===MitFam===
~Unity_Event("happyFamily")
~Unity_Event("inviteDolores")
You ask your wife Dolores to accompany you. She thinks it's a wonderful idea.
->Messe

===MitFreu===
~Unity_Event("metFriend")
~Unity_Event("inviteDavy")
You ask your friend Davy to accompany you. He is pleased about your request and agrees.
->Messe

===Alleine===
~Unity_Event("unhappyFamily")
You decide to go to the service alone. Dolores is disappointed that you are going alone.
->Messe

===Messe===
In church, the priest preaches about greed, which must be renounced.
He urges everyone to do their work piously and not to envy others who have more.
You think of your work and of the mining company, which has so much more and only gives you barely enough to survive.
How can that be fair?
Now the priest starts a common prayer. What are you doing?
+[Pray]
-> Beten
+[Remain silent]
-> Schweigen
+[Think of family]
-> Denken

===Beten===
~Add_State("segen",1)
You decide to follow the prayer with the hope that God will hear your request.
{MitFam:->BetenFam}
{MitFreu:->BetenFreu}
->Spenden

===BetenFam===
Dolores also says the prayer and looks over at you with a smile.
->Spenden

===BetenFreu===
Davy just sits there and stares silently at the priest. I wonder what he's thinking about?
->Spenden

===Schweigen===
You decide to remain silent. What's the point? Only you can help yourself.
{MitFam:->SchweigenFam}
{MitFreu:->SchweigenFreu}
->Spenden
===SchweigenFam===
Dolores says the prayer and when she realises that you are silent, she gives you a reproachful look.
->Spenden
===SchweigenFreu===
Your friend just sits there like you and stares at the priest without a word. I wonder what he's thinking about?
->Spenden

===Denken===
You decide to think about your family. Of what means something to you. Because they are the reason why you are taking on this work.
{MitFreu:->DenkenFreu}
->Spenden

===DenkenFreu===
Your friend just sits there and stares silently at the priest. I wonder what he's thinking about?
->Spenden

===Spenden===
At the end of the mass, the high priest informs about the dates of the next masses and asks for donations in favour of the church.
You go to the exit and see the collection into which the people in front of you are putting money.
Now you are standing in front of the collection, what do you do?
+[Donate 10c]
-> 10c
+[Donate 50c]
-> 50c
+[Refuse]
-> NichtSpenden

===10c===
~ spenden("10")
You decide to throw 10c into the collection.
~Unity_Event("UpdateMoneyUI")
{MitFam:->EpilogFam}
{MitFreu:->EpilogFreu}
->EpilogAllein

===50c===
~ spenden("50")
You decide to throw 50c into the collection.
~Unity_Event("UpdateMoneyUI")
{MitFam:->EpilogFam}
{MitFreu:->EpilogFreu}
->EpilogAllein

===NichtSpenden===
You decide to walk past the collection without donating anything.
{MitFam:->EpilogFam}
{MitFreu:->EpilogFreu}
->EpilogAllein

===EpilogFam===
Dolores thanks you again for going to mass with her.
{Get_State("segen") ==2: ->Segen}->end

===EpilogFreu===
Your friend thanks you for spending time with him.
{Get_State("segen") ==2: ->Segen}->end

===EpilogAllein===
You leave the church.
{Get_State("segen") ==2: ->Segen}->end

===Segen===
You already feel much better after the mass.
It seems that your prayers have been answered.
You can go to work tomorrow with more energy than ever.
~Unity_Event("segnung")
~Unity_Event("endDay")
~Unity_Event("clearDay3")
-->END

=== end ===
You're still thinking about the mass the whole evening.
Everything will certainly be better tomorrow.
~Unity_Event("endDay")
~Unity_Event("clearDay3")
-->END

