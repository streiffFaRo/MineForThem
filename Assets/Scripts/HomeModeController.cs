using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class HomeModeController : MonoBehaviour
{
    [Header("ManagePay")]
    public float savings = 4f;
    public float goldEarned = 1111f;
    public float companyCut = 90f;
    public float rent = 4f;
    public float heat = 0.5f;
    public float food = 1.5f;
    public float special = 2f;
    public string specialOccasion = "Hochzeit";
    public float money = 3f;
    public float total;

    [Header("TextMeshPro Amount Elements")]
    [SerializeField] private TextMeshProUGUI savingAmount;
    [SerializeField] private TextMeshProUGUI earnedAmount;
    [SerializeField] private TextMeshProUGUI cutAmount;
    [SerializeField] private TextMeshProUGUI rentAmount;
    [SerializeField] private TextMeshProUGUI heatAmount;
    [SerializeField] private TextMeshProUGUI foodAmount;
    [SerializeField] private TextMeshProUGUI specialAmount;
    [SerializeField] private TextMeshProUGUI specialOccasionText;
    [SerializeField] private TextMeshProUGUI totalAmount;
    [SerializeField] private TextMeshProUGUI familyHappinessAmount;

    [Header("Checkboxen")]
    [SerializeField] Toggle heatToggle;
    [SerializeField] Toggle foodToggle;
    [SerializeField] Toggle specialToggle;

    [Header("Anderes")]
    [SerializeField] private GameObject specialGameObject;
    public bool hasSpecialExpenses;
    

    private void Start()
    {
        SetSavings();
        goldEarned = 20 * GameManager.instance.goldMined;
        CalculateCompanyCut();
        CalculateRent();
        CalculateHeat();
        CalculateFood();

        if (hasSpecialExpenses)
        {
            specialGameObject.SetActive(true);
            CalculateSpecial();
        }

        SetAmounts();
    }

    public void SetSavings()
    {
        savings = GameManager.instance.savings;
        money = savings;
        SetAmounts();
    }

    public void CalculateCompanyCut()
    {
        int cutMoneyFromEarnings = Mathf.RoundToInt(goldEarned / 100f * companyCut);
        money = money + goldEarned - cutMoneyFromEarnings;
    }

    public void CalculateRent()
    {
        money = money - rent;
    }

    public void CalculateHeat()
    {
        if (heatToggle.isOn)
        {
            money = money - heat;
        }
        else
        {
            money = money + heat;
        }

        SetAmounts();
    }

    public void CalculateFood()
    {
        if (foodToggle.isOn)
        {
            money = money - food;
        }
        else
        {
            money = money + food;
        }
        SetAmounts();
    }

    public void CalculateSpecial()
    {
        if (specialToggle.isOn)
        {
            money = money - special;
        }
        else
        {
            money = money + special;
        }
        SetAmounts();
    }

    public void SetAmounts()
    {
        total = money;
        
        savingAmount.SetText("$"+savings);
        earnedAmount.SetText("$"+goldEarned);
        cutAmount.SetText(companyCut+"%");
        rentAmount.SetText("$"+rent);
        heatAmount.SetText("$"+heat);
        foodAmount.SetText("$"+food);
        specialAmount.SetText("$"+special);
        specialOccasionText.SetText(specialOccasion);
        totalAmount.SetText("$"+total);
        familyHappinessAmount.SetText(GameManager.instance.familyHappiness.ToString());
    }

    public void EndHomeMode()
    {
        if (total >= 0)
        {
            GameManager.instance.savings = total;
            Debug.Log(GameManager.instance.savings);
            CalcualteFamilyHappy();
            SceneManager.LoadScene("SandboxScene");
        }
        else
        {
            Debug.Log("GameOver - kein Geld mehr");
        }
    }

    public void CalcualteFamilyHappy()
    {
        if (heatToggle.isOn && foodToggle.isOn)
        {
            int increaseHappinessAmount = Random.Range(1, 3);
            GameManager.instance.familyHappiness += increaseHappinessAmount;
        }
        else if (heatToggle.isOn || foodToggle.isOn)
        {
            GameManager.instance.familyHappiness -= 1;
        }
        else if (!heatToggle.isOn && !foodToggle.isOn)
        {
            GameManager.instance.familyHappiness -= 2;
        }
        
        
        
        CheckIfFamilyLeaves();
    }

    public void CheckIfFamilyLeaves()
    {
        int leaveProbability = Random.Range(1, 101);
        
        if (GameManager.instance.familyHappiness <= 1)
        {
            FamilyLeaves();
        }
        else if (GameManager.instance.familyHappiness <= 2)
        {
            if (leaveProbability >= 75)
            {
                FamilyLeaves();
            }
            else
            {
                Debug.Log("Family might leave");
                //TODO Info pop up: "Family might leave"
            }
        }
        else if (GameManager.instance.familyHappiness <= 3)
        {
            if (leaveProbability >= 95)
            {
                FamilyLeaves();
            }
            else
            {
                Debug.Log("Family might leave");
                //TODO Info pop up: "Family might leave"
            }
        }
        
        Debug.Log(GameManager.instance.familyHappiness);
    }

    public void FamilyLeaves()
    {
        Debug.Log("Family left");
    }

}
