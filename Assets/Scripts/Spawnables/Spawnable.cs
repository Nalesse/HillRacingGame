using System;
using UnityEngine;

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
        public float minX, maxX;
        public float minY, maxY;
        public float minZ, maxZ;
        #endregion

        public Vector3 GenerateRandomPosition()
        {
            var randomPos = new Vector3();

            randomPos.x = UnityEngine.Random.Range(minX, minX);
            randomPos.y = UnityEngine.Random.Range(minY, maxY);
            randomPos.z = UnityEngine.Random.Range(minZ, maxZ);

            return randomPos;
        }
    }
}
