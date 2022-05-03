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

        //private IEnumerator Start()
        //{
        // yield return new WaitForSeconds(3.0f);
        // SceneManager.LoadScene(1);
        //}

    }
}
