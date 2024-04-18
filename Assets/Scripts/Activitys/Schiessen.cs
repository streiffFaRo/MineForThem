using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schiessen : MonoBehaviour
{
    
    private GameState gamestate;

    private ActivityController activityController;

    private int winProb = 50;
    private int category = 1;
    
    private void Awake()
    {
        gamestate = GetComponent<GameState>();
        activityController = GetComponent<ActivityController>();
    }

    public void Wettkampf(string kategorie)
    {

        switch (kategorie)
        {
            case "1":
                winProb = 75;
                category = 2;
                GameManager.instance.savings -= 0.5f;
                break;
            case "2":
                winProb = 55;
                category = 5;
                GameManager.instance.savings -= 2f;
                break;
            case "3":
                winProb = 30;
                category = 10;
                GameManager.instance.savings -= 5f;
                break;
            default:
                break;
        }
        activityController.moneyUI.text = GameManager.instance.savings.ToString();
        CheckWin();
    }

    public void StealRound() //Aufgerufen über InkEvent
    {
        winProb -= 25;
        GameManager.instance.hasBullet = true;
    }

    public void CheckWin()
    {

        int winNumb = Random.Range(1, 101);
        
        if (winNumb <= winProb)
        {
            Debug.Log("Gewonnen - WinNumb: "+winNumb+" WinProb "+winProb);
            gamestate.Add("round", 1, true);
            gamestate.Add("price", category, true);
            GameManager.instance.savings += category;
            activityController.moneyUI.text = GameManager.instance.savings.ToString();
        }
        
        
    }


    public void CheckPlan() //Aufgerufen über InkEvent
    {
        if (GameManager.instance.knowsPlan)
        {
            gamestate.Add("knowsPlan", 1, true);
        }
    }

    public void Snitched()
    {
        GameManager.instance.snitched = true;
    }

}
