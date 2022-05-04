using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Road
{
    public class PersonToBeHit : MonoBehaviour
    {
        public Animator anim;
        public ParticleSystem particle;
        [SerializeField] private int pointValue;
        private Score scoreScript;
        // Start is called before the first frame update
        void Start()
        {
            anim = gameObject.GetComponent<Animator>();
            particle = gameObject.GetComponent<ParticleSystem>();
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                scoreScript = GameObject.Find("PlayerScore").GetComponent<Score>();
            }
        
        }

        // Update is called once per frame
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                particle.Play();
                Debug.Log("Score!");
                scoreScript.PlayerScore += pointValue;

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
}
