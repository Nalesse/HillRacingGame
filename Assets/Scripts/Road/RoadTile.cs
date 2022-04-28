using System;
using System.Collections;
using System.Collections.Generic;
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
        if (!other.CompareTag("Player")) return;
        
        if (!Player.Instance.gameOver)
        {
            LevelGenerator.Instance.SpawnObjects();
        }
            
        Destroy(gameObject, 2);

    }

    public void SpawnRoadObjects(SpawnableObject spawnableObjectData)
    {
        var tileTransform = transform;
        var randomPos = tileTransform.position;

        spawnedObject = Instantiate(spawnableObjectData.prefab, randomPos, spawnableObjectData.prefab.transform.rotation);
        spawnedObject.transform.SetParent(tileTransform,true);
        AdjustPosition(spawnableObjectData, spawnedObject);
        
    }

    public void SpawnCar(SpawnableObject[] carData)
    {
        for (int i = 0; i < carData.Length; i++)
        {
            var chanceToSpawn = 1 - carData[i].chanceToSpawn;
            if (Random.value > chanceToSpawn)
            {
                var spawnedCar = Instantiate(carData[i].prefab, transform.position, carData[i].prefab.transform.rotation);
                spawnedCar.transform.SetParent(transform, true);
                AdjustPosition(carData[i], spawnedCar);
                break;
            }
        }
        
        
        
    }
    

    private void AdjustPosition(SpawnableObject spawnableObjectData, GameObject spawnedGameObject)
    {
        // Makes sure object is positioned correctly at the center of the road  
        var objectPosition = transform.position + spawnableObjectData.Offset;

        //Once object is positioned object is given random position on road
        var randomPos = objectPosition + spawnableObjectData.GenerateRandomPosition();
        objectPosition = randomPos;
        spawnedGameObject.transform.position = objectPosition;
    }

    
}
