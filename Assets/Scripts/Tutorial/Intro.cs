using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{

    [SerializeField] private Image image1;
    [SerializeField] private Image image2;
    [SerializeField] private Image image3;
    [SerializeField] private Button button;
    private AudioManager audio;

    private void Start()
    {
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
        StartCoroutine(PlayIntro());
        
        audio = VolumeManager.instance.GetComponent<AudioManager>();
    }
    
    
    public IEnumerator PlayIntro()
    {
        //TODO Reinwerfen
        yield return new WaitForSeconds(2f);
        audio.PlayPhotoSound();
        yield return new WaitForSeconds(0.5f);
        image1.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        audio.PlayPhotoSound();
        yield return new WaitForSeconds(0.5f);
        image2.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        audio.PlayPhotoSound();
        yield return new WaitForSeconds(0.5f);
        image3.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        button.gameObject.SetActive(true);
    }

    public void LoadLobby()
    {
        SceneManager.LoadScene("Lobby_Scene");
    }
}
