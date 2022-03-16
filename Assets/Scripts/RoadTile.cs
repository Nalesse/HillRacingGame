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
    //[SerializeField] private Spawnable[] objectsToSpawn;

    #endregion

    #region Privite
    private GameObject spawnedObject;
    #endregion
    
    

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LevelGenerator.Instance.SpawnTile();
            Destroy(gameObject, 2);
        }
        
    }

    public void SpawnObjects(SpawnableObject spawnableObjectData)
    {
        var tileTransform = transform;
        var randomPos = tileTransform.position + spawnableObjectData.GenerateRandomPosition();

        spawnedObject = Instantiate(spawnableObjectData.prefab, randomPos, spawnableObjectData.prefab.transform.rotation);
        
        spawnedObject.transform.SetParent(tileTransform,true);

        AdjustPosition(spawnableObjectData);
    }

    private void AdjustPosition(SpawnableObject spawnableObjectData)
    {
        var spawnedObjectPosition = transform.position + spawnableObjectData.Offset;
        spawnedObject.transform.position = spawnedObjectPosition;

    }

    
}
