using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
    #endregion

    #region Inspector Fields

    [SerializeField] private GameObject roadTile;
    [SerializeField] private int tilesToPreSpawn;
    [SerializeField] private float roadSlopeAngle;
    #endregion

    
    
    public void SpawnTile()
    {
        //Spawns a tile and sets the parent to the container. Then preforms setup for the next tile to be spawned
        spawnedTile = Instantiate(roadTile, nextSpawnPoint, Quaternion.identity);
        spawnedTile.transform.SetParent(roadTileContainer.transform, false);
        col = spawnedTile.GetComponentInChildren<BoxCollider>();
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
        
        nextSpawnPoint.z = currentTilePosition.z + col.bounds.size.z;

        return nextSpawnPoint;
    }

    private void SetRotation(GameObject objectToRotate, float angle, Vector3 direction)
    {
        objectToRotate.transform.rotation = Quaternion.AngleAxis(angle, direction);
    }
}
