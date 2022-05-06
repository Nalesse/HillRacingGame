using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SceneController : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
