using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour
{

    public AudioManager audioManager;
    public GameObject TNTBlock;
    public GameObject explosionLight;
    
    private void Awake()
    {
        audioManager = VolumeManager.instance.GetComponent<AudioManager>();
    }
    
    public void Bang()
    {
        explosionLight.SetActive(true);
        audioManager.PlayExplosionSound();
    }

    public void Destroy()
    {
        explosionLight.SetActive(false);
        Destroy(TNTBlock);
    }
}
