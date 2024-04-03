using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayRandomSound : MonoBehaviour
{
    public AudioSource[] sounds;

    public void PlaySound()
    {
        int randomSound = Random.Range(0, sounds.Length);

        Debug.Log(randomSound);
        sounds[randomSound].Play();
    }
}
