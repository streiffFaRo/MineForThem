using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MiningSystem : MonoBehaviour
{

    [SerializeField] private GridGenerator gridGenerator;
    public float maxDistance = 2;
    public int blocksInInv = 0;
    
    public void DestroyBlock(Vector3Int mousePos2D)
    {
        TileBase foundTile = gridGenerator.tilemap.GetTile(mousePos2D);

        if (foundTile != null && foundTile != gridGenerator.barrierTile && IsInRange(mousePos2D))
        {
            if (foundTile == gridGenerator.blocks[3].tile)
            {
                //TODO Gold Int++ (GameManager)
            }
            else
            {
                blocksInInv++;
            }


            gridGenerator.tilemap.SetTile(mousePos2D,null);
        }
    }

    public void PlaceBlock(Vector3Int mousePos2D)
    {
        TileBase foundTile = gridGenerator.tilemap.GetTile(mousePos2D);

        if (foundTile == null && IsInRange(mousePos2D) && blocksInInv > 0)
        {
            gridGenerator.tilemap.SetTile(mousePos2D, gridGenerator.blocks[0].tile);
            blocksInInv--;
            
            //TODO Check: Block nicht auf Spieler setzen
            //if (mousePos2D.x != Mathf.FloorToInt(transform.position.x) && mousePos2D.y != Mathf.FloorToInt(transform.position.y)){}
            
        }
    }

    public bool IsInRange(Vector3Int mousePos)
    {
        float distance = Vector3Int.Distance(mousePos, new Vector3Int(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y)));

        return distance <= maxDistance;

    }

}
