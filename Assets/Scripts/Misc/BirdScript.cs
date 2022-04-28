using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
  private int spawnInterval = 6;
  private float spawnRangeX = -27.5f;
  private float spawnRangeotherX = 38.1f;
  private float spawnRangeY = 72.0f;
  private float spawnRangeotherY = 25.1f;
  public GameObject birdy;
 // Start is called before the first frame update
  void Start()
  {
     InvokeRepeating("SpawnBirdy", 0, spawnInterval);
  }

// Update is called once per frame
  void Update()
  {

  }

  void SpawnBirdy()
  {
     Vector3 spawnpos = new Vector3(Random.Range(spawnRangeX, spawnRangeotherX), Random.Range(spawnRangeY, spawnRangeotherY), 600);
     Instantiate(birdy, spawnpos, birdy.transform.rotation);

  }


}
