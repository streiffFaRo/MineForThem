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
    public AudioSource placeBlockSound;
    public PlayRandomSound uI_ClickSound;
    public AudioSource shotSound;
    public AudioSource photoSound;

    [Header("Blocks")]
    public PlayRandomSound pickaxeSound;
    public PlayRandomSound StoneCrackSound;
    public PlayRandomSound dirtSound;
    public PlayRandomSound stoneSound;
    public AudioSource goldSound;
    
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

    // --- UI Sounds
    
    public void PlayUIClickSound()
    {
        uI_ClickSound.PlaySound();
    }

    // --- Gameplay Sounds ---
    
    public void PlayCollectSound()
    {
        collectSound.PlaySound();
    }

    public void PlayFootStepSound()
    {
        footstepsSound.PlaySound();
    }

    public void PlayPlaceBlockSound()
    {
        placeBlockSound.Play();
    }
    
    public void PlayPhotoSound()
    {
        photoSound.Play();
    }
    

    // --- Block Sounds ---
    
    public void PlayPickaxeSound()
    {
        pickaxeSound.PlaySound();
    }
    
    
    public void PlayStoneCrackSound()
    {
        StoneCrackSound.PlaySound();
    }
    
    public void PlayDirtSound()
    {
        dirtSound.PlaySound();
    }
    
    public void PlayStoneSound()
    {
        stoneSound.PlaySound();
    }
    
    public void PlayGoldSound()
    {
        goldSound.Play();
    }
    
    

    // --- Atmo Sounds ---
    
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
