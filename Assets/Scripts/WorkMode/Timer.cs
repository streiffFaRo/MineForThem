using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime;
    public bool stopTimer;


    private void Start()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
        //Timer will be started in MineTutorial Script
        stopTimer = true;
        
    }

    private void Update()
    {
        if (!stopTimer)
        {
            Countdown();
        }
    }

    public void Countdown()
    {
        
            //TODO Timer visuelles feedback wenn Timer unter 30 sec
            
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
    
