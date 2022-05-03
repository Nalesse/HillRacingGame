using UnityEngine;

namespace Road.Road_Objects
{
    public class AerialObject : MonoBehaviour,ICollidable
    {
    
        public void CollisionAction()
        {
            //Replace this with something better later
            Destroy(gameObject);
        }
    }
}
