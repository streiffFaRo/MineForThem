using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MineTutorial : MonoBehaviour
{

    private Canvas canvas;
    private PlayerInputScript playerInputScript;
    private Timer timer;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        playerInputScript = FindObjectOfType<PlayerInputScript>();
        timer = FindObjectOfType<Timer>();

    }

    private void Start()
    {
        if (GameManager.instance.currentDay != 0)
        {
            canvas.gameObject.SetActive(false);
            Debug.Log("After Day 0");
            timer.stopTimer = false;
        }
        else
        {
            playerInputScript.canMove = false;
            Debug.Log("Day0");
        }
    }

    public void TutorialOver()
    {
        timer.stopTimer = false;
        playerInputScript.canMove = true;
        canvas.gameObject.SetActive(false);
    }
}
