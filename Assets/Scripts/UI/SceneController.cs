using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SceneController : MonoBehaviour
    {
        private Controls controls;

        private void OnEnable()
        {
            controls.UI.Enable();
        }

        private void OnDisable()
        {
            controls.UI.Disable();
        }

        private void Awake()
        {
            controls = new Controls();

            controls.UI.Cancel.performed += ctx => ReturnToMenu();
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        }

        private void ReturnToMenu()
        {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                SceneManager.LoadScene(1);
            }
            
        }

    }
}
