using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    
    
    public void StartGame()
    {
        SceneManager.LoadScene("SandboxScene");
        //TODO Cameraswipe right to contract
    }

    public void Credits()
    {
        Debug.Log("Credits");
        //TODO Cameraswipe left
    }

    public void Quit()
    {
        Application.Quit();
    }

}
