using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour
{

    public AudioManager audioManager;
    public GameObject TNTBlock;
    
    private void Awake()
    {
        audioManager = VolumeManager.instance.GetComponent<AudioManager>();
    }
    
    public void Bang()
    {
        audioManager.PlayPhotoSound();
    }

    public void Destroy()
    {
        Destroy(TNTBlock);
    }
}
