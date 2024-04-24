INCLUDE Utility.ink
EXTERNAL ordoredDrink(drink)
EXTERNAL saloon(betAmount)


-> main
=== main === 
~Unity_Event("checkVisit")
~Unity_Event("metFriend")
When you visit the saloon, you see Davy, your friend from the mine. He seems very pleased to see you.
He waves you over to his table and greets you in a friendly manner.
He says: "Let's order something first. What do you like to drink? I'll buy it!"
+[Water]
-> Wasser
+[Beer]
-> Bier
+[Whiskey]
-> Whiskey

=== Wasser ===
~ ordoredDrink("Wasser")
You sit down and a cool drink of water is brought to you. Your friend took a beer.
{Get_State("visited") ==1: ->visitedPoker} -> Spiel

=== Bier ===
~ ordoredDrink("Bier")
You sit down and a cold beer is brought to you and your friend.
{Get_State("visited") ==1: ->visitedPoker} -> Spiel

=== Whiskey ===
~ ordoredDrink("Whiskey")
You sit down and a glass of whiskey is brought to you. Your friend took a beer.
{Get_State("visited") ==1: ->visitedPoker} -> Spiel


===visitedPoker===
Davy: "I saw you playing poker yesterday. I have to warn you, it can be a dark road."
Davy: "I'm just trying to help you. I've seen a lot of people meet their miserable end in this town."
Davy: "I hope you won't become one of them."
->Spiel

===Spiel
Davy: "Fancy a little drinking game?"
+[Accept ($1)]
-> Eins
+[Accept ($3)]
-> Drei
+[Refuse]
-> Ablehnen

=== Eins ===
~ saloon("1")
You: "All right, let's play for $1."
{Get_State("round") ==1: ->Gewonnen} -> Verloren

=== Drei ===
~ saloon("3")
You: "All right, let's play for $3."
{Get_State("round") ==1: ->Gewonnen} -> Verloren

=== Ablehnen ===
You: "That's not for me, I refuse."
->WieGehts

=== Gewonnen ===
You drink and drink until your friend can't take any more. You've won!
~Unity_Event("clearRound")
->WieGehts

=== Verloren ===
You drink and drink until you can't drink any more. You have lost!
->WieGehts

=== WieGehts
Davy: "Whatever. How are you doing now?"
+[Good]
-> Gut
+[Decent]
-> Passabel
+[Bad]
-> Schlecht

=== Gut ===
You: "I'm doing well. I'm getting by and it's not easy to find work."
->end

=== Passabel ===
You: "Well, I'm just about managing. The work is hard but it's not easy to find work"
->end

=== Schlecht ===
You: "It was the best thing I found. I need money for my family and it's not easy to find work."
->end

=== end ===
Davy: "Well, I can tell you frankly that after three months I'm completely exhausted. The mining company earns a fortune from our work and we don't have enough to live a decent life."
Davy "I'm trying to find a way to avoid this. But enough of that, it's getting late. Have a nice evening."
You leave the saloon, still thinking about Davy's words.
~Unity_Event("endDay")
-->END

