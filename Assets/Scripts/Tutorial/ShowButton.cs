using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButton : MonoBehaviour
{

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        sprite.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            sprite.gameObject.SetActive(true);
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
