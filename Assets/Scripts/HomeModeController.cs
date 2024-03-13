using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("Checkboxen")]
    [SerializeField] Toggle heatToggle;
    [SerializeField] Toggle foodToggle;
    [SerializeField] Toggle specialToggle;

    [Header("Anderes")]
    [SerializeField] private GameObject specialGameObject;
    public bool hasSpecialExpenses;


    private void Start()
    {
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

    public void CalculateCompanyCut()
    {
        float cutMoneyFromEarnings;
        cutMoneyFromEarnings = goldEarned / 100f * companyCut;
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
    }
}
