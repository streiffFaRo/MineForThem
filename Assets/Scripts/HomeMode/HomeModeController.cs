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
    public float savings = 5f;
    public float goldEarned = 1111f;
    public float companyCut = 95f;
    public float rent = 4f;
    public float heat = 0.5f;
    public float food = 1.5f;
    public float money = 3f;
    public float total;
    
    [Header("TextMeshPro Amount Elements")]
    [SerializeField] private TextMeshProUGUI savingAmount;
    [SerializeField] private TextMeshProUGUI earnedAmount;
    [SerializeField] private TextMeshProUGUI cutAmount;
    [SerializeField] private TextMeshProUGUI rentAmount;
    [SerializeField] private TextMeshProUGUI heatAmount;
    [SerializeField] private TextMeshProUGUI foodAmount;
    [SerializeField] private TextMeshProUGUI totalAmount;
    [SerializeField] private TextMeshProUGUI familyHappinessAmount;
    [SerializeField] private TextMeshProUGUI currentDayUI;

    [Header("Checkboxen")]
    [SerializeField] Toggle heatToggle;
    [SerializeField] Toggle foodToggle;

    [Header("Continue Parts")] 
    [SerializeField] private string[] descriptionTexts;
    [SerializeField] private TextMeshProUGUI descriptionTextUI;
    [SerializeField] private Button goOutButton;
    [SerializeField] private Button stayHomeButton;

    [Header("Other")]
    public int oldFamilyHappiness;
    public Animator familyUIAnimationController;
    public PlayerInputScript playerInputScript;

    private void Awake()
    {
        playerInputScript = FindObjectOfType<PlayerInputScript>();
    }

    private void Start()
    {
        if (GameManager.instance.currentDay >= 1)
        {
            heat = 1f;
        }
        if (GameManager.instance.currentDay >= 2)
        {
            rent = 5f;
        }
        if (GameManager.instance.currentDay >= 3)
        {
            companyCut = 99f;
        }
        if (GameManager.instance.currentDay >= 4)
        {
            food = 2.5f;
        }

        oldFamilyHappiness = GameManager.instance.familyHappiness;
        
        SetSavings();
        goldEarned = 11 * GameManager.instance.goldMined;
        CalculateCompanyCut();
        CalculateRent();
        CalculateHeat();
        CalculateFood();
        setUpActivityText();

        SetAmounts();
        SetFamilyHappiness();

        currentDayUI.text = (GameManager.instance.currentDay + 1).ToString();
    }

    public void SetSavings()
    {
        savings = GameManager.instance.savings;
        Math.Round(savings, 2);
        money = savings;
        SetAmounts();
    }

    public void CalculateCompanyCut()
    {
        int cutMoneyFromEarnings = Mathf.RoundToInt(goldEarned / 100f * companyCut);
        money = money + goldEarned - cutMoneyFromEarnings;

        GameManager.instance.earnedMoneyForCompany += cutMoneyFromEarnings;
        GameManager.instance.earnedMoneyForSelf += Mathf.RoundToInt(goldEarned - cutMoneyFromEarnings);
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

    public void setUpActivityText()
    {
        int currentDay = GameManager.instance.currentDay;
        descriptionTextUI.text = descriptionTexts[currentDay];

        if (currentDay == 3 && !GameManager.instance.metFriend)
        {
            descriptionTextUI.text = "Heute Abend gibt es nichts zu tun. Deine Familie freut sich mit dir Zeit zu verbringen.";
            goOutButton.gameObject.SetActive(false);
        }

        if (currentDay == 4)
        {
            goOutButton.gameObject.SetActive(true);
        }
        
        if (currentDay >= 6 && GameManager.instance.snitched)
        {
            descriptionTextUI.text = "Der Sheriff erwartet mich auf dem Hauptplatz...";
            stayHomeButton.gameObject.SetActive(false);
        }
        else if (currentDay >= 6)
        {
            descriptionTextUI.text = "Heute Abend gibt es nichts zu tun. Deine Familie freut sich mit dir Zeit zu verbringen.";
            goOutButton.gameObject.SetActive(false);
        }
    }

    public void SetAmounts()
    {
        total = money;
        Math.Round(total, 2);
        
        savingAmount.SetText("$"+savings);
        earnedAmount.SetText("$"+goldEarned);
        cutAmount.SetText(companyCut+"%");
        rentAmount.SetText("$"+rent);
        heatAmount.SetText("$"+heat);
        foodAmount.SetText("$"+food);
        totalAmount.SetText("$"+total);
    }

    public void SetFamilyHappiness()
    {
        int happiness = GameManager.instance.familyHappiness;
        
        familyHappinessAmount.SetText(happiness.ToString());

        if (happiness >= 7)
        {
            familyHappinessAmount.color = new Color(255, 181, 0);
        }
        else if (happiness <= 3)
        {
            familyHappinessAmount.color = new Color(133, 0, 0);
        }
        else
        {
            familyHappinessAmount.color = new Color(255, 255, 255);
        }
    }

    public void StartEndHomeMode(int key)
    {
        StartCoroutine(EndHomeMode(key));
    }

    public IEnumerator EndHomeMode(int key)
    {
        if (total >= 0)
        {
            GameManager.instance.savings = total;
            foodToggle.enabled = false;
            heatToggle.enabled = false;
            goOutButton.enabled = false;
            stayHomeButton.enabled = false;
            playerInputScript.allowInput = false;
            CalcualteFamilyHappy();
            yield return new WaitForSeconds(0.5f);
            
            if (key == 0)
            {
                //Animation
                if (oldFamilyHappiness > GameManager.instance.familyHappiness)
                {
                    //Happiness -
                    familyUIAnimationController.SetTrigger("Family-");
                }
                else if (oldFamilyHappiness < GameManager.instance.familyHappiness)
                {
                    //Happiness +
                    familyUIAnimationController.SetTrigger("Family+");
                }
                
                yield return new WaitForSeconds(2.5f);
                playerInputScript.allowInput = true;
                CheckIfFamilyLeaves();
                SceneManager.LoadScene("Activity_Scene");
                
            }
            else if (key == 1)
            {
                if (GameManager.instance.currentDay >=6)
                {
                    GameManager.instance.GetComponent<EndingManager>().InitEnding(2);
                }
                
                if (GameManager.instance.familyHappiness <= 6)
                {
                    GameManager.instance.familyHappiness++;    //Increases Happiness because Player stayed with Family
                }
                
                //Animation
                if (oldFamilyHappiness > GameManager.instance.familyHappiness)
                {
                    //Happiness -
                    familyUIAnimationController.SetTrigger("Family-");
                }
                else if (oldFamilyHappiness < GameManager.instance.familyHappiness)
                {
                    //Happiness +
                    familyUIAnimationController.SetTrigger("Family+");
                }
                
                yield return new WaitForSeconds(2.5f);
                playerInputScript.allowInput = true;
                CheckIfFamilyLeaves();
                SceneManager.LoadScene("Lobby_Scene");
                GameManager.instance.UpdateCurrentDay(); //Updates Current Day
            }
            else
            {
                Debug.LogWarning("EndHomeMode-Key out of range");
            }
            
        }
        else
        {
            GameManager.instance.GetComponent<EndingManager>().InitEnding(4);
            Debug.Log("GameOver - kein Geld mehr");
        }
        
    }

    public void CalcualteFamilyHappy()
    {
        if (heatToggle.isOn && foodToggle.isOn)
        {
            
            if (GameManager.instance.familyHappiness <= 6)
            {
                GameManager.instance.familyHappiness += 1;
            }

            if (GameManager.instance.familyHappiness >= 7)
            {
                GameManager.instance.familyHappiness = 7;
            }
            
        }
        else if (!heatToggle.isOn && !foodToggle.isOn)
        {
            GameManager.instance.familyHappiness -= 2;
        }
        else if (heatToggle.isOn || foodToggle.isOn)
        {
            GameManager.instance.familyHappiness -= 1;
        }
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
        }
        else if (GameManager.instance.familyHappiness <= 3)
        {
            if (leaveProbability >= 95)
            {
                FamilyLeaves();
            }
        }
        
        Debug.Log(GameManager.instance.familyHappiness);
    }

    public void FamilyLeaves()
    {
        GameManager.instance.GetComponent<EndingManager>().InitEnding(3);
        Debug.Log("Family left");
    }

}
