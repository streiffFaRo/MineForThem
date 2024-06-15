using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SackManager : MonoBehaviour
{

    public GameObject sack1;
    public GameObject sack2;
    public GameObject sack3;
    public GameObject sack4;
    public GameObject sack5;
    
    private void Start()
    {
        switch (GameManager.instance.currentDay)
        {
            case 1:
                sack1.SetActive(true);
                break;
            case 2:
                sack2.SetActive(true);
                break;
            case 3:
                sack3.SetActive(true);
                break;
            case 4:
                sack4.SetActive(true);
                break;
            case 5:
                sack5.SetActive(true);
                break;
        }
    }
}
