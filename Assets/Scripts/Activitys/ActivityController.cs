using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;

public class ActivityController : MonoBehaviour
{

    [Header("Text Positions")]
    [SerializeField] private TextMeshProUGUI textBox;

    [Header("Ink Files")] 
    private Story currentStory;
    private bool dialogueIsPlaying;
    [SerializeField] private TextAsset inkDay0;

    [Header("Choices UI")] 
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    
    
    
    private void Start()
    {
        currentStory = new Story(inkDay0.text);
        LoadCurrentDayInkFile();

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
        
        ContinueStory();

    }
    

    public void LoadCurrentDayInkFile()
    {
        switch (GameManager.instance.currentDay)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
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
        }
    }

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
        
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }
}
