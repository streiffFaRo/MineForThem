using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

public class ActivityController : MonoBehaviour
{

    [Header("GameObjects")]
    public FadingPanel fadingPanel;
    
    [Header("Text Positions")]
    [SerializeField] private TextMeshProUGUI textBox;

    [Header("Money")]
    public TextMeshProUGUI moneyUI;

    [Header("Ink Files")] 
    private Story currentStory;
    private bool dialogueIsPlaying;
    [SerializeField] private TextAsset inkDay0;
    [SerializeField] private TextAsset inkDay1;
    [SerializeField] private TextAsset inkDay2;
    [SerializeField] private TextAsset inkDay3;
    [SerializeField] private TextAsset inkDay4;
    [SerializeField] private TextAsset inkDay5;
    [SerializeField] private TextAsset inkDay5Snitched;

    [Header("Choices UI")] 
    [SerializeField] private GameObject continueButton;
    [SerializeField] private FirstSelected firstSelected;
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    public static event Action<string> InkEvent;

    private bool canMakeChoice;
    
    private GameState gameState;

    //Activity Scritps
    private Poker poker;
    private Saloon saloon;
    private Kirche kirche;
    private Angeln angeln;
    private Schiessen schiessen;

    private void Awake()
    {
        poker = GetComponent<Poker>();
        saloon = GetComponent<Saloon>();
        kirche = GetComponent<Kirche>();
        gameState = GetComponent<GameState>();
        angeln = GetComponent<Angeln>();
        schiessen = GetComponent<Schiessen>();

    }

    private void Start()
    {
        LoadCurrentDayInkFile();

        moneyUI.text = GameManager.instance.savings.ToString();
        
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
        BindExternalFunctions();
        
        ContinueStory();

        continueButton.GetComponent<Button>().Select();
    }

    #region ExternalInkFunctions

    private void BindExternalFunctions()
    {
        currentStory.BindExternalFunction<string>("Unity_Event", Unity_Event);
        currentStory.BindExternalFunction<string>("Get_State", Get_State, true);
        currentStory.BindExternalFunction<string, int>("Add_State", Add_State);

        //Tag 0:
        currentStory.BindExternalFunction("poker", (string betAmount) =>
        {
            poker.BetAmount(betAmount);
        });
        
        //Tag 1:
        currentStory.BindExternalFunction("ordoredDrink", (string drink) =>
        {
            saloon.OrdoredDrink(drink);
        });
        
        currentStory.BindExternalFunction("saloon", (string amount) =>
        {
            saloon.SaloonComp(amount);
        });
        
        //Tag 2:
        currentStory.BindExternalFunction("spenden", (string amount) =>
        {
            kirche.Spenden(amount);
        });
                
        //Tag 3:
        
        //Tag 4:
        currentStory.BindExternalFunction("platz", (string amount) =>
        {
            angeln.Platz(amount);
        });
        
        currentStory.BindExternalFunction("bait", (string amount) =>
        {
            angeln.Bait(amount);
        });
        
        //Tag 5:
        currentStory.BindExternalFunction("category", (string amount) =>
        {
            schiessen.Wettkampf(amount);
        });
        
        
    }

    private void OnDisable()
    {
        currentStory.UnbindExternalFunction("poker");
        currentStory.UnbindExternalFunction("ordoredDrink");
        currentStory.UnbindExternalFunction("saloon");
        currentStory.UnbindExternalFunction("spenden");
        currentStory.UnbindExternalFunction("platz");
        currentStory.UnbindExternalFunction("bait");
        currentStory.UnbindExternalFunction("Unity_Event");
        currentStory.UnbindExternalFunction("Get_State");
        currentStory.UnbindExternalFunction("Add_State");
    }

    #endregion

    public void LoadCurrentDayInkFile()
    {
        switch (GameManager.instance.currentDay)
        {
            case 0:
                currentStory = new Story(inkDay0.text);
                break;
            case 1:
                currentStory = new Story(inkDay1.text);
                break;
            case 2:
                currentStory = new Story(inkDay2.text);
                break;
            case 3:
                currentStory = new Story(inkDay3.text);
                break;
            case 4:
                currentStory = new Story(inkDay4.text);
                break;
            case 5:
                currentStory = new Story(inkDay5.text);
                break;
            case 6:
                if (GameManager.instance.snitched)
                {
                    currentStory = new Story(inkDay5Snitched.text);
                }
                else
                {
                    currentStory = new Story(inkDay5Snitched.text);
                    Debug.Log("Error: Playing Day 6 without snitched!");
                }
                break;
            default:
                Debug.Log("Error:Current Day");
                break;
            
        }
        
    }

    public void ContinueStory()
    {

        if (currentStory.canContinue)
        {
            textBox.text = currentStory.Continue();
            DisplayChoices();
            
            if (currentStory.currentTags.Contains("Davy"))
            {
                VolumeManager.instance.GetComponent<AudioManager>().PlayDavyTalk();
            }
            if (currentStory.currentTags.Contains("Jack"))
            {
                VolumeManager.instance.GetComponent<AudioManager>().PlayJackTalk();
            }
            if (currentStory.currentTags.Contains("Sheriff"))
            {
                VolumeManager.instance.GetComponent<AudioManager>().PlaySheriffTalk();
            }
            
        }
        else
        {
            Debug.Log("No Dialogue to Display");
            canMakeChoice = true;
        }
    }

    
    #region Choices

    public void DisplayChoices()
    {
        List<Choice> currenChoices = currentStory.currentChoices;

        if (currenChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support");
        }
        
        
        int index = 0;
        foreach (Choice choice in currenChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
        
        if (index >= 2)
        {
            continueButton.SetActive(false);
        }
        else
        {
            continueButton.SetActive(true);
        }

    }

    public void MakeChoice(int choiceIndex)
    {
        
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
        canMakeChoice = false;
        
        if (canMakeChoice)
        {
            
        }
    }

    #endregion
    
    // Functions aus 2. Sem
    private void Unity_Event(string eventName)
    {
        InkEvent?.Invoke(eventName);
    }
    
    private object Get_State(String id)
    {
        State state = gameState.Get(id);
        return state != null ? state.amount : 0;
    }

    private void Add_State(string id, int amount)
    {
        gameState.Add(id, amount);
    }
    //

    public void MetFriend() //Aufgerufen über InkEvent
    {
        GameManager.instance.metFriend = true;
    }

    public void Plan() //Aufgerufen über InkEvent
    {
        GameManager.instance.knowsPlan = true;
    }

    public void UpdateMoneyUI() //Aufgerufen über InkEvent
    {
        moneyUI.text = GameManager.instance.savings.ToString();
    }

    public void EndDay() //Aufgrufen über InkEvent
    {
        StartCoroutine(EndDayCorutine());
    }
    

    public IEnumerator EndDayCorutine()
    {
        fadingPanel.FadeIn(0.8f);
        yield return new WaitForSeconds(1f);
        if (GameManager.instance.savings >= 0)
        {
            SceneManager.LoadScene("Lobby_Scene");
            GameManager.instance.UpdateCurrentDay();
        }
        else
        {
            GameManager.instance.GetComponent<EndingManager>().InitEnding(4);
        }
        
    }
    
    public void InitSnitchedEnding() //Aufgrufen über InkEvent
    {
        StartCoroutine(SnitchedEnding());
    }

    public IEnumerator SnitchedEnding()
    {
        fadingPanel.FadeIn(0.8f);
        yield return new WaitForSeconds(1f);
        GameManager.instance.GetComponent<EndingManager>().InitEnding(1);
    }
    
    public void InitEscapedEnding() //Aufgrufen über InkEvent
    {
        StartCoroutine(EscapedEnding());
    }

    public IEnumerator EscapedEnding()
    {
        fadingPanel.FadeIn(0.8f);
        yield return new WaitForSeconds(1f);
        GameManager.instance.GetComponent<EndingManager>().InitEnding(6);
    }
}
