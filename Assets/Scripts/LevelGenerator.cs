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
    #endregion

    #region Inspector Fields

    [SerializeField] private GameObject roadTile;
    [SerializeField] private int tilesToPreSpawn;

    #endregion


    public void SpawnTile()
    {
        spawnedTile = Instantiate(roadTile, nextSpawnPoint, Quaternion.identity);
        col = spawnedTile.GetComponentInChildren<BoxCollider>();
        nextSpawnPoint = CalculateNextSpawnPoint();
    }

    private void Start()
    {
        for (int i = 0; i < tilesToPreSpawn; i++)
        {
            SpawnTile();
        }
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

    private Vector3 CalculateNextSpawnPoint()
    {
        Vector3 currentTilePosition = spawnedTile.transform.position;

        nextSpawnPoint.x = currentTilePosition.x;
        nextSpawnPoint.y = currentTilePosition.y;
        nextSpawnPoint.z = currentTilePosition.z + col.bounds.size.z;

        return nextSpawnPoint;
    }
}
