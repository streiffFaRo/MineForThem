using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class GridGenerator : MonoBehaviour
{

    [Header("Grid")]
    public int currentGridNumber = 0;
    public int gridSizeX = 20;
    public int gridSizeY = 20;
    public Tilemap tilemap;
    public Tilemap noCollisionTileMap;
    public Tile barrierTile;
    public List<Blocks> blocks = new List<Blocks>();
    public int goldChangeRate = 40;
    

    [Header("Walker")] 
    public int walkerAmount = 5;
    public int walkerRange = 8;
    public Vector2Int steps = new Vector2Int(3,10);

    [Header("Start")] 
    public Tile start;
    public Tile end;
    public Vector2Int startToEndDistance = new Vector2Int(14,16);
    public GameObject exitDoor;

    private int goldProbability;
    private Vector2 currentStartPosition;
    

    private void Start()
    {
        LoadGrid();
    }

    public void LoadGrid()
    {
        currentGridNumber++;
        if (currentGridNumber > 3)
        {
            Debug.Log("feddig");
            return;
        }
        tilemap.ClearAllTiles();
        noCollisionTileMap.ClearAllTiles();
        SetUpGrid();
        PlaceCorridor();
        SetStartAndEnd();
        SetRandomTiles();
        FindObjectOfType<PlayerInputScript>().transform.position = currentStartPosition;
        ChanceGoldProbability();
        
    }

    public void SetUpGrid()
    {
        for (int x = -1; x <= gridSizeX; x++)
        {
            for (int y = -1; y <= gridSizeY; y++)
            {
                
                if (x == -1 || y == -1 || x == gridSizeX || y == gridSizeY)
                {
                    tilemap.SetTile(new Vector3Int(x,y), barrierTile);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(x,y),blocks[0].tile);
                }
            }
        }
    }

    public void PlaceCorridor()
    {
        List<Vector2Int> walkerStartPositions = new List<Vector2Int>(walkerAmount);

        for (int j = 0; j < walkerAmount; j++)
        {
            Vector2Int currentPos = new Vector2Int(Random.Range(0, gridSizeX), Random.Range(0,gridSizeY));
            bool goodPos = false;
            int maxPosTries = gridSizeX*gridSizeY*2;
            while (!goodPos && maxPosTries > 0)
            {
                foreach (Vector2Int walkerStart in walkerStartPositions)
                {
                    if (Vector2Int.Distance(walkerStart, currentPos) >= walkerRange)
                    {
                        goodPos = true;
                        break;
                    }
                }

                if (!goodPos)
                {
                    currentPos = new Vector2Int(Random.Range(0, gridSizeX), Random.Range(0,gridSizeY));
                }

                maxPosTries--;
            }
            tilemap.SetTile(new Vector3Int(currentPos.x, currentPos.y, 0), null);
            walkerStartPositions.Add(currentPos);

            int stepsAmount = Random.Range(steps.x, steps.y);
            
            for (int i = 0; i < stepsAmount; i++)
            {
                bool goodTile = false;
                int maxTries = 500;
            
                while (!goodTile && maxTries>0)
                {
                    Vector2Int nextPos = currentPos += GetRandomDirection();
                    if (tilemap.GetTile(new Vector3Int(nextPos.x, nextPos.y, 0)) != barrierTile && 
                        tilemap.GetTile(new Vector3Int(nextPos.x, nextPos.y, 0)) != null) 
                    {
                        currentPos = nextPos;
                        goodTile = true;
                    }
                    maxTries--;
                }

                if (tilemap.GetTile(new Vector3Int(currentPos.x, currentPos.y, 0)) != barrierTile)
                {
                    tilemap.SetTile(new Vector3Int(currentPos.x, currentPos.y, 0), null);
                }
                else
                {
                    Debug.Log("Wäre Barrier-Tile gewesen");
                }
            }
        }
    }

    public Vector2Int GetRandomDirection()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                return Vector2Int.up;
            case 1:
                return Vector2Int.down;
            case 2:
                return Vector2Int.left;
            case 3:
                return Vector2Int.right;
            default:
                return Vector2Int.up;
        }
    }

    public void SetStartAndEnd()
    {
        Vector2Int startPos = new Vector2Int(Random.Range(0, gridSizeX), Random.Range(0,gridSizeY));
        tilemap.SetTile(new Vector3Int(startPos.x, startPos.y, 0), null);
        noCollisionTileMap.SetTile(new Vector3Int(startPos.x, startPos.y, 0), start);
        tilemap.SetTile(new Vector3Int(startPos.x, startPos.y-1, 0), barrierTile);
        currentStartPosition = new Vector2(startPos.x+0.5f, startPos.y+0.5f);

        bool goodTile = false;
        int maxTries = gridSizeX * gridSizeY * 10;
        Vector2Int endPos = new Vector2Int(0,0);
        
        while (!goodTile && maxTries > 0)
        {
            endPos = new Vector2Int(Random.Range(0, gridSizeX), Random.Range(0,gridSizeY));

            float distance = Vector2Int.Distance(endPos, startPos);
            
            if (distance >= startToEndDistance.x && 
                distance <= startToEndDistance.y)
            {
                goodTile = true;
            }

            maxTries--;
        }
        tilemap.SetTile(new Vector3Int(endPos.x, endPos.y, 0), null);
        noCollisionTileMap.SetTile(new Vector3Int(endPos.x, endPos.y, 0), end);
        tilemap.SetTile(new Vector3Int(endPos.x, endPos.y-1, 0), barrierTile);
        Instantiate(exitDoor, new Vector3(endPos.x+0.5f, endPos.y+0.5f), Quaternion.identity);

    }
    
    public void SetRandomTiles()
    {
        int totalProbability = 0;

        goldProbability = blocks[3].probability;
        
        for (int i = 0; i < blocks.Count; i++)
        {
            totalProbability += blocks[i].probability;
            blocks[i].probability = totalProbability;
        }

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                
                if (tilemap.GetTile(new Vector3Int(x,y,0)) != null && 
                    tilemap.GetTile(new Vector3Int(x,y,0)) != barrierTile)
                {
                    int randomValue = Random.Range(0, totalProbability);

                    foreach (Blocks block in blocks)
                    {
                        if (randomValue <= block.probability)
                        {
                            tilemap.SetTile(new Vector3Int(x,y,0), block.tile);
                            break;
                        }
                    }
                }
            }
        }
    }

    public void ChanceGoldProbability()
    {
        int reduceAmount = goldProbability / 100 * goldChangeRate;
        goldProbability = goldProbability - reduceAmount;
        blocks[3].probability -= reduceAmount;
    }



}

[System.Serializable]
public class Blocks
{
    public Tile tile;
    public int probability;
    public float durability;
}

