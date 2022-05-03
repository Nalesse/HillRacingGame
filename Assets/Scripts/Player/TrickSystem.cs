using System.Collections;
using UnityEngine;

namespace Player
{
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
            isDoingTrick = true;
            isDoingTrickSmaller = true;
            animator.SetBool(animatorBool, true);

        }
    
        public IEnumerator CooldownTrick(string _animatorBool)
        {
            if (_animatorBool != animatorBool || Player.Instance.isGrounded) yield break;
        
            stopCooldown = true;
            animator.SetBool(animatorBool, false);
            isDoingTrickSmaller = false;
            yield return new WaitForSeconds(.10f);
            isDoingTrick = false;
            stopCooldown = false;


        }

    }
}
