using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("ActiveGameValues")]
    public int goldMined = 0;
    public int blocksInInv = 0;
    [Range(0,10)]
    public int familyHappiness = 4;
    public int pickaxeStrength = 10;
    public int currentDay = 0;
    public float savings = 4;

    [Header("Activity")] 
    public bool visitedPoker;
    public bool metFriend;
    public bool knowsPlan;
    public bool hasBullet;
    public bool snitched;

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
        if (currentDay != 6)
        {
            currentDay++;
        }
        else
        {
            GetComponent<EndingManager>().InitEnding(2);
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
        familyHappiness = 5;
        pickaxeStrength = 10;
        currentDay = 0;
        savings = 3;
        visitedPoker = false;
        metFriend = false;
        knowsPlan = false;
        hasBullet = false;
        snitched = false;
        
        //Reset Stats
        blocksMined = 0;
        blocksPlaced = 0;
        timeInMine = 0;
        earnedMoneyForCompany = 0;
        deathsUnlocked = 0;
        earnedMoneyForSelf = 0;
        scoreFromEnding = 0;
    }

}
