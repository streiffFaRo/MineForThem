using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Poker : MonoBehaviour
{

    private GameState gamestate;
    
    private void Awake()
    {
        gamestate = GetComponent<GameState>();
    }

    public void BetAmount(string betAmount)
    {
        Debug.Log("Du hast den " + betAmount + " Amount gesetzt!");
        gamestate.Add("round1", 0, true);
    }
}
