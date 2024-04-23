using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootout : MonoBehaviour
{

    public PlayerInputScript playerInputScript;
    //TODO VorarbeiterAnimator
    //TODO PlayerAnimator

    private void Awake()
    {
        playerInputScript = FindObjectOfType<PlayerInputScript>();
    }

    public void ShootoutInteraction()
    {
        //TODO Übergabeanimation
        playerInputScript.canMove = false;
        playerInputScript.GetComponent<Interaction>().shootoutDone = true;
        StartCoroutine(CutScene());
    }

    public IEnumerator CutScene()
    {
        yield return new WaitForSeconds(1);
        //TODO Move NPC links
        yield return new WaitForSeconds(2);
        //TODO Schussound
        //TODO Change Vorarbeiter Sprite
        yield return new WaitForSeconds(1);
        //TODO Move NPC zurück
        playerInputScript.canMove = true;
        
    }

}