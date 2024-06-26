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
        if (audioManager != null)
        {
            audioManager.PlayScribbleSound();
        }
    }

    public void PlayPaperSound()
    {
        if (audioManager != null)
        {
            audioManager.PlayPaperSound();
        }
    }

    public void PlayHoverSound()
    {
        if (audioManager != null)
        {
            audioManager.PlayHoverSound();
        }
    }

    public void PlayClickSound()
    {
        audioManager.PlayClickSound();
    }
}
