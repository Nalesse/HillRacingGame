using System;
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

    public bool isDoingTrick;
    [SerializeField] private Animator animator;
    
    //singleton
    private static TrickSystem _instance;
    public static TrickSystem Instance => _instance;

    private string animatorBool;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        
        // Singleton setup
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }

        else
        {
            _instance = this;
        }
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
        animator.SetBool(animatorBool, false);
        Debug.Log(animatorBool + " Cooled");
        yield return new WaitForSeconds(.7f);
        isDoingTrick = false;
    }

}
