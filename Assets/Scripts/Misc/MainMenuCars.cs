using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCars : MonoBehaviour
{
    public GameObject[] carPrefabs;
    public GameObject[] carPrefabs2;
    public int carIndex;
    public int carIndex2;
    private int spawnInterval = 2;
    public int spawnPosXleft = 80;
    public int spawnPosXright = -80;
    private int spawnRangeZ = 146;
    private int spawnRangeotherZ = 135;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCarLeft", 0, spawnInterval);
        InvokeRepeating("SpawnCarRight", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
 
    }
    
    void SpawnCarLeft()
    {
        int carIndex =  Random.Range(0, carPrefabs.Length);
        Vector3 spawnpos = new Vector3(spawnPosXleft, -3 , Random.Range(spawnRangeZ, spawnRangeotherZ));
        Instantiate(carPrefabs[carIndex], spawnpos, carPrefabs[carIndex].transform.rotation);

    }

    void SpawnCarRight()
    {
        int carIndex2 = Random.Range(0, carPrefabs2.Length);
        Vector3 spawnpos = new Vector3(spawnPosXright, -3, Random.Range(spawnRangeZ, spawnRangeotherZ));
        Instantiate(carPrefabs2[carIndex2], spawnpos, carPrefabs2[carIndex2].transform.rotation);

    }
}
