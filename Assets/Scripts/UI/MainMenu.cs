using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject controlScreen;
        public GameObject optionsScreen;
        public GameObject keyboardControls;
        public GameObject gamepadControls;

        public Button startButton;
        public Button controlFirstButton;
        public Slider optionsFirstButton;

        void Start()
        {
        
        }

        // Update is called once per frame
        public void OpenControls()
        {
            controlScreen.SetActive(true);
            controlFirstButton.Select();
        }

        public void CloseControls()
        {
            controlScreen.SetActive(false);
            startButton.Select();
        }

        public void OpenOptions()
        {
            optionsScreen.SetActive(true);
            optionsFirstButton.Select();
        }

        public void CloseOptions()
        {
            optionsScreen.SetActive(false);
            startButton.Select();
        }

        public void ShowKeyboardControls()
        {
            keyboardControls.SetActive(true);
            gamepadControls.SetActive(false);
        }

        public void ShowGamepadControls()
        {
            keyboardControls.SetActive(false);
            gamepadControls.SetActive(true);
        }

        public void EndGame()
        {
            Application.Quit();
        }
    }
}
