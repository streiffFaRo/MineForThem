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
    
    
    private void Start()
    {
        currentStory = new Story(inkDay0.text);
        LoadCurrentDayInkFile();
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
        }
        else
        {
            Debug.Log("No Dialogue to Display");
        }
    }
}
