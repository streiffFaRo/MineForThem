using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("ActiveGameValues")]
    public int goldMined = 0;
    public int blocksInInv = 0;
    [Range(0,10)]
    public int familyHappiness = 4;
    public float pickaxeStrength = 1;
    public float currentDay = 0;
    public float savings = 4;
    

    [Header("GameStats")]
    public int blocksMined = 0;
    public int blocksPlaced = 0;
    public float timeInMine = 0; //TODO Wenn Timesystem gemacht
    public float earnedMoneyForCompany = 0;
    public int deathsUnlocked = 0; //TODO Wenn Savesystem gemacht

    [Header("Score")]
    public int earnedMoneyForSelf = 0;
    public int scoreFromEnding = 0;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    public void UpdateCurrentDay()
    {
        if (currentDay != 7)
        {
            currentDay++;
        }
        else
        {
            Debug.Log("Game End: Survived");
            //TODO Init GameEnding
        }
    }

    public void ClearGoldMined()
    {
        goldMined = 0;
    }

    public void ClearBlocksInInv()
    {
        blocksInInv = 0;
    }

    public void UpdateGoldCount()
    {
        goldMined++;
    }

    public void UpdateBlocksInInv(bool add)
    {
        if (add)
        {
            blocksInInv++;
        }
        else
        {
            blocksInInv--;
        }
    }

    public void SetUpNewGame()
    {
        //ResetCore
        goldMined = 0;
        blocksInInv = 0;
        familyHappiness = 4;
        pickaxeStrength = 1;
        currentDay = 0;
        
        //Reset Stats
        blocksMined = 0;
        blocksPlaced = 0;
        timeInMine = 0;
        earnedMoneyForCompany = 0;
        deathsUnlocked = 0;
    }

}
