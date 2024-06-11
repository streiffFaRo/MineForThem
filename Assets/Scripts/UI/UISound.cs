using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISound : MonoBehaviour
{

    private AudioManager audioManager;
    
    private void Start()
    {
        audioManager = VolumeManager.instance.GetComponent<AudioManager>();
    }

    public void PlayScribbleSound()
    {
        audioManager.PlayUIClickSound();
    }

    public void PlayHoverSound()
    {
        audioManager.PlayHoverSound();
    }

    public void PlayClickSound()
    {
        audioManager.PlayClickSound();
    }
}
