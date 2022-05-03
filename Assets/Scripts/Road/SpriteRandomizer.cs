using UnityEngine;

namespace Road
{
    public class SpriteRandomizer : MonoBehaviour
    {
        public Sprite[] spritePool;
        public SpriteRenderer spriteRendererA;
        public SpriteRenderer spriteRendererB;
        // Start is called before the first frame update
        void Start()
        {
            int spriteChosen = Random.Range(0, spritePool.Length);
            spriteRendererA.sprite = spritePool[spriteChosen];
            spriteRendererB.sprite = spritePool[spriteChosen];
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
