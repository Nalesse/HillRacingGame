using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBillboardPicker : MonoBehaviour
{
    public Material[] material;
    public GameObject billboard;
    // Start is called before the first frame update
    void Start()
    {
        billboard = gameObject;
        billboard.gameObject.GetComponent<MeshRenderer>().material = material[Random.Range(0, material.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
