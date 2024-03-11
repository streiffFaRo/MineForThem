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

    private bool hasSpecialExpenses;


    private void Start()
    {
        CalculateCompanyCut();
        //
        //
        //
        //TODO SpecialExpensesCheck
        SetAmounts();
    }

    public void CalculateCompanyCut()
    {
        float cutMoneyFromEarnings;
        cutMoneyFromEarnings = goldEarned / 100f * companyCut;
        money = money + goldEarned - cutMoneyFromEarnings;
        total = money;
    }

    public void SetAmounts()
    {
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
