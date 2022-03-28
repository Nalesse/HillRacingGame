using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickSystem : MonoBehaviour
{
    Player player;

    public Animator animator;

    public bool isTrick;

    private void Awake()
    {
        
    }


    public void StartTrick()
    {
        StartCoroutine(Trick());
    }

    public void EndTrick()
    {
        StartCoroutine(TrickCoolDown());
    }
    
    IEnumerator Trick()
    {
        if (player.isGrounded == false && player.isTrick == false)
        {
            if (player.northTrick)
            {
                isTrick = true;
                yield return new WaitForSeconds(.7f);
                animator.SetBool("Ntrick", true);
            }



        }


    }

    IEnumerator TrickCoolDown()
    {
        if (player.isGrounded == false)
        {

            if(player.northTrick == true && player.eastTrick == false)
            {
                animator.SetBool("Ntrick", false);
                Debug.Log("start cooldown");


                //this is cooldown time for trick
                yield return new WaitForSeconds(.7f);
                player.northTrick = false;
                Debug.Log("Trickcooled");

                player.northTrick = false;
                isTrick = false;
            }



        }
    }

}
