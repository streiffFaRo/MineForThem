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
    
    public AudioSource shotSound;
    public AudioSource photoSound;

    [Header("Talk Sounds")]
    public PlayRandomSound vorarbeiterTalk;
    public PlayRandomSound davyTalk;
    
    [Header("UI")]
    public PlayRandomSound uI_FlipPageSound;
    public PlayRandomSound uI_ScribbleSound;
    public AudioSource uI_ClickSound;
    public AudioSource uI_HoverSound;
    
    [Header("Blocks")]
    public PlayRandomSound pickaxeSound;
    public PlayRandomSound StoneCrackSound;
    public PlayRandomSound dirtSound;
    public PlayRandomSound stoneSound;
    public AudioSource goldSound;
    public AudioSource fuzeSound;
    public AudioSource explosionSound;
    public AudioSource minecartSound;
    
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

    // --- Talks Sounds ---

    public void PlayVorarbeiterTalk()
    {
        vorarbeiterTalk.PlaySound();
    }

    public void PlayDavyTalk()
    {
        davyTalk.PlaySound();
    }

    
    // --- UI Sounds
    
    public void PlayPaperSound()
    {
        uI_FlipPageSound.PlaySound();
    }
    
    public void PlayScribbleSound()
    {
        uI_ScribbleSound.PlaySound();
    }

    public void PlayClickSound()
    {
        uI_ClickSound.Play();
    }

    public void PlayHoverSound()
    {
        uI_HoverSound.Play();
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

    public void PlayFuzeSound()
    {
        fuzeSound.Play();
    }

    public void PlayExplosionSound()
    {
        explosionSound.Play();
    }

    public void PlayMinecartSound()
    {
        minecartSound.Play();
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
