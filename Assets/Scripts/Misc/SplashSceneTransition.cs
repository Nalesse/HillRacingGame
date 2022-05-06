using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSceneTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SceneChanger());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator SceneChanger() 
    {
        yield return new WaitForSeconds(16.0f);
        SceneManager.LoadScene(1);
    }
}
