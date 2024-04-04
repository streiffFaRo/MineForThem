using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class MiningSystem : MonoBehaviour
{

    [Header("SystemComponents")]
    public PlayerMovement playerMovement;
    public UIController uIController;
    public GridGenerator gridGenerator;
    public float maxDistance = 2;
    public GameObject goldNugget;
    
    [Header("Sounds")]
    //TODO Sounds in AudioManager
    public PlayRandomSound pickaxeSound;
    public PlayRandomSound placeSound;

    //Private Varibalen
    private Vector3 middleBlockPos;
    

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
                
                //Debug.Log(foundTile.GameObject().GetComponent<Blocks>().durability);
                
                Debug.Log(foundTile);
                
                if (foundTile == gridGenerator.blocks[3].tile)
                {
                    int rdmNuggetCount = Random.Range(1, 5);

                    for (int i = 0; i < rdmNuggetCount; i++)
                    {
                        middleBlockPos = new Vector3(mousePos2D.x + Random.Range(0.3f, 0.7f), mousePos2D.y + Random.Range(0.3f, 0.7f), 0);
                        
                        gridGenerator.tilemap.SetTile(mousePos2D,null);
                        Instantiate(goldNugget, middleBlockPos, Quaternion.identity);
                        i++;
                        //TODO Nuggets buggen in die Tilemap
                    }
                
                }
                else
                {
                    gridGenerator.tilemap.SetTile(mousePos2D,null);
                    GameManager.instance.UpdateBlocksInInv(true);
                    uIController.UpdateBlocksInInv();
                }    
                
                pickaxeSound.PlaySound();
                GameManager.instance.blocksMined++;
            }
        }
    }

    public void PlaceBlock(Vector3Int mousePos2D)
    {
        TileBase foundTile = gridGenerator.tilemap.GetTile(mousePos2D);

            if (foundTile == null && IsInRange(mousePos2D) && GameManager.instance.blocksInInv > 0)
            {

                if (mousePos2D.x == Mathf.FloorToInt(transform.position.x) &&
                    mousePos2D.y == Mathf.FloorToInt(transform.position.y) || 
                    gridGenerator.noCollisionTileMap.GetTile(mousePos2D) != null)
                {
                    //TODO Cancle Sound (Block kann nicht Platziert werden)
                }
                else
                {
                    gridGenerator.tilemap.SetTile(mousePos2D, gridGenerator.blocks[0].tile);
                    GameManager.instance.UpdateBlocksInInv(false);
                    GameManager.instance.blocksPlaced++;
                    uIController.UpdateBlocksInInv();
                    placeSound.PlaySound();
                    
                    //TODO Was wenn Block auf Gold gesetzt?
                }
                
                
            }
    }

    public bool IsInRange(Vector3Int mousePos)
    {
        float distance = Vector3Int.Distance(mousePos, new Vector3Int(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y)));

        return distance <= maxDistance;
    }

}
