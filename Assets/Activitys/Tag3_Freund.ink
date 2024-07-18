INCLUDE Utility.ink


-> main
=== main === 
You accept your friend's invitation.
On the way to his house, you wonder what he's all about.
Your friend is very happy to see you. He greets you warmly and offers you a glass of water to drink.
Davy: "How are you holding up, now that you know what work is like?" #Davy
+[Decent]
-> Passabel
+[Bad]
-> Schlecht
+[Horrible]
-> Schrecklich

===Passabel===
You: "Well, it's okay, I'm dependent on this work. I will do anything for my family" #Jack
->AnsichtFreund

===Schlecht===
You: "I'm not doing well. The work is exhausting and the pay is bad, but I'm doing it for my family." #Jack
->AnsichtFreund

===Schrecklich===
You: "I feel terrible. I can't take any more. If only there was enough money. But I have to do this for my family." #Jack
->AnsichtFreund

===AnsichtFreund===
Davy: "I can understand that you're doing this for your family. I've been working at the mine for three months now and you can imagine how the work has affected me." #Davy
Davy: "What would you think if I told you that I might have a way of getting the money and getting back at the foreman?" #Davy
+[Interested]
-> Interesse
+[Not Interested]
-> NichtInteresse
+[Say Nothing]
-> Schweigen

===Interesse===
You: "That sounds good, but how is that supposed to work?" #Jack
Davy: "As you have noticed, the foreman likes to keep his money on display next to him." #Davy
->Plan
===NichtInteresse===
You: "That sounds too risky. I'd rather work in the mine than take part in such dodgy activities." #Jack
Davy: "Listen to me first, it won't be as dangerous for you as it is for me." #Davy
Davy: "As you have noticed, the foreman likes to keep his money on display next to him." #Davy
->Plan

===Schweigen===
You: "..."
Davy: "Listen to me first, it won't be as dangerous for you as it is for me." #Davy
Davy: "As you have noticed, the foreman likes to keep his money on display next to him." #Davy
->Plan

===Plan===
~Unity_Event("plan")
Davy: "The foreman already knows that I'm planning something against him. I sometimes have the feeling that I'm being monitored by people from the mining company." #Davy
Davy: "There's a shooting competition in the village in two days' time. If you take part, just put a bullet in your pocket." #Davy
Davy: "Give it to me the next morning and I'll do the rest." #Davy
Davy: "With the foreman gone, I can plunder his stash. I'll give you your fair share after we've left the scene." #Davy
Davy: "You don't need to be afraid, they'll come looking for me and I can live with that. All you have to do is hide your share for a few weeks and you can lead a good life. Away from the mine." #Davy
Davy: "What do you say? Will you help me?" #Davy
+[Agree]
-> Helfen
+[Refuse]
-> NichtHelfen
+[Say Nothing]
-> Schweigen2

===Helfen===
You: "Alright, I'll get you the ammunition." #Jack
Davy: "Wonderful. I knew you were the right person for it." #Davy
-> end

===NichtHelfen===
You: "No, I can't take responsibility for that." #Jack
Davy: "What a pity. I was hoping you would help me. I'm asking you to reconsider. I really need the bullet." #Davy
-> end

===Schweigen2===
You: "..."
Davy: "I'm asking you to reconsider. I really need the bullet." #Davy
-> end

=== end ===
After you have finished your drinks and are getting ready to leave, he accompanies you to the door.
Davy: "Thank you for your visit. I believe that you will do the right thing." #Davy
Now you know that a difficult decision awaits you in two days time.
Do you steal the ammunition to help Davy get rid of the foreman and split the money...
Or will you stay on the right path and continue to work in the mine under miserable conditions?
~Unity_Event("endDay")
-->END

