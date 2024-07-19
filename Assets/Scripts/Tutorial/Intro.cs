using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
    private Vector3 pic1Pos;
    private Vector3 pic2Pos;
    private Vector3 pic3Pos;

    private void Start()
    {
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
        StartCoroutine(PlayIntro());
        
        audio = VolumeManager.instance.GetComponent<AudioManager>();

        pic1Pos = new Vector3(image1.transform.position.x, image1.transform.position.y, image1.transform.position.z);
        pic2Pos = new Vector3(image2.transform.position.x, image2.transform.position.y, image2.transform.position.z);
        pic3Pos = new Vector3(image3.transform.position.x, image3.transform.position.y, image3.transform.position.z);
    }
    
    
    public IEnumerator PlayIntro()
    {
        yield return new WaitForSeconds(2f);
        audio.PlayPhotoSound();
        yield return new WaitForSeconds(0.5f);
        image1.gameObject.SetActive(true);
        image1.transform.position = new Vector3(900, 1200, 0);
        image1.transform.DOMove(pic1Pos, 0.6f);
        image1.transform.DORotate(new Vector3(0,0,12.103f), 0.6f);
        yield return new WaitForSeconds(2f);
        audio.PlayPhotoSound();
        yield return new WaitForSeconds(0.5f);
        image2.gameObject.SetActive(true);
        image2.transform.position = new Vector3(-100, 900, 0);
        image2.transform.DOMove(pic2Pos, 0.8f);
        image2.transform.DORotate(new Vector3(0, 0,-2.5f), 0.8f);
        yield return new WaitForSeconds(2f);
        audio.PlayPhotoSound();
        yield return new WaitForSeconds(0.5f);
        image3.gameObject.SetActive(true);
        image3.transform.position = new Vector3(-100, -100, 0);
        image3.transform.DOMove(pic3Pos, 0.6f);
        image3.transform.DORotate(new Vector3(0, 0,-5f), 0.6f);
        yield return new WaitForSeconds(2f);
        button.gameObject.SetActive(true);
    }

    public void LoadLobby()
    {
        StartCoroutine(BootLobby());
    }

    public IEnumerator BootLobby()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Lobby_Scene");
    }
}
