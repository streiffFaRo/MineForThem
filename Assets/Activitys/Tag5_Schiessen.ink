INCLUDE Utility.ink
EXTERNAL category(number)


-> main
=== main === 
~Unity_Event("clearRound")
You are attending today's shooting competition in the city.
There are three prize categories, in the first the stake is 50c, the prize is $2.
The second category costs $2 and the best shooter receives $5
In the best shooter category, the entry fee is $5 and the grand prize is $10.
In which price category would you like to participate?
+[1. category]
-> Eins
+[2. category]
-> Zwei
+[3. category]
-> Drei

===Eins===
~ category("1")
You register for the first category.
->Wettbewerb

===Zwei===
~ category("2")
You register for the second category.
->Wettbewerb

===Drei==
~ category("3")
You register for the third category.
->Wettbewerb


===Wettbewerb===
~Unity_Event("checkPlan")
Each shooter goes to his stand.
In front of you is a revolver, still unloaded.
There are 6 cans to hit, which are a good 25 metres away from the shooters.
The shooting master now begins to hand out the ammunition and starts the shooting competition.
{Get_State("knowsPlan") ==1: ->knowsPlan} -> NotKnowsPlan

===knowsPlan===
You think about your friend's plan.
If so, now would be the opportunity to steal the ammunition.
Only one bullet would be needed for the plan.
What will you do?
+[Steal bullet]
-> Stehlen
+[Don't steal]
-> NichtStehlen

===Stehlen===
~Unity_Event("stealRound")
You slip a cartridge inconspicuously into your trouser pocket.
You look around you. Nobody suspects anything.
You start shooting at the cans as if nothing is wrong.
{Get_State("round") ==1: ->Win} -> Lose

===NichtStehlen===
You briefly think about taking them, but then you decide against it.
You start shooting the cans and focus on winning.
{Get_State("round") ==1: ->Win} -> Lose

===NotKnowsPlan===
{Get_State("round") ==1: ->Win} -> Lose

===Win===
You hit the most cans and won your category!
You have now received the price from ${Get_State("price")}!
->WayHome

===Lose===
You didn't hit enough cans. You lost in your category.
->WayHome

===WayHome===
You go home again after shooting.
On the way to your family, you start to think about your family, your work and your decisions.
{NichtStehlen: ->Snitch} ->end

===Snitch===
~Unity_Event("snitched")
You think of your friend.
You think about how he tried to talk you into this plan.
Maybe he's dangerous...
Maybe he needs to be stopped...
Maybe YOU have to stop him...
Maybe you need to report him to the sheriff.
Will you betray your friend?
+[Betray]
-> Verraten
+[Do Nothing]
-> Schweigen

===Verraten===
You decide to go to the sheriff on your way home.
You describe the events and your friend's criminal plan to him.
The sheriff immediately believes you and reassures you: "Don't worry, good man, I'll take care of it."
You leave the sheriff's office and wonder if that was the right thing to do...
->end

===Schweigen===
You decide not to say anything. Your friend may have this plan, but you don't see yourself as a traitor.
You wonder if that was the right thing to do...
->end

=== end ===
~Unity_Event("endDay")
-->END

