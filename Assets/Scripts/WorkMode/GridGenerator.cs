using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
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
    public Dictionary<Vector3Int, int> blockGridDurabilityDictionary = new Dictionary<Vector3Int, int>();
    
    [Header("Walker")] 
    public int walkerAmount = 5;
    public int walkerRange = 8;
    public Vector2Int steps = new Vector2Int(3,10);

    [Header("Start")] 
    public Tile start;
    public Tile end;
    public Vector2Int startToEndDistance = new Vector2Int(14,16);
    public GameObject exitDoor;

    [Header("MinecartStation")]
    public GameObject minecartStation;
    public Tile tntTile;
    public Tile minecartStationTile;
    
    [Header("Tnt")]
    public GameObject tntDeathCollider;
    public GameObject tntAnimation;
    
    [Header("UI")]
    public UIController uIController;
    public TextMeshProUGUI uIGridNumber;
    
    //Private Variablen
    private Vector2 currentStartPosition;
    private Vector2Int station1Pos;
    private Vector2Int station2Pos;
    private Vector3 middleBlockPos;

    private void Start()
    {
        LoadGrid();
        GameManager.instance.ClearBlocksInInv();
        GameManager.instance.ClearGoldMined();
        uIController.UpdateBlocksInInv();
        uIController.UpdateGoldMined();
    }

    public void LoadGrid()
    {
        currentGridNumber++;
        if (currentGridNumber > 3)
        {
            SceneManager.LoadScene("Home_Scene");
            return;
        }

        uIGridNumber.text = (currentGridNumber+"/3");
        tilemap.ClearAllTiles();
        noCollisionTileMap.ClearAllTiles();
        SetUpGrid();
        PlaceCorridor();
        SetStartAndEnd();
        if (GameManager.instance.currentDay >= 2)
            SetMineCartTiles();
        SetRandomTiles();
        if (GameManager.instance.currentDay >= 4)
            SetTNTTiles();
        FindObjectOfType<PlayerInputScript>().transform.position = currentStartPosition;
        ChanceGoldProbability();
        KillGoldNuggets();
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

    public void SetMineCartTiles()
    {
        bool station1PosFound = false;
        int maxStation1Tries = gridSizeX * gridSizeY * 10;

        while (!station1PosFound && maxStation1Tries > 0)
        {
            station1Pos = new Vector2Int(Random.Range(0, gridSizeX), Random.Range(0,gridSizeY));
            if (tilemap.GetTile(new Vector3Int(station1Pos.x,station1Pos.y,0)) != barrierTile &&
                noCollisionTileMap.GetTile(new Vector3Int(station1Pos.x,station1Pos.y,0)) != start &&
                noCollisionTileMap.GetTile(new Vector3Int(station1Pos.x,station1Pos.y-1,0)) != start &&
                noCollisionTileMap.GetTile(new Vector3Int(station1Pos.x,station1Pos.y,0)) != end &&
                noCollisionTileMap.GetTile(new Vector3Int(station1Pos.x,station1Pos.y-1,0)) != end)
            {
                tilemap.SetTile(new Vector3Int(station1Pos.x, station1Pos.y, 0), null);
                noCollisionTileMap.SetTile(new Vector3Int(station1Pos.x, station1Pos.y, 0), minecartStationTile);
                tilemap.SetTile(new Vector3Int(station1Pos.x, station1Pos.y-1, 0), barrierTile);
                Instantiate(minecartStation, new Vector3(station1Pos.x+0.5f, station1Pos.y+0.5f), Quaternion.identity);
                station1PosFound = true;
            }
            maxStation1Tries--;
        }
        
        
        bool goodTile = false;
        int maxDistanceTries = gridSizeX * gridSizeY * 10;
        station2Pos = new Vector2Int(0,0);
        
        while (!goodTile && maxDistanceTries > 0)
        {
            station2Pos = new Vector2Int(Random.Range(0, gridSizeX), Random.Range(0,gridSizeY));

            float distance = Vector2Int.Distance(station2Pos, station1Pos);
            
            if (distance >= startToEndDistance.x && 
                distance <= startToEndDistance.y)
            {
                goodTile = true;
            }

            maxDistanceTries--;
        }
        
        bool station2PosFound = false;
        int maxStation2Tries = gridSizeX * gridSizeY * 10;

        while (!station2PosFound && maxStation2Tries > 0)
        {
            if (tilemap.GetTile(new Vector3Int(station1Pos.x,station1Pos.y,0)) != barrierTile &&
                noCollisionTileMap.GetTile(new Vector3Int(station1Pos.x,station1Pos.y,0)) != start &&
                noCollisionTileMap.GetTile(new Vector3Int(station1Pos.x,station1Pos.y-1,0)) != start &&
                noCollisionTileMap.GetTile(new Vector3Int(station1Pos.x,station1Pos.y,0)) != end &&
                noCollisionTileMap.GetTile(new Vector3Int(station1Pos.x,station1Pos.y-1,0)) != end)
            {
                tilemap.SetTile(new Vector3Int(station2Pos.x, station2Pos.y, 0), null);
                noCollisionTileMap.SetTile(new Vector3Int(station2Pos.x, station2Pos.y, 0), minecartStationTile);
                tilemap.SetTile(new Vector3Int(station2Pos.x, station2Pos.y-1, 0), barrierTile);
                Instantiate(minecartStation, new Vector3(station2Pos.x+0.5f, station2Pos.y+0.5f), Quaternion.identity);
                station2PosFound = true;
            }

            maxStation2Tries--;
        }
        
    }
    
    public void SetRandomTiles()
    {
        int totalProbability = 0;
        

        if (blocks[3].probability != 100)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                totalProbability += blocks[i].probability;
                blocks[i].probability = totalProbability;
            }
        }
        else
        {
            totalProbability = 100;
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
                            blockGridDurabilityDictionary[new Vector3Int(x, y, 0)] = block.maxDurability;
                            break;
                        }
                    }
                }
            }
        }
    }
    
    public void SetTNTTiles()
    {
        for (int i = 0; i < Random.Range(1,4); i++)
        {
            bool tntPosFound = false;
            int maxStation1Tries = gridSizeX * gridSizeY * 10;

            while (!tntPosFound && maxStation1Tries > 0)
            {
                Vector2Int tntPos = new Vector2Int(Random.Range(0, gridSizeX), Random.Range(0,gridSizeY));
                if (tilemap.GetTile(new Vector3Int(tntPos.x,tntPos.y,0)) != barrierTile &&
                    noCollisionTileMap.GetTile(new Vector3Int(tntPos.x,tntPos.y,0)) != start &&
                    noCollisionTileMap.GetTile(new Vector3Int(tntPos.x,tntPos.y,0)) != end &&
                    noCollisionTileMap.GetTile(new Vector3Int(tntPos.x,tntPos.y,0)) != minecartStationTile)
                {
                    tilemap.SetTile(new Vector3Int(tntPos.x, tntPos.y, 0), null);
                    tilemap.SetTile(new Vector3Int(tntPos.x, tntPos.y, 0), tntTile);
                    tntPosFound = true;
                }
            }
        }
    }

    public void ChanceGoldProbability()
    {
        float cleanGoldProbability = blocks[3].probability - blocks[2].probability;
        float reduceCleanGoldProbability = (cleanGoldProbability / 100) * goldChangeRate;
        blocks[2].probability += Mathf.RoundToInt(reduceCleanGoldProbability);
        blocks[3].probability = 100;
        //TODO 100% Modular machen
    }

    public void KillGoldNuggets()
    {
        GoldNugget[] goldNuggetsLeftInMine = FindObjectsOfType<GoldNugget>();

        foreach (GoldNugget goldNugget in goldNuggetsLeftInMine)
        {
            Destroy(goldNugget.GetComponentInParent<SpriteRenderer>().gameObject);
            Debug.Log("NuggetDestroyed");
        }
    }


    public IEnumerator IgniteTNT(Vector3Int mousePos2d)
    {
        tilemap.SetTile(new Vector3Int(mousePos2d.x, mousePos2d.y, 0), null);
        
        Instantiate(tntAnimation, new Vector3(mousePos2d.x + 0.5f, mousePos2d.y + 0.5f, 0), Quaternion.identity);
        
        yield return new WaitForSeconds(3);
        
        Instantiate(tntDeathCollider, new Vector3(mousePos2d.x+0.5f, mousePos2d.y+0.5f), Quaternion.identity);
        
        noCollisionTileMap.SetTile(new Vector3Int(mousePos2d.x, mousePos2d.y, 0), null);
        
        CheckTileToDestroy(new Vector3Int(mousePos2d.x + 1, mousePos2d.y + 1, 0));
        
        CheckTileToDestroy(new Vector3Int(mousePos2d.x, mousePos2d.y+1, 0));
        
        CheckTileToDestroy(new Vector3Int(mousePos2d.x-1, mousePos2d.y+1, 0));
        
        CheckTileToDestroy(new Vector3Int(mousePos2d.x+1, mousePos2d.y, 0));
        
        CheckTileToDestroy(new Vector3Int(mousePos2d.x-1, mousePos2d.y, 0));
        
        CheckTileToDestroy(new Vector3Int(mousePos2d.x+1, mousePos2d.y-1, 0));
        
        CheckTileToDestroy(new Vector3Int(mousePos2d.x, mousePos2d.y-1, 0));
        
        CheckTileToDestroy(new Vector3Int(mousePos2d.x - 1, mousePos2d.y - 1, 0));
    }

    public void CheckTileToDestroy(Vector3Int tileToCheck)
    {
        
        if (tilemap.GetTile(tileToCheck) !=  barrierTile)
        {
            if (tilemap.GetTile(tileToCheck) !=  tntTile)
            {
                if (tilemap.GetTile(tileToCheck) != blocks[3].tile)
                {
                    tilemap.SetTile(tileToCheck, null);
                }
                else
                {
                    int rdmNuggetCount = Random.Range(1, 5);

                    for (int i = 0; i < rdmNuggetCount; i++)
                    {
                        middleBlockPos = new Vector3(tileToCheck.x + Random.Range(0.3f, 0.7f), tileToCheck.y + Random.Range(0.3f, 0.7f), 0);
                        
                        tilemap.SetTile(tileToCheck,null);
                        Instantiate(FindObjectOfType<MiningSystem>().goldNugget, middleBlockPos, Quaternion.identity);
                        i++;
                        //TODO Modular machen -> In Miningsystem evtl eine Funktion erstellen
                    }
                }
            }
            else
            {
                StartCoroutine(IgniteTNT(tileToCheck));
            }
        }
    }

}

[System.Serializable]
public class Blocks
{
    public Tile tile;
    public int probability;
    public int maxDurability;
}

