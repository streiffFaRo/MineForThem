using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class MiningSystem : MonoBehaviour
{

    public PlayerMovement playerMovement;
    public UIController uIController;
    public GridGenerator gridGenerator;
    public float maxDistance = 2;
    public GameObject goldNugget;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void DestroyBlock(Vector3Int mousePos2D)
    {

        if (playerMovement.IsGrounded())
        {
            TileBase foundTile = gridGenerator.tilemap.GetTile(mousePos2D);

            if (foundTile != null && foundTile != gridGenerator.barrierTile && IsInRange(mousePos2D))
            {
                if (foundTile == gridGenerator.blocks[3].tile)
                {
                    int rdmNuggetCount = Random.Range(1, 5);

                    for (int i = 0; i < rdmNuggetCount; i++)
                    {
                        Instantiate(goldNugget, mousePos2D, Quaternion.identity);
                        i++;
                        //TODO Nuggets buggen in die Tilemap
                    }
                
                }
                else
                {
                    GameManager.instance.UpdateBlocksInInv(true);
                    uIController.UpdateBlocksInInv();
                }


                gridGenerator.tilemap.SetTile(mousePos2D,null);
            }
        }
    }

    public void PlaceBlock(Vector3Int mousePos2D)
    {
        if (playerMovement.IsGrounded())
        {
            TileBase foundTile = gridGenerator.tilemap.GetTile(mousePos2D);

            if (foundTile == null && IsInRange(mousePos2D) && GameManager.instance.blocksInInv > 0)
            {
                gridGenerator.tilemap.SetTile(mousePos2D, gridGenerator.blocks[0].tile);
                GameManager.instance.UpdateBlocksInInv(false);
                uIController.UpdateBlocksInInv();
            
                //TODO Check: Block nicht auf Start oder Ende setzen
                //TODO Check: Block nicht auf Spieler setzen
                //TODO Was wenn Block auf Gold gesetzt?
                //if (mousePos2D.x != Mathf.FloorToInt(transform.position.x) && mousePos2D.y != Mathf.FloorToInt(transform.position.y)){}
            
            }
        }
    }

    public bool IsInRange(Vector3Int mousePos)
    {
        float distance = Vector3Int.Distance(mousePos, new Vector3Int(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y)));

        return distance <= maxDistance;
    }

}
