using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickSystem : MonoBehaviour
{

    public bool isDoingTrick;
    [SerializeField] private Animator animator;

    private string animatorBool;
    
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
    
    public IEnumerator CooldownTrick()
    {
        if (!Player.Instance.isGrounded)
        {
            yield return new WaitForSeconds(.7f);
            animator.SetBool(animatorBool, false);
            isDoingTrick = false;
            Debug.Log(animatorBool + " Cooled");
           
        }
        
    }

}
