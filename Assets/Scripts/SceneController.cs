using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

    }

    //private IEnumerator Start()
    //{
       // yield return new WaitForSeconds(3.0f);
       // SceneManager.LoadScene(1);
    //}

}
