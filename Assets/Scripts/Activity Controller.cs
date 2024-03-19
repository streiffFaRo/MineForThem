using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityController : MonoBehaviour
{
    private void Start()
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
}
