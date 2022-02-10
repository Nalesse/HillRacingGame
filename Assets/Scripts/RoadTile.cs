using System;
using System.Collections;
using System.Collections.Generic;
using Spawnables;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadTile : MonoBehaviour
{
    #region Inspector Fields
    // Each object is a scriptable object so that the object specific data is not bound to this script
    // The reason for this is so that I don't have to write an if statement for every object that we might want to spawn.
    [SerializeField] private Spawnable[] objectsToSpawn;

    #endregion

    #region Privite
    private GameObject spawnedObject;
    private int spawnIndex;
    #endregion
    

    private void Start()
    {
        spawnIndex = Random.Range(0, objectsToSpawn.Length);
        
        //The formula to determine the percent is 1 - percent,
        //For example to give a 30% chance you would do 1 - 0.3 which is 0.7
        // This action is done automatically because it is a bit weird to have to put 0.7 for 30% in the inspector 
        var chanceToSpawn = 1 - objectsToSpawn[spawnIndex].chanceToSpawn;
        
        // gives a percent chance to run function. The percent is stored in the scriptable object 
        if (Random.value > chanceToSpawn)
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
        var tileTransform = transform;
        
        spawnedObject = Instantiate(objectsToSpawn[spawnIndex].prefab, tileTransform.position, 
            objectsToSpawn[spawnIndex].prefab.transform.rotation);
        
        // Fixes Scale
        // var originalScale = tileTransform.localScale;
        spawnedObject.transform.SetParent(tileTransform,true);
        // spawnedObject.transform.localScale = originalScale;
        
        AdjustPosition();
    }

    private void AdjustPosition()
    {
        var spawnedObjectPosition = spawnedObject.transform.position;
        var spawnedObjectCol = spawnedObject.GetComponent<BoxCollider>();
        spawnedObjectPosition.y += spawnedObjectCol.bounds.size.y + objectsToSpawn[spawnIndex].positionOffset;
        spawnedObject.transform.position = spawnedObjectPosition;
    }

    
}
