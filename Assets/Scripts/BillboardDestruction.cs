using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardDestruction : MonoBehaviour
{
    public GameObject billBoardPlane;
    public ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            particles.GetComponent<ParticleSystemRenderer>().material = billBoardPlane.GetComponent<MeshRenderer>().material;
            billBoardPlane.SetActive(false);
            particles.Play();
        }
    }
}
