using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldNugget : MonoBehaviour
{

    public GameObject player;
    public GameObject nugget;
    public UIController uIController;

    private void Awake()
    {
        uIController = FindObjectOfType<UIController>();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("Player"))
        {
            GameManager.instance.UpdateGoldCount();
            uIController.UpdateGoldMined();
            //TODO Play CollectSound
            Destroy(nugget);
        }
    }
    
}
