using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kirche : MonoBehaviour
{


    private GameState gamestate;

    private void Awake()
    {
        gamestate = GetComponent<GameState>();
    }
    
    public void Spenden(string amount)
    {

        if (amount.Equals("10"))
        {
            GameManager.instance.savings -= 0.1f;
        }
        else if (amount.Equals("50"))
        {
            GameManager.instance.savings -= 0.5f;
        }
        gamestate.Add("segen", 1, true);
    }

    public void HappyFam() //Aufgerufen über InkEvent
    {
        GameManager.instance.familyHappiness++;
    }

    public void UnHappyFam() //Aufgerufen über InkEvent
    {
        GameManager.instance.familyHappiness--;
    }

    public void Segen() //Aufgerufen über InkEvent
    {
        Debug.Log("HALLLOOOO");
        GameManager.instance.pickaxeStrength = 15;
        //TODO -> Heiligenschein für Player
    }
}
