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
        public AudioClip[] shrieks;
        public AudioSource audioSource;

        // Start is called before the first frame update
        void Start()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
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
                audioSource.PlayOneShot(shrieks[Random.Range(0, shrieks.Length)]);
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
