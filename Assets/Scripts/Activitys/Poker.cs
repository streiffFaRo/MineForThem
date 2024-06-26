using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Poker : MonoBehaviour
{

    private GameState gamestate;

    private ActivityController activityController;

    private void Awake()
    {
        gamestate = GetComponent<GameState>();
        activityController = GetComponent<ActivityController>();
    }

    public void BetAmount(string betAmount)
    {
        gamestate.Clear("roundChange");
        int winorlose = Random.Range(0, 2);
        
        if (winorlose >= 1)
        {
            Debug.Log("Gewonnen");
            gamestate.Add("round", 1, true);
        }
        
        switch (betAmount)
        {
            case "25":
                float moneyLow = Random.Range(2, 25);
                gamestate.Add("roundChange", Mathf.RoundToInt(moneyLow), true);
                moneyLow = moneyLow / 100;
                if (winorlose >= 1)
                {
                    GameManager.instance.savings += moneyLow;
                }
                else
                {
                    GameManager.instance.savings -= moneyLow;
                }
                break;
            case "50":
                float moneyMid = Random.Range(5, 50);
                gamestate.Add("roundChange", Mathf.RoundToInt(moneyMid), true);
                moneyMid = moneyMid / 100;
                if (winorlose >= 1)
                {
                    GameManager.instance.savings += moneyMid;
                }
                else
                {
                    GameManager.instance.savings -= moneyMid;
                }
                break;
            case "100":
                float moneyHigh = Random.Range(10, 100);
                gamestate.Add("roundChange", Mathf.RoundToInt(moneyHigh), true);
                moneyHigh = moneyHigh / 100;
                if (winorlose >= 1)
                {
                    GameManager.instance.savings += moneyHigh;
                }
                else
                {
                    GameManager.instance.savings -= moneyHigh;
                }
                break;
            default:
                Debug.LogWarning("Default Case in Poker skript");
                break;
        }
    }

    public void ClearRound() //Aufgerufen über InkEvent, Möglicherweise unnötig -> Testen bevor löschen!
    {
        gamestate.Clear("round");
    }

    public void VisitedPoker() //Aufgerufen über InkEvent
    {
        GameManager.instance.visitedPoker = true;
    }
}
