INCLUDE Utility.ink


-> main
=== main === 
You accept your friend's invitation.
On the way to his house, you wonder what he's all about.
Your friend is very happy to see you. He greets you warmly and offers you a glass of water to drink.
Davy: "What about you now that you know what the work is like?"
+[Passabel]
-> Passabel
+[Schlecht]
-> Schlecht
+[Schrecklich]
-> Schrecklich

===Passabel===
You: "Well, it's okay, I'm dependent on this work. I do it for my family"
->AnsichtFreund

===Schlecht===
You: "I'm not doing well. The work is exhausting and the pay is bad, but I'm doing it for my family."
->AnsichtFreund

===Schrecklich===
You: "I feel terrible. I can't take any more. If only there was enough money. But I have to do this for my family."
->AnsichtFreund

===AnsichtFreund===
Davy: "I can understand that you're doing this for your family. I've been working at the mine for three months now and you can imagine how the work has affected me."
Davy: "What would you think if I told you that I might have a way of getting the money and getting back at the foreman?"
+[Interested]
-> Interesse
+[Not Interested]
-> NichtInteresse
+[Say Nothing]
-> Schweigen

===Interesse===
You: "That sounds good, but how is that supposed to work?"
Davy: "I've noticed that the foreman always keeps the weeks's takings in his office."
->Plan
===NichtInteresse===
You: "That doesn't sound good. I'd rather work in the mine than take part in such dodgy activities."
Davy: "Listen to me first, it won't be as dangerous for you as it is for me."
Davy: "I've noticed that the foreman always keeps the weeks's takings in his office."
->Plan

===Schweigen===
You: "..."
Davy: "Listen to me first, it won't be as dangerous for you as it is for me."
Davy: "I've noticed that the foreman always keeps the weeks's takings in his office."
->Plan

===Plan===
~Unity_Event("plan")
Davy: "The foreman already knows that I'm planning something against him. I sometimes have the feeling that I'm being monitored by people from the mining company."
Davy: "There's a shooting competition in the village in two days' time. If you take part, just put a bullet in your pocket."
Davy: "Give it to me the next morning and I'll do the rest."
Davy: "With the foreman's key, I can plunder his office. I'll give you your fair share."
Davy: "You don't need to be afraid, they'll come looking for me and I can live with that. All you have to do is hide your share and you can lead a good life. Away from the mine."
Davy: "What do you say? Will you help me?"
+[Agree]
-> Helfen
+[Refuse]
-> NichtHelfen
+[Say Nothing]
-> Schweigen2

===Helfen===
You: "Good, I'll get you the ammunition."
Davy: "Wonderful. I knew you were the right person for it."
-> end

===NichtHelfen===
You: "No, I can't take responsibility for that."
Davy: "What a pity. I was hoping you would help me. I'm asking you to reconsider. I need this ammunition."
-> end

===Schweigen2===
You: "..."
Davy: "I'm asking you to reconsider. I need this ammunition."
-> end

=== end ===
After you have finished your drinks and are getting ready to leave, he accompanies you to the door.
Davy: "Thank you for your visit. I believe that you will do the right thing."
Now you know that a difficult decision awaits you in two days time.
Do you steal the ammunition to help Davy get rid of the foreman and split the money...
Or will you stay on the right path and continue to work in the mine under miserable conditions?
~Unity_Event("endDay")
-->END

