using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Road
{
    [Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab;
        public Vector3 Offset;
        [Range(0.0f, 1.0f)]
        public float chanceToSpawn;
        [Header("Randomness")]
        [Range(-8.609f, -2.08f)]
        public float xMin;
        [Range(2.08f, 8.609f)]
        public float xMax;
        [Space]
        [Range(-66.65f, 0)]
        public float zMin;
        [Range(0,66.65f)]
        public float zMax;
        [Range(0.0f, -10)]
        public float yMin;
        [Range(0.0f, 10)]
        public float yMax;
    
        [Header("Disallowed Spawn Range")]
        [Range(-1.92f, -1.38f)]
        public float disallowedXMin;
        [Range(1.38f, 1.92f)]
        public float disallowedXMax;

        public Vector3 GenerateRandomPosition()
        {
            // Generates a random position to start with
            var randomPos = GetRandomVector3(xMin, xMax, zMin, zMax, yMin, yMax);

            // if the random position is in the disallowed spawn range then a new position is generated until it is
            // no longer is within the spawn range
            while (randomPos.x >= disallowedXMin && randomPos.x <= disallowedXMax)
            {
                randomPos = GetRandomVector3(xMin, xMax, zMin, zMax, yMin, yMax);
            }

            return randomPos;

        }

        // Helper function to avoid repeated code
        private Vector3 GetRandomVector3(float _xMin, float _xMax, float _zMin, float _zMax, float _yMin, float _yMax)
        {
            var randomVector3 = new Vector3
            {
                x = Random.Range(_xMin, _xMax),
                z = Random.Range(_zMin, _zMax),
                y = Random.Range(_yMin, _yMax)
            };

            return randomVector3;
        }

    
    }

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
        private float roadSlopeAngle = 0;
        private SpawnableObject spawnedObjectData;
        #endregion

        #region Inspector Fields
        [SerializeField] private GameObject[] roadTiles;
        [SerializeField] private int tilesToPreSpawn;
        [FormerlySerializedAs("shittyCar")] [SerializeField] private SpawnableObject[] shittyCars;
        [SerializeField] private SpawnableObject[] aerialObjects;
        [FormerlySerializedAs("SpawnableObjects")] [SerializeField] private SpawnableObject[] roadObjects;

        #endregion

    

    
    
        public void SpawnObjects()
        {
            int spawnIndex = Random.Range(0, roadTiles.Length);

            // Setup for Spawning Road objects

            //Spawns a tile and sets the parent to the container. Then preforms setup for the next tile to be spawned
            spawnedTile = Instantiate(roadTiles[spawnIndex], nextSpawnPoint, Quaternion.identity);
            spawnedTile.transform.SetParent(roadTileContainer.transform, false);
            col = spawnedTile.transform.GetChild(0).GetComponent<BoxCollider>();
        
            var roadTileScript = spawnedTile.GetComponent<RoadTile>();
        
            // loops through all the spawnable objects and checks the chance to spawn.
            //if random.value is greater then the chance to spawn then the object gets spawned
            for (int i = 0; i < roadObjects.Length; i++)
            {
                var chanceToSpawn = 1 - roadObjects[i].chanceToSpawn;
                if (Random.value > chanceToSpawn)
                {
                    spawnedObjectData = roadObjects[i];
                    roadTileScript.SpawnRoadObjects(spawnedObjectData);
                    break;
                }
            }

            for (int i = 0; i < aerialObjects.Length; i++)
            {
                var chanceToSpawn = 1 - aerialObjects[i].chanceToSpawn;
                if (Random.value > chanceToSpawn)
                {
                    spawnedObjectData = aerialObjects[i];
                    roadTileScript.SpawnRoadObjects(spawnedObjectData);
                    break;
                }
            }
        
            roadTileScript.SpawnCar(shittyCars);
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
                if (i >= 3)
                {
                    SpawnObjects();
                }
            
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
}