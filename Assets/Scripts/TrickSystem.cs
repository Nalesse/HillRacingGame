using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickSystem : MonoBehaviour
{

    public bool isDoingTrick;
    [SerializeField] private Animator animator;

    public string animatorBool;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        
        
    }


    public void DoTrick(string _animatorBool)
    {
        
        if (isDoingTrick || Player.Instance.isGrounded) {return;}

        animatorBool = _animatorBool;
        Debug.Log("Performing trick: " + animatorBool);
        isDoingTrick = true;
        animator.SetBool(animatorBool, true);

    }
    
    public IEnumerator CooldownTrick(string _animatorBool)
    {

        if (_animatorBool == animatorBool)
        {
            if (!Player.Instance.isGrounded)
            {
                animator.SetBool(animatorBool, false);
                yield return new WaitForSeconds(.5f);

                isDoingTrick = false;
                Debug.Log(animatorBool + " Cooled");

            }
        }
        
        
    }

}
