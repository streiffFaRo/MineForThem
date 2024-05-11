using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{

    private BoxCollider2D boxcollider;
    [SerializeField] GameObject speechbubble;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject newsMarker;
    [SerializeField] private SpeechLineDeluxe speechLineDeluxeDay0;
    [SerializeField] private SpeechLineDeluxe speechLineDeluxeDay1;
    [SerializeField] private SpeechLineDeluxe speechLineDeluxeDay2;
    [SerializeField] private SpeechLineDeluxe speechLineDeluxeDay3;
    [SerializeField] private SpeechLineDeluxe speechLineDeluxeDay4;
    [SerializeField] private SpeechLineDeluxe speechLineDeluxeDay5;
    [SerializeField] private SpeechLineDeluxe speechLineDeluxeDay6;
    private bool isTalking;
    private int currentLine = 0;
    private SpeechLineDeluxe currentSpeechLineDay;
    
    
    private void Awake()
    {
        boxcollider = GetComponentInChildren<BoxCollider2D>();
        speechbubble.SetActive(false);
    }

    public void Start()
    {
        SelectSpeechLines();
    }

    public void SelectSpeechLines()
    {
        switch (GameManager.instance.currentDay)
        {
            case 0:
                currentSpeechLineDay = speechLineDeluxeDay0;
                break;
            case 1:
                currentSpeechLineDay = speechLineDeluxeDay1;
                break;
            case 2:
                currentSpeechLineDay = speechLineDeluxeDay2;
                break;
            case 3:
                currentSpeechLineDay = speechLineDeluxeDay3;
                break;
            case 4:
                currentSpeechLineDay = speechLineDeluxeDay4;
                break;
            case 5:
                currentSpeechLineDay = speechLineDeluxeDay5;
                break;
            case 6:
                currentSpeechLineDay = speechLineDeluxeDay6;
                break;
            default:
                break;
        }
    }

    public void Speech()
    {

        if (!isTalking)
        {
            isTalking = true;
            if (currentSpeechLineDay.importantLineNumber == 9)
            {
                newsMarker.SetActive(false);
            }
            else if (currentLine == currentSpeechLineDay.importantLineNumber)
            {
                newsMarker.SetActive(false);
            }
            
            if (currentSpeechLineDay.speechLines.Length <= currentLine)
            {
                currentLine = 0;
                
            }
            StartCoroutine(Bubble());
        }
    }

    public IEnumerator Bubble()
    {
        speechbubble.SetActive(true);
        text.SetText(currentSpeechLineDay.speechLines[currentLine]);
        currentLine++;
        //TODO Play Sound
        //TODO Animation Bubble Pop up
        yield return new WaitForSeconds(5f);
        speechbubble.SetActive(false);
        isTalking = false;
    }
}

[System.Serializable]
public class SpeechLineDeluxe
{
    public string[] speechLines;
    public int importantLineNumber;
}