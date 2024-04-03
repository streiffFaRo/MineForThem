using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime;
    private bool stopTimer;


    private void Update()
    {
        Countdown();
    }

    public void Countdown()
    {
        if (!stopTimer)
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
        
    }

    public void InitEnding()
    {
        Debug.Log("Died in Mine");
        GameManager.instance.GetComponent<EndingManager>().InitEnding(5);
    }

}
    
