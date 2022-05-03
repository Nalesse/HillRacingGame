using UnityEngine;

namespace Misc
{
    public class LookAt : MonoBehaviour
    {
        Vector3 playerPos;
        public Vector3 offset;

        public GameObject lookAtPoint;
    




        // Start is called before the first frame update
        void Start()
        {
      
        }

        // Update is called once per frame
        void Update()
        {

            playerPos = Player.Player.Instance.transform.position;


            lookAtPoint.transform.position = playerPos + offset;

        }
    }
}
