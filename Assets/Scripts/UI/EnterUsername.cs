using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UI
{
    public class EnterUsername : MonoBehaviour
    {
        [SerializeField] private TMP_InputField userNameField;

        private void Start()
        {
            var tempUsername = "Player" + Random.Range(0, 1000);
            PlayerPrefs.SetString("Username", tempUsername);
            PlayerPrefs.Save();
        }

        public void Submit()
        {
            PlayerPrefs.SetString("Username", userNameField.text);
            PlayerPrefs.Save();
            gameObject.SetActive(false);
        }
    }
}
