using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saloon : MonoBehaviour
{
    private GameState gamestate;

    private float winprob;
    
    private void Awake()
    {
        gamestate = GetComponent<GameState>();
        winprob = 50f;
    }

    public void OrdoredDrink(string drink)
    {
        switch (drink)
        {
            case "Wasser":
                winprob += 20f;
                break;
            case "Bier":
                winprob -= 10f;
                break;
            case "Whiskey":
                winprob -= 30f;
                break;
            default:
                break;
        }
    }

    public void SaloonComp(string amount)
    {
        gamestate.Clear("roundChange");
        float winNumb = Random.Range(0, 100);
        int betAmount = 1;
        
        if (amount.Equals("3"))
        {
            betAmount = 3;
        }
        else
        {
            Debug.LogWarning("Saloon Competition Input ist ungültig!");
            
        }

        if (winNumb <= winprob)
        {
            Debug.Log("Gewonnen - WinNumb: "+winNumb+" WinProb "+winprob);
            gamestate.Add("round", 1, true);
            GameManager.instance.savings += betAmount;
        }
        else
        {
            Debug.Log("Verloren - WinNumb: "+winNumb+" WinProb "+winprob);
            GameManager.instance.savings -= betAmount;
        }

        Debug.Log(betAmount);
    }
    
    
    public void CheckVisit() //Aufgerufen über InkEvent
    {
        if (GameManager.instance.visitedPoker)
        {
            gamestate.Add("visited", 1, true);
        }
    }
    
}
