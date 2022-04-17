using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialObject : MonoBehaviour,ICollidable
{
    
    public void CollisionAction()
    {
        //Replace this with something better later
        Destroy(gameObject);
    }
}
