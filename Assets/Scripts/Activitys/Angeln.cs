using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angeln : MonoBehaviour
{
    private GameState gamestate;

    private ActivityController activityController;

    private int priceCategory;

    private int catchRate;
    
    private void Awake()
    {
        gamestate = GetComponent<GameState>();
        activityController = GetComponent<ActivityController>();
    }


    public void Platz(string ort)
    {

        
        switch (ort)
        {
            case "1":
                priceCategory = 1;
                catchRate = 70;
                break;
            case "2":
                priceCategory = 6;
                catchRate = 50;
                break;
            case "3":
                priceCategory = 11;
                catchRate = 30;
                break;
            default:
                break;
        }
    }


    public void Bait(string bait)
    {
        switch (bait)
        {
            case "1":
                catchRate += 5;
                GameManager.instance.savings -= 0.3f;
                break;
            case "2":
                catchRate += 12;
                GameManager.instance.savings -= 1;
                break;
            case "3":
                catchRate += 25;
                GameManager.instance.savings -= 4;
                break;
            default:
                break;
        }
    }


    public void Catch() //Aufgerufen über InkEvent
    {
        int catchChance = Random.Range(1, 101);
        
        if (catchChance <= catchRate)
        {
            Debug.Log("Gewonnen CatchChance: "+catchChance+" ChatchRate: "+catchRate);
            gamestate.Add("round", 1, true);
            
            int randomPrice = Random.Range(5, 41);
            int price;
            
            price = randomPrice * priceCategory;
            
            gamestate.Add("price", price, true);

            price = price / 100;

            GameManager.instance.savings += price;
            activityController.moneyUI.text = GameManager.instance.savings.ToString();

        }
        else
        {
            Debug.Log("Verloren CatchChance: "+catchChance+" ChatchRate: "+catchRate);
        }
    }
}
