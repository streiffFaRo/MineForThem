using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Deathzone : MonoBehaviour
{
    public bool colliderOnDetection = true;

    private void Start()
    {
        StartCoroutine(Kill());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && colliderOnDetection)
        {
            GameManager.instance.GetComponent<EndingManager>().InitEnding(7);
        }
    }

    public IEnumerator Kill()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.GameObject());
        colliderOnDetection = false;
    }
}
