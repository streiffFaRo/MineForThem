INCLUDE Utility.ink
EXTERNAL platz(ort)
EXTERNAL bait(bait)

-> main
=== main === 
You decide to go on a little fishing trip today to relax.
With a good catch, you can also earn some money for the family.
The first thing you need to do is decide on a fishing spot.
The place in the south has a lot of small fish, you can certainly catch something there, but is it worth it?
In the north-east next to the railway station there is a pond with very large fish, the only question is whether one will bite.
Otherwise there is another pond in the west that is quite balanced.
Where would you like to go fishing?
+[South]
-> Sueden
+[North-east]
-> Nordosten
+[West]
-> Westen

===Sueden===
~ platz("1")
You have decided in favour of the more populated south.
->Koeder

===Nordosten===
~ platz("3")
You have chosen the pond with the big fish in the north-east.
->Koeder

===Westen===
~ platz("2")
You make your way west to fish there.
->Koeder

===Koeder===
Now it is important to choose the right bait.
Cheese is a very simple and cheap bait.
Crickets are a solid bait that can also attract large fish.
An artificial bait is basically a safe choice. But they come at a price.
Which bait do you choose?
+[Cheese 30c]
-> Kaese
+[Crickets $1]
-> Grillen
+[Artificial bait $4]
-> Kunstkoeder

===Kaese===
~ bait("1")
You have opted for the cheap cheese.
->Durchgang1

===Grillen===
~ bait("2")
You have decided in favour of the crickets.
->Durchgang1

===Kunstkoeder===
~ bait("3")
You have opted for the expensive artificial bait.
->Durchgang1

===Durchgang1===
~Unity_Event("clearRound")
~Unity_Event("catch")
You start to attach your lure to the fishing hook and lean back a little.
.
..
...
Something has bitten!
You quickly try to reel in the fish. You crank the fishing line...
{Get_State("round") ==1: ->Win1} -> Lose1

===Win1===
And that's him! You managed to bring him ashore.
You estimate its price at {Get_State("price")}c.
->Durchgang2

===Lose1===
The fish was able to detach itself from the hook.
He has escaped!
->Durchgang2

===Durchgang2===
~Unity_Event("clearRound")
~Unity_Event("catch")
You put the next lure on the hook and wait for the next sign that a fish is biting.
.
..
...
A fish is on the hook!
You start to reel in the fishing line.
{Get_State("round") ==1: ->Win2} -> Lose2

===Win2===
You've made it! A good catch.
You estimate its price at {Get_State("price")}c.
->Durchgang3


===Lose2===
But when the line is out of the water, you realise that only an old boot has got caught on the hook.
The bait fell off.
->Durchgang3

===Durchgang3===
~Unity_Event("clearRound")
~Unity_Event("catch")
You want to make one last attempt. You take the last lure and put it on.
.
..
...
It wriggles!
You start turning the crank.
{Get_State("round") ==1: ->Win3} -> Lose3

===Win3===
You manage to land the fish successfully!
You estimate its price at {Get_State("price")}c.
-> end

===Lose3===
The fish locks up and pulls on the fishing line.
You try to hold out against it.
While trying to retrieve the fish, the line broke.
The fish has escaped!
-> end


=== end ===
You start to pack up your equipment and make your way home.
~Unity_Event("endDay")
-->END




