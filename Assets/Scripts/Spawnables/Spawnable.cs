using System;
using UnityEngine;
using Random = UnityEngine.Random;

// ReSharper disable IdentifierTypo
namespace Spawnables 
    // ReSharper restore IdentifierTypo
{
    [CreateAssetMenu(fileName = "New Spawnable", menuName = "Spawnable")]
    public class Spawnable : ScriptableObject
    {
        #region Public
        public Vector3 positionOffset;
        public GameObject prefab;
        public float chanceToSpawn;

        [Header("Randomness")]
        public float minX;
        public float maxX;
        // public float minZ, maxZ;
        #endregion

        public Vector3 GenerateRandomPosition()
        {
            var randomPos = new Vector3
            {
                x = Random.Range(minX, maxX),
                //Can't use z until I find a way to make the object match the slope angel in every situation 
                // z = Random.Range(minZ, maxZ)
            };

            return randomPos;
        }
    }

    
}
