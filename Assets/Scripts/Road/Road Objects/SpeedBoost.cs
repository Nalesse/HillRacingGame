using UnityEngine;

namespace Road.Road_Objects
{
    public class SpeedBoost : MonoBehaviour
    {
        [field: SerializeField] protected float speedBoost;
        protected AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (Player.Player.Instance.gameOver) return;
            
                Player.Player.Instance.speed = speedBoost;
                audioSource.Play();
            }
        }
    }
}
