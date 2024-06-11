using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class Shootout : MonoBehaviour
{

    public PlayerInputScript playerInputScript;
    public GameObject showButtonMine;
    public GameObject showButtonExit;
    public GameObject vorarbeiter;
    public Transform friendTransform;
    public SpriteRenderer davySprite;
    public Animator davyAnimator;
    public GameObject newsMarker;
    public GameObject säcke;
    public GameObject vorarbeiterDead;
    private bool shootoutDone = false;
    //TODO VorarbeiterAnimator

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
        
        if (!shootoutDone)
        {
            playerInputScript.canMove = false;
            playerInputScript.GetComponent<Interaction>().shootoutDone = true;
            newsMarker.SetActive(false);
            shootoutDone = true;
            säcke.SetActive(false);
            StartCoroutine(CutScene());
        }
    }

    public IEnumerator CutScene()
    {
        yield return new WaitForSeconds(1);

        Vector3 friendStartPos = new Vector3(friendTransform.position.x, friendTransform.position.y, friendTransform.position.z);
        Vector3 friendLeftPos = new Vector3(friendTransform.position.x-15, friendTransform.position.y, friendTransform.position.z);
        friendTransform.DOMove(friendLeftPos, 5f);
        davySprite.flipX = true;
        davyAnimator.SetBool("DavyWalking", true);
        
        yield return new WaitForSeconds(3);
        VolumeManager.instance.GetComponent<AudioManager>().shotSound.Play();
        vorarbeiter.gameObject.SetActive(false);
        vorarbeiterDead.SetActive(true);
        
        
        yield return new WaitForSeconds(1);
        davySprite.flipX = false;
        friendTransform.DOMove(friendStartPos, 5f);
        showButtonExit.SetActive(true);
        
        yield return new WaitForSeconds(5);
        playerInputScript.canMove = true;
        davyAnimator.SetBool("DavyWalking", false);
        
    }

}