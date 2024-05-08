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
    [SerializeField] bool usesMarker;
    [SerializeField] string[] speechLinesDay0;
    [SerializeField] private SpeechLineDeluxe speechLineDeluxeTest;
    [SerializeField] string[] speechLinesDay1;
    [SerializeField] string[] speechLinesDay2;
    [SerializeField] string[] speechLinesDay3;
    [SerializeField] string[] speechLinesDay4;
    [SerializeField] string[] speechLinesDay5;
    [SerializeField] string[] speechLinesDay6;
    private bool isTalking;
    private int currentLine = 0;
    private string[] currentSpeechLineDay;
    
    
    private void Awake()
    {
        boxcollider = GetComponentInChildren<BoxCollider2D>();
        speechbubble.SetActive(false);
        newsMarker.SetActive(false);
        if (usesMarker)
        {
            newsMarker.SetActive(true);
        }
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
                currentSpeechLineDay = speechLinesDay0;
                break;
            case 1:
                currentSpeechLineDay = speechLinesDay1;
                break;
            case 2:
                currentSpeechLineDay = speechLinesDay2;
                break;
            case 3:
                currentSpeechLineDay = speechLinesDay3;
                break;
            case 4:
                currentSpeechLineDay = speechLinesDay4;
                break;
            case 5:
                currentSpeechLineDay = speechLinesDay5;
                break;
            case 6:
                currentSpeechLineDay = speechLinesDay6;
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
            if (currentSpeechLineDay.Length <= currentLine)
            {
                currentLine = 0;
                
                if (usesMarker)
                {
                    newsMarker.SetActive(false);
                }
            }
            StartCoroutine(Bubble());
        }
    }

    public IEnumerator Bubble()
    {
        speechbubble.SetActive(true);
        text.SetText(currentSpeechLineDay[currentLine]);
        currentLine++;
        //TODO Play Sound
        //TODO Animation Bubble Pop up
        yield return new WaitForSeconds(3f);
        speechbubble.SetActive(false);
        isTalking = false;
    }
}

[System.Serializable]
public class SpeechLineDeluxe
{
    [SerializeField] string[] speechLine;
    public int importantLineNumber;
}