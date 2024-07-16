INCLUDE Utility.ink

-> main

===main===
As you are walking onto the market square, you can already see the gallows.
Are they meant for you? You were just fulfilling your duty as a law-abiding citizen.
Should you perhaps take your family and flee? Or will you be paranoid? What are you doing?
+[Escape]
-> Flucht
+[Go to Sheriff]
-> Sheriff

===Flucht===
You go to your family and flee to the next town. 
~Unity_Event("escaped")
->END

===Sheriff===
You go to the sheriff with a queasy feeling in your stomach.
He greets you with: "Oh, it's you. Good to see you, you'll be pleased to hear that we were able to arrest the criminal you reported to us."
Sheriff: "My men are about to finish him off for his just punishment."
Sheriff: "Tell me, aren't you feeling well? You look a bit worn out."
+[Badly eaten]
->schlecht
+[Everything fine]
->gut

===schlecht===
You: "I think I've eaten something bad"
->kommen

===gut===
You: "No, everything's fine."
->kommen

===kommen
The sheriff: "Whatever, here he comes."
You look into the empty eyes of your friend as he is led to the gallows.
When he sees you, he frowns but doesn't say a word.
The sheriff's men put the rope around his neck and one of them goes to the lever that will carry out the sentence.
In the meantime, a small crowd has gathered in front of the gallows.
Sheriff: "Good people, this scoundrel tried to defraud the mining company that supports the town and thus all of us."
Sheriff: "Because of the attempted betrayal and the planned murder of a foreman, I hereby sentence him to death! Execute!"
The lever is pulled and the platform that was still holding your friend falls away.
You leave the square and on the way home you ask yourself whether you did the right thing.
~Unity_Event("snitched")
-->END





