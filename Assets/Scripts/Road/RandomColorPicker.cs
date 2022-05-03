using UnityEngine;

namespace Road
{
    public class RandomColorPicker : MonoBehaviour
    {
        public Color[] colorPool;
        public SpriteRenderer spriteRenderer;
        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = colorPool[Random.Range(0,colorPool.Length)];
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
