using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButton : MonoBehaviour
{

    private SpriteRenderer sprite;
    public bool oneTimeUse = false;
    private bool denyFunction = false;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        sprite.gameObject.SetActive(false);
        if (GameManager.instance.currentDay > 0 && oneTimeUse)
        {
            denyFunction = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && !denyFunction)
        {
            sprite.gameObject.SetActive(true);
            if (oneTimeUse)
            {
                denyFunction = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            sprite.gameObject.SetActive(false);
        }
    }
}
