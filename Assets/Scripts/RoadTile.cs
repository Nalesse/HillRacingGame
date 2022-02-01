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
        /*float random = Random.Range(0f, 1f);
        
        var format = string.Format("0.0", random);
        random = float.Parse(format);

        if (random < 0.2)
        {
            SpawnObjects();
        }*/
        
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
        int spawnIndex = Random.Range(0, objectsToSpawn.Length);
        var tileTransform = transform;
        Instantiate(objectsToSpawn[spawnIndex], tileTransform.position, objectsToSpawn[spawnIndex].transform.localRotation,
            tileTransform);
    }
}
