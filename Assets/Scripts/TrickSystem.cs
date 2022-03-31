using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Trick
{
    public bool NorthTrick;
    public bool EastTrick;
    public bool SouthTrick;
}


public class TrickSystem : MonoBehaviour
{
    //Player player;

    public Animator animator;

    //trick delegate
    

    //public bool isTrick;

    private void Awake()
    {

    }




    IEnumerator TrickCooldown(string animatorBool)
    {
        if (!Player.Instance.isGrounded)
        {
            animator.SetBool(animatorBool, false);
            Debug.Log("start cooldown");

            //this is cooldown time for trick
            yield return new WaitForSeconds(.7f);

            Debug.Log("Trickcooled");

            Player.Instance.isTrick = false;
        }
    }
}
