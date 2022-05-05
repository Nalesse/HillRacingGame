using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

namespace UI
{
    public class EnterUsername : MonoBehaviour
    {
        [SerializeField] private TMP_InputField userNameField;
        public Button startButton;
        private string userName;
        private Controls controls;
        private int letterIndex = -1;
        private char currentLetter;
        private readonly char[] alpha =
        {
            'a',
            'b',
            'c',
            'd',
            'e',
            'f',
            'g',
            'h',
            'i',
            'j',
            'k',
            'l',
            'm',
            'n',
            'o',
            'p',
            'q',
            'r',
            's',
            't',
            'u',
            'v',
            'w',
            'x',
            'y',
            'z',
            'A',
            'B',
            'C',
            'D',
            'E',
            'F',
            'G',
            'H',
            'I',
            'J',
            'K',
            'L',
            'M',
            'N',
            'O',
            'P',
            'Q',
            'R',
            'S',
            'T',
            'U',
            'V',
            'W',
            'X',
            'Y',
            'Z'
        };


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

            controls.UI.Select.performed += EnterName;
            controls.UI.Confirm.performed += ctx => Confirm();
            controls.UI.Cancel.performed += ctx => Cancel();
        }

        private void Start()
        {
            var tempUsername = "Player" + Random.Range(0, 1000);
            PlayerPrefs.SetString("Username", tempUsername);
            PlayerPrefs.Save();
        }

        

        public void Submit()
        {
            PlayerPrefs.SetString("Username", userName);
            PlayerPrefs.Save();
            gameObject.SetActive(false);
            startButton.Select();
        }

        private void EnterName(InputAction.CallbackContext ctx)
        {
            var playerInput = ctx.ReadValue<Vector2>();
            
            if (!userNameField.isFocused) return;

            userNameField.readOnly = true;

            if (playerInput.y > 0)
            {
                letterIndex++;
            }
            else if (playerInput.y < 0)
            {
                letterIndex--;
            }
            
            if (letterIndex >= alpha.Length)
            {
                letterIndex = 0;
            }
            else if (letterIndex < 0)
            {
                letterIndex = alpha.Length - 1;
            }
            
            currentLetter = alpha[letterIndex];
            userNameField.text = userName + currentLetter;
            Debug.Log(currentLetter);
        }

        private void Confirm()
        {
            userName += currentLetter;
            userNameField.text = userName;
        }

        private void Cancel()
        {
            userNameField.readOnly = false;
        }

    }
}
