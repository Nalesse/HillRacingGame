using Input;
using UnityEngine;

namespace Misc
{
    public class FrameRateCap : MonoBehaviour
    {
        Controls controls;



        private void Awake()
        {

            controls = new Controls();

            controls.Racing.DebugFPS30.performed += ctx => Fps30();

            controls.Racing.DebugFPS60.performed += ctx => Fps60();

            //framerate locks

            Application.targetFrameRate = 32;
            // Application.targetFrameRate = 61;
            //Application.targetFrameRate = 120;
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        void Fps30()
        {
            Debug.Log("30");
            Application.targetFrameRate = 32;
        }

        void Fps60()
        {
            Debug.Log("60");
            Application.targetFrameRate = 62;
        }


        private void OnEnable()
        {
            controls.Racing.Enable();
        
        }

        private void OnDisable()
        {
            controls.Racing.Disable();
        
        }
    }
}
