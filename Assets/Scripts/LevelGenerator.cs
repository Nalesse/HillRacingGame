using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    #region Public
    public static LevelGenerator Instance { get; private set; }
    #endregion

    #region Private

    private Collider col;
    private GameObject spawnedTile;
    private Vector3 nextSpawnPoint;
    private GameObject roadTileContainer;
    // Please do not touch this unless it is absolutely necessary. if this value is changed then the position offsets
    // and rotations for all the spawnable objects will need to be readjusted  
    private float roadSlopeAngle = 10;
    #endregion

    #region Inspector Fields
    //TODO: When we do biomes this will need to be changed to support 2 levels of random, random biome and then whithin that biome a random tile.
    // This will be done with scriptiple objects, the biome will be a scriptiple object each one will have its own array of tiles
    [SerializeField] private GameObject[] roadTiles;
    [SerializeField] private int tilesToPreSpawn;
     
    #endregion

    

    
    
    public void SpawnTile()
    {
        int spawnIndex = UnityEngine.Random.Range(0, roadTiles.Length);

        //Spawns a tile and sets the parent to the container. Then preforms setup for the next tile to be spawned
        spawnedTile = Instantiate(roadTiles[spawnIndex], nextSpawnPoint, Quaternion.identity);
        spawnedTile.transform.SetParent(roadTileContainer.transform, false);
        col = spawnedTile.transform.GetChild(0).GetComponent<BoxCollider>();
        nextSpawnPoint = CalculateNextSpawnPoint();
    }
    
    
    private void Awake()
    {
        // Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    
    private void Start()
    {
        roadTileContainer = new GameObject
        {
            name = "RoadTileContainer"
        };

        for (int i = 0; i < tilesToPreSpawn; i++)
        {
            SpawnTile();
        }
        // Sets the rotation of the container, which also rotates the tiles
        SetRotation(roadTileContainer, roadSlopeAngle, Vector3.right);
    }

    
    // Helper Functions
    private Vector3 CalculateNextSpawnPoint()
    {
        // localPosition is used so that the tiles position is local to that of the container
        Vector3 currentTilePosition = spawnedTile.transform.localPosition;

        nextSpawnPoint.y = currentTilePosition.y- 0.02f;
        nextSpawnPoint.z = currentTilePosition.z + col.bounds.size.z;

        return nextSpawnPoint;
    }

    private void SetRotation(GameObject objectToRotate, float angle, Vector3 direction)
    {
        objectToRotate.transform.rotation = Quaternion.AngleAxis(angle, direction);
    }
}
