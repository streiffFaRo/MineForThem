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
    [SerializeField] string[] speechLines;
    private bool isTalking;
    private int currentLine = 0;
    
    private void Awake()
    {
        boxcollider = GetComponentInChildren<BoxCollider2D>();
    }

    public void Speech()
    {

        if (!isTalking)
        {
            isTalking = true;
            if (speechLines.Length <= currentLine)
            {
                currentLine = 0;
            }
            Debug.Log("Speech");
            StartCoroutine(Bubble());
        }
        else
        {
            StopCoroutine(Bubble());
            if (speechLines.Length <= currentLine)
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
        text.SetText(speechLines[currentLine]);
        currentLine++;
        //TODO Set TEXT
        //TODO Play Sound
        //TODO Animation Bubble Pop up
        yield return new WaitForSeconds(3f);
        speechbubble.SetActive(false);
        isTalking = false;
    }
}
