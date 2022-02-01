using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadTile : MonoBehaviour
{
    #region Inspector Fields

    [SerializeField] private GameObject[] objectsToSpawn;

    #endregion

    private void Start()
    {
       //SpawnObjects();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LevelGenerator.Instance.SpawnTile();
            Destroy(gameObject, 2);
        }
        
    }

    private void SpawnObjects()
    {
        //TODO: fix scaling issues 
        int spawnIndex = Random.Range(0, objectsToSpawn.Length);
        var tileTransform = transform;
        var spawnedObject = Instantiate(objectsToSpawn[spawnIndex], tileTransform, false);
        spawnedObject.transform.position = tileTransform.position;
    }
}
