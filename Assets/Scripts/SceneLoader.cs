using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Image LoadingBar;

    // Start is called before the first frame update
    void Start()
    {
        //start async operation
        StartCoroutine(LoadAsyncOperation());
    }

    // Update is called once per frame
    IEnumerator LoadAsyncOperation()
    {
        //create async op.
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(2);
        while (gameLevel.progress < 1)
        {
            //take progress bar fill = async op. progress
            LoadingBar.fillAmount = gameLevel.progress;
            //when finished - load the game scene
            yield return new WaitForEndOfFrame();
        }
        
    }
}
