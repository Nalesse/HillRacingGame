using UnityEngine;

namespace Road.Road_Objects
{
    public class DoesPedestrianAppear : MonoBehaviour
    {
        public int chanceToAppear;
        private int rollForAppearing;
        // Start is called before the first frame update
        void Start()
        {
            rollForAppearing = Random.Range(0, chanceToAppear);
            if(rollForAppearing != 0)
            {
                gameObject.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
