using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shootout : MonoBehaviour
{

    public PlayerInputScript playerInputScript;
    public GameObject showButtonMine;
    public GameObject showButtonExit;
    public SpriteRenderer vorarbeiterSprite;
    public Transform friendTransform;
    //TODO VorarbeiterAnimator
    //TODO PlayerAnimator

    private void Awake()
    {
        playerInputScript = FindObjectOfType<PlayerInputScript>();

        int currentDay = GameManager.instance.currentDay;
        
        if (currentDay >= 6 && GameManager.instance.snitched)
        {
            GetComponentInParent<SpriteRenderer>().gameObject.SetActive(false);
        }

        if (currentDay >= 5 && GameManager.instance.hasBullet)
        {
            showButtonMine.SetActive(false);
        }
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

        Vector3 friendStartPos = new Vector3(friendTransform.position.x, friendTransform.position.y, friendTransform.position.z);
        Vector3 friendLeftPos = new Vector3(friendTransform.position.x-15, friendTransform.position.y, friendTransform.position.z);
        friendTransform.DOMove(friendLeftPos, 5f);
        yield return new WaitForSeconds(5);
        VolumeManager.instance.GetComponent<AudioManager>().shotSound.Play();
        vorarbeiterSprite.gameObject.SetActive(false);
        //TODO Change Vorarbeiter Sprite
        yield return new WaitForSeconds(2);
        friendTransform.DOMove(friendStartPos, 5f);
        playerInputScript.canMove = true;
        showButtonExit.SetActive(true);
        
    }

}