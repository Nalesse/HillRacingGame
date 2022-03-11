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

        [SerializeField] private float[] xPositions;
        #endregion

        public Vector3 GenerateRandomPosition()
        {
            int index = Random.Range(0, xPositions.Length);
            var randomPos = new Vector3
            {
                x = xPositions[index]
            };

            return randomPos;
        }
    }

    
}
