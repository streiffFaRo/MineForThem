using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    
    
    public void StartGame()
    {
        GameManager.instance.SetUpNewGame();
        SceneManager.LoadScene("Lobby_Scene");
        //TODO Cameraswipe right to contract
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
