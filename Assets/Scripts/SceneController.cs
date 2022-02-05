using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginGame();
    {
        SceneManagement.LoadScene("Kcamp");
    }

    public void GoToSceneB();
    {
        SceneManagement.LoadScene(SceneB);
    }

    public void GoToSceneC();
    {
        SceneManagement.LoadScene(SceneC);
    }

    public void ReturnToMenu();
    {
        SceneManagement.LoadScene(SceneA);
    }
}
