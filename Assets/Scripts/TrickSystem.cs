using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickSystem : MonoBehaviour
{

    public bool isDoingTrick;
    [SerializeField] private Animator animator;

    public string animatorBool;
    public bool isDoingTrickSmaller;

    public bool stopCooldown;
    
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
        isDoingTrickSmaller = true;
        animator.SetBool(animatorBool, true);

    }
    
    public IEnumerator CooldownTrick(string _animatorBool)
    {
        if (_animatorBool != animatorBool || Player.Instance.isGrounded) yield break;
        
        stopCooldown = true;
        Debug.Log("Cooling trick");
        animator.SetBool(animatorBool, false);
        isDoingTrickSmaller = false;
        yield return new WaitForSeconds(.5f);
        isDoingTrick = false;
        Debug.Log(animatorBool + " Cooled");
        stopCooldown = false;


    }

}
