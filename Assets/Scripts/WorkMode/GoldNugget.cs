using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldNugget : MonoBehaviour
{

    public AudioManager collectSound;
    public GameObject nugget;
    public UIController uIController;

    private void Awake()
    {
        collectSound = VolumeManager.instance.GetComponent<AudioManager>();
        uIController = FindObjectOfType<UIController>();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("Player"))
        {
            GameManager.instance.UpdateGoldCount();
            uIController.UpdateGoldMined();
            collectSound.PlayCollectSound();
            //TODO Play CollectSound
            Destroy(nugget);
        }
    }
    
}
