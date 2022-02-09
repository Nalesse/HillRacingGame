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
        // gives a percent chance to run function. The formula to determine the percent is 1 - percent.
        // For example to give a 30% chance you would do 1 - 0.3 which is 0.7
        if (Random.value > 0.7)
        {
            SpawnObjects();
        }
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
        var spawnIndex = Random.Range(0, objectsToSpawn.Length);
        var tileTransform = transform;

        var spawnedObject = Instantiate(objectsToSpawn[spawnIndex], tileTransform.position, objectsToSpawn[spawnIndex].transform.rotation);
        
        // Fixes Scale
        // var originalScale = tileTransform.localScale;
        spawnedObject.transform.SetParent(tileTransform,true);
        // spawnedObject.transform.localScale = originalScale;
        
        // Adjust object position
        var spawnedObjectPosition = spawnedObject.transform.position;
        var spawnedObjectCol = spawnedObject.GetComponent<BoxCollider>();
        spawnedObjectPosition.y += spawnedObjectCol.bounds.size.y + 0.59f;
        spawnedObject.transform.position = spawnedObjectPosition;
    }
}
