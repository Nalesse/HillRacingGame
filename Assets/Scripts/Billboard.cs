using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour,ICollidable
{
    [SerializeField] private GameObject billBoardPlane;
    [SerializeField] private ParticleSystem particles;
    private int randomNumber;
    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(0, 10);
        if(randomNumber >= 1)
        {
            gameObject.SetActive(false);
        }
    }


    public void CollisionAction()
    {
        particles.GetComponent<ParticleSystemRenderer>().material = billBoardPlane.GetComponent<MeshRenderer>().material;
        billBoardPlane.SetActive(false);
        particles.Play();
    }
}
