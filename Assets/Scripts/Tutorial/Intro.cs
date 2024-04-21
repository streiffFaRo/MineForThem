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

    private void Start()
    {
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
        StartCoroutine(PlayIntro());
    }

    public IEnumerator PlayIntro()
    {
        //TODO Let them fade in
        yield return new WaitForSeconds(3f);
        image1.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        image2.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        image3.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        button.gameObject.SetActive(true);
    }

    public void LoadLobby()
    {
        SceneManager.LoadScene("Lobby_Scene");
    }
}
