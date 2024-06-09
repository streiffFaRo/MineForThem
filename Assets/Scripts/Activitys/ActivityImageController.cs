using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityImageController : MonoBehaviour
{
    [Header("Images")] 
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;
    public GameObject image6;
    public GameObject image7;
    

    private void Start()
    {
        switch (GameManager.instance.currentDay)
        {
            case 0:
                image1.SetActive(true);
                break;
            case 1:
                image2.SetActive(true);
                break;
            case 2:
                image3.SetActive(true);
                break;
            case 3:
                image4.SetActive(true);
                break;
            case 4:
                image5.SetActive(true);
                break;
            case 5:
                image6.SetActive(true);
                break;
            case 6:
                image7.SetActive(true);
                break;
        }
    }
}
