using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeTutorial : MonoBehaviour
{
    private Canvas canvas;
    private PlayerInputScript playerInputScript;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        playerInputScript = FindObjectOfType<PlayerInputScript>();
    }

    private void Start()
    {
        if (GameManager.instance.currentDay != 0)
        {
            canvas.gameObject.SetActive(false);
        }
        else
        {
            playerInputScript.canMove = false;
        }
    }

    public void TutorialOver()
    {
        playerInputScript.canMove = true;
        canvas.gameObject.SetActive(false);
    }
}
