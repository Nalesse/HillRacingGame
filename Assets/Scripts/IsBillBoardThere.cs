using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBillBoardThere : MonoBehaviour, ICollidable
{
    public int randomNumber;
    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(0, 5);
        if(randomNumber >= 1)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollisionAction()
    {
        Debug.Log("Billboard hit");
        
        // move particle effects here
    }
}
