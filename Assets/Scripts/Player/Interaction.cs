using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    
    public float radius = 5f;
    public bool showGizmos = true;
    public bool shootoutDone;
    

    private void OnDrawGizmos()
    {
        if (showGizmos)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }

    public void Interact()
    {
        
        Collider2D[]foundCollider = Physics2D.OverlapCircleAll(transform.position, radius);
        
        foreach (Collider2D collider in foundCollider)
        {
            NPCDialog npcdialog = collider.GetComponent<NPCDialog>();

            if (npcdialog != null)
            {
                Debug.Log("Test if npc Dialogue is null passed");
                if (GameManager.instance.currentDay >= 5 && GameManager.instance.hasBullet &&
                    npcdialog.GetComponentInChildren<Shootout>()!= null)
                {
                    Debug.Log("Fire Shootout passed");
                    npcdialog.GetComponentInChildren<Shootout>()?.ShootoutInteraction();
                }
                else
                {
                    Debug.Log("Play Dialogue Line passed");
                    npcdialog.Speech();
                }
                
            }
            
            if (collider.CompareTag("Interaction") && 
                Vector2.Distance(transform.position, collider.transform.position) <= collider.GetComponent<BoxCollider2D>().size.x/2)
            {
                FindObjectOfType<GridGenerator>()?.LoadGrid();
                
                if (FindObjectOfType<LobbyManager>()!= null && !shootoutDone)
                {
                    FindObjectOfType<LobbyManager>().LoadMineScene();
                }
                
            }
            else if (collider.CompareTag("EndDoor") && shootoutDone &&
                     Vector2.Distance(transform.position, collider.transform.position) <= collider.GetComponent<BoxCollider2D>().size.x/2)
            {
                GameManager.instance.GetComponent<EndingManager>().InitEnding(0);
            }

            if (collider.CompareTag("MineCartStation") && 
                Vector2.Distance(transform.position, collider.transform.position) <= collider.GetComponent<BoxCollider2D>().size.x/2)
            {
                collider.GetComponent<Minecart>().SetupTransition();
            }
        }

        
    }
    
    
    
}
