using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayStats : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI blocksMinedAmount;
    [SerializeField] private TextMeshProUGUI blocksPlacedAmount;
    [SerializeField] private TextMeshProUGUI timeSpendInMineAmount;
    [SerializeField] private TextMeshProUGUI moneyEarnedForCompanyAmount;
    [SerializeField] private TextMeshProUGUI scoreAmount;
    
    public void Display()
    {
        blocksMinedAmount.text = GameManager.instance.blocksMined.ToString();
        blocksPlacedAmount.text = GameManager.instance.blocksPlaced.ToString();
        timeSpendInMineAmount.text = GameManager.instance.timeInMine.ToString();
        moneyEarnedForCompanyAmount.text = GameManager.instance.earnedMoneyForCompany.ToString();
        GameManager.instance.GetComponent<ScoreCalculator>().DisplayEndScore();
        scoreAmount.text = GameManager.instance.GetComponent<ScoreCalculator>().Score.ToString();
    }
}
