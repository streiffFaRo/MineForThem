using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    
    public float radius = 5f;
    public bool showGizmos = true;
    

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
        Debug.Log("Interact");

        Collider2D[]foundCollider = Physics2D.OverlapCircleAll(transform.position, radius);
        
        foreach (Collider2D collider in foundCollider)
        {
            NPCDialog npcdialog = collider.GetComponent<NPCDialog>();

            if (npcdialog != null)
            {
                npcdialog.Speech();
            }
            
            if (collider.CompareTag("Interaction") && 
                Vector2.Distance(transform.position, collider.transform.position) <= collider.GetComponent<BoxCollider2D>().size.x/2)
            {
                FindObjectOfType<GridGenerator>().LoadGrid();
            }
            
            /*
         *  ->Minecarttrack
         *  ->Enter/leave Area
         *  ->
         */
        }

        
    }
    
    
    
}
