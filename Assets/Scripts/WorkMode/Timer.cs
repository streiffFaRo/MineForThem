using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime;
    [SerializeField] private Animator timerAnimator;
    public bool stopTimer;
    

    private void Start()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
        if (GameManager.instance.currentDay == 0)
        {
            stopTimer = true;
        }
        else
        {
            stopTimer = false;
        }
    }

    private void Update()
    {
        if (!stopTimer)
        {
            Countdown();
        }
    }

    public void ToggleTimer()
    {
        if (stopTimer)
        {
            stopTimer = false;
        }
        else
        {
            stopTimer = true;
        }
    }

    public void Countdown()
    {
        
            if (remainingTime <= 31 && timerText.color != Color.red)
            {
                timerText.color = Color.red;
                timerAnimator.SetBool("Beat", true);
                VolumeManager.instance.GetComponent<AudioManager>().PlayBellSound();
            }
            
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else if (remainingTime < 0)
            {
                remainingTime = 0;
                InitEnding();
                stopTimer = true;
                
            }

            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    public void InitEnding()
    {
        Debug.Log("Died in Mine");
        GameManager.instance.GetComponent<EndingManager>().InitEnding(5);
    }

}
    
