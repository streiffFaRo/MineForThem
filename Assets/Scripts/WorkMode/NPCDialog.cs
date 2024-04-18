using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{

    private BoxCollider2D boxcollider;
    [SerializeField] GameObject speechbubble;
    [SerializeField] private TextMeshPro text;
    [SerializeField] string[] speechLinesDay0;
    [SerializeField] string[] speechLinesDay1;
    [SerializeField] string[] speechLinesDay2;
    [SerializeField] string[] speechLinesDay3;
    [SerializeField] string[] speechLinesDay4;
    [SerializeField] string[] speechLinesDay5;
    private bool isTalking;
    private int currentLine = 0;
    private string[] currentSpeechLineDay;
    
    private void Awake()
    {
        boxcollider = GetComponentInChildren<BoxCollider2D>();
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
            }
            Debug.Log("Speech");
            StartCoroutine(Bubble());
        }
        else
        {
            StopCoroutine(Bubble());
            if (currentSpeechLineDay.Length <= currentLine)
            {
                currentLine = 0;
            }
            Debug.Log("Speech");
            new WaitForEndOfFrame();
            StartCoroutine(Bubble());
        }
        
    }

    public IEnumerator Bubble()
    {
        speechbubble.SetActive(true);
        text.SetText(currentSpeechLineDay[currentLine]);
        currentLine++;
        //TODO Set TEXT
        //TODO Play Sound
        //TODO Animation Bubble Pop up
        yield return new WaitForSeconds(3f);
        speechbubble.SetActive(false);
        isTalking = false;
    }
}
