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
        #endregion
    }
}
