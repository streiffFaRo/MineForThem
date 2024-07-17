using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public TextMeshProUGUI fpsText;

    private int currentFPSCap = 0;
    private void Awake()
    {
        if (Application.targetFrameRate >= 400)
        {
            currentFPSCap = 0;
        }
        else if (Application.targetFrameRate >= 200)
        {
            currentFPSCap = 240;
        }
        else if (Application.targetFrameRate >= 100)
        {
            currentFPSCap = 120;
        }
        else if (Application.targetFrameRate >=50)
        {
            currentFPSCap = 60;
        }
        else
        {
            currentFPSCap = 30;
        }

        if (fpsText != null)
        {
            fpsText.text = currentFPSCap.ToString();
        }
        
        
    }
    
    public void StartGame()
    {
        GameManager.instance.SetUpNewGame();
        StartCoroutine(BootGame());
    }

    public IEnumerator BootGame()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Intro_Scene");
    }

    public void ChangeFPSCap()
    {
        switch (currentFPSCap)
        {
            case 0:
                Application.targetFrameRate = 30;
                currentFPSCap = 30;
                fpsText.text = "30";
                break;
            case 30:
                Application.targetFrameRate = 60;
                currentFPSCap = 60;
                fpsText.text = "60";
                break;
            case 60:
                Application.targetFrameRate = 120;
                currentFPSCap = 120;
                fpsText.text = "120";
                break;
            case 120:
                Application.targetFrameRate = 240;
                currentFPSCap = 240;
                fpsText.text = "240";
                break;
            case 240:
                Application.targetFrameRate = 0;
                currentFPSCap = 0;
                fpsText.text = "unlimited";
                break;
        }
    }


    public void SelectButton(Button button)
    {
        button.Select();
    }

    public void Credits()
    {
        Debug.Log("Credits");
        //TODO Cameraswipe left
    }
    
    public void LoadMainMenu()
    {
        GameManager.instance.SetUpNewGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
