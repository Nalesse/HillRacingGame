using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonToBeHit : MonoBehaviour
{
    public Animator anim;
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        particle = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            particle.Play();

            if (other.transform.position.x > gameObject.transform.position.x)
            {
                anim.SetBool("HitLeft", true);
            }
            else
            {
                anim.SetBool("HitRight", true);
            }
        }
    }
}
