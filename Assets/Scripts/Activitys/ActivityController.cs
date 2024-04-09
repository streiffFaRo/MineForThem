using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivityController : MonoBehaviour
{

    [Header("GameObjects")]
    public FadingPanel fadingPanel;
    
    [Header("Text Positions")]
    [SerializeField] private TextMeshProUGUI textBox;

    [Header("Ink Files")] 
    private Story currentStory;
    private bool dialogueIsPlaying;
    [SerializeField] private TextAsset inkDay0;
    [SerializeField] private TextAsset inkDay1;
    [SerializeField] private TextAsset inkDay2;
    [SerializeField] private TextAsset inkDay3;
    [SerializeField] private TextAsset inkDay4;
    [SerializeField] private TextAsset inkDay5;

    [Header("Choices UI")] 
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    public static event Action<string> InkEvent;

    private bool canMakeChoice;
    
    private GameState gameState;

    //Activity Scritps
    private Poker poker;
    private Saloon saloon;

    private void Awake()
    {
        poker = GetComponent<Poker>();
        saloon = GetComponent<Saloon>();
        gameState = GetComponent<GameState>();

    }

    private void Start()
    {
        LoadCurrentDayInkFile();

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
        BindExternalFunctions();
        
        ContinueStory();
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
        
        //Tag 3:
        
        //Tag 4:
        
        //Tag 5:
        
    }

    private void OnDisable()
    {
        currentStory.UnbindExternalFunction("poker");
        currentStory.UnbindExternalFunction("ordoredDrink");
        currentStory.UnbindExternalFunction("saloon");
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

    }

    public void MakeChoice(int choiceIndex)
    {
        //TODO Fix -> (Selektiere Chioces werden automatisch ausgeführt)
        if (canMakeChoice)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
            canMakeChoice = false;
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
    
    public void EndDay() //Aufgrufen über InkEvent
    {
        StartCoroutine(EndDayCorutine());
    }
    public IEnumerator EndDayCorutine()
    {
        fadingPanel.FadeIn(0.8f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Mine_Scene");
    }
}
