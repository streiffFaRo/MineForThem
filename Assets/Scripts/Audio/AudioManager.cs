using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{

    [Header("Sounds")]
    public PlayRandomSound collectSound;
    public PlayRandomSound footstepsSound;
    public PlayRandomSound pickaxeSound;
    public AudioSource placeBlockSound;
    public PlayRandomSound StoneCrackSound;
    public PlayRandomSound uI_ClickSound;
    public AudioSource shotSound;
    public AudioSource photoSound;

    [Header("Atmos")]
    public AudioSource miningAtmo;
    public AudioSource homeAtmo;
    public AudioSource MenuMusic;
    public AudioSource currentAtmo;

    private void Start()
    {
        PlayCurrentAtmo();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneChange;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneChange;
    }

    private void OnSceneChange(Scene arg0, LoadSceneMode arg1)
    {
        PlayCurrentAtmo();
    }


    public void PlayCollectSound()
    {
        collectSound.PlaySound();
    }

    public void PlayFootStepSound()
    {
        footstepsSound.PlaySound();
    }

    public void PlayPickaxeSound()
    {
        pickaxeSound.PlaySound();
    }

    public void PlayPlaceBlockSound()
    {
        placeBlockSound.Play();
    }
    
    public void PlayPhotoSound()
    {
        photoSound.Play();
    }
    
    public void PlayStoneCrackSound()
    {
        StoneCrackSound.PlaySound();
    }

    public void PlayUIClickSound()
    {
        uI_ClickSound.PlaySound();
    }
    



    public void PlayCurrentAtmo()
    {
        
        
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Mine_Scene") || 
            SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Lobby_Scene"))
        {
            if (currentAtmo != miningAtmo)
            {
                currentAtmo.Stop();
                currentAtmo = miningAtmo;
            }
            
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {
            if (currentAtmo != MenuMusic)
            {
                currentAtmo.Stop();
                currentAtmo = MenuMusic;
            }
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("End_Scene"))
        {
            if (currentAtmo != homeAtmo)
            {
                currentAtmo.Stop();
                currentAtmo = homeAtmo;
            }
        }
        else
        {
            if (currentAtmo != homeAtmo)
            {
                currentAtmo.Stop();
                currentAtmo = homeAtmo;
            }
        }
        currentAtmo.Play();
        
    }

}
