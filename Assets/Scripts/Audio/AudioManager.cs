using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("Sounds")]
    public PlayRandomSound collectSound;


    public void PlayCollectSound()
    {
        collectSound.PlaySound();
    }

}
