using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{

    private int Score;

    private void Start()
    {
        Score = 0;
    }

    public void DisplayEndScore()
    {
        CalculateEarnedMoney();
        CalculateSavings();
        CalculateFamilyHappieness();
        CalculateEndingBonus(GameManager.instance.scoreFromEnding);
        Debug.Log(Score);
    }

    private void CalculateEarnedMoney()
    {
        float earnedMoneyScore = GameManager.instance.earnedMoneyForSelf * 4;
        Score += Mathf.RoundToInt(earnedMoneyScore);
    }

    private void CalculateSavings()
    {
        float savingsScore = GameManager.instance.savings * 10;
        Score += Mathf.RoundToInt(savingsScore);
    }

    private void CalculateFamilyHappieness()
    {
        int familyScore = GameManager.instance.familyHappiness * 100;
        Score += familyScore;
    }

    private void CalculateEndingBonus(int bonus)
    {
        Score += bonus;
    }


}
