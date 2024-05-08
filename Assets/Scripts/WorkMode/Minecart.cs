using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Minecart : MonoBehaviour
{
    public List<Minecart> minecartStations;
    private Tween transition;
    private PlayerMovement player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    public void SetupTransition()
    {
        if (player.GetComponentInChildren<SpriteRenderer>().gameObject != null)
        {
            minecartStations = new List<Minecart>(FindObjectsOfType<Minecart>());
            minecartStations.Remove(GetComponent<Minecart>());

            Minecart stationToExit = minecartStations[0];
        
            Vector3 stationtoExitCords = new Vector3(stationToExit.gameObject.transform.position.x,
                stationToExit.gameObject.transform.position.y, stationToExit.gameObject.transform.position.z);

        
            StartCoroutine(TransitionPlayer());
            player.transform.DOMove(stationtoExitCords, 2f);
        }
        
    }

    public IEnumerator TransitionPlayer()
    {
        SpriteRenderer playerSprite = player.GetComponentInChildren<SpriteRenderer>();
        playerSprite.gameObject.SetActive(false);
        player.GetComponent<PlayerInputScript>().canMove = false;
        yield return new WaitForSeconds(2);
        playerSprite.gameObject.SetActive(true);
        player.GetComponent<PlayerInputScript>().canMove = true;
        
    }
}
