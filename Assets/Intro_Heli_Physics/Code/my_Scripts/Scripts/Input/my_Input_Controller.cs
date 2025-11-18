using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace My_Practice
{

    public enum InputType { Keyboard, Xbox, Mobile }

    [RequireComponent(typeof(my_KeyboardHeli_Input), typeof(my_XboxHeli_Input))]
    public class my_Input_Controller : MonoBehaviour
    {
        #region Variables
        [Header("Input Properties")]
        public InputType inputType = InputType.Keyboard;

        [Header("Input Events")]
        public UnityEvent onCamButtonPressed = new UnityEvent();

        [Header("Input Components")]
        private my_KeyboardHeli_Input keyboardInput;
        private my_XboxHeli_Input xboxInput;
        #endregion

        #region Properties
        private float throttleInput;
        public float ThrottleInput
        {
            get { return throttleInput; }
        }
        private float stickyThrottle;
        public float StickyThrottle
        {
            get { return stickyThrottle; }
        }
        private float collectiveInput;
        public float CollectiveInput
        {
            get { return collectiveInput; }
        }
        private float stickycollectiveInput;
        public float StickyCollectiveInput
        {
            get { return stickycollectiveInput; }
        }
        private Vector2 cyclicInput;
        public Vector2 CyclicInput
        {
            get { return cyclicInput; }
        }
        private float pedalInput;
        public float PedalInput
        {
            get { return pedalInput; }
        }

        private bool camInput;
        public bool CamInput
        {
            get { return camInput; }
        }
        #endregion

        #region BuiltIn Methods
        private void Awake()
        {
            keyboardInput = GetComponent<my_KeyboardHeli_Input>();
            xboxInput = GetComponent<my_XboxHeli_Input>();
        }
        void Start()
        {
            if (keyboardInput && xboxInput)
            {
                SetInputType(inputType);
            }
        }

        private void Update()
        {
            if (keyboardInput && xboxInput)
            {
                switch (inputType)
                {
                    case InputType.Keyboard:
                        throttleInput = keyboardInput.RawThrottleInput;
                        collectiveInput = keyboardInput.CollectiveInput;
                        stickycollectiveInput = keyboardInput.StickyCollectiveInput;
                        cyclicInput = keyboardInput.CyclicInput;
                        pedalInput = keyboardInput.PedaleInput;
                        stickyThrottle = keyboardInput.StickyThrottle;
                        camInput = keyboardInput.CamInput;
                        break;
                    case InputType.Xbox:
                        throttleInput = xboxInput.RawThrottleInput;
                        collectiveInput = xboxInput.CollectiveInput;
                        stickycollectiveInput = xboxInput.StickyCollectiveInput;
                        cyclicInput = xboxInput.CyclicInput;
                        pedalInput = xboxInput.PedaleInput;
                        stickyThrottle = xboxInput.StickyThrottle;
                        camInput = xboxInput.CamInput;
                        break;
                    default:
                        break;
                }
                if (camInput)
                {
                    onCamButtonPressed.Invoke();
                }
            }
        }

        #endregion

        #region Custom Methods

        public void SetInputType(InputType type)
        {
            if (keyboardInput && xboxInput)
            {
                if (type.Equals(InputType.Keyboard))
                {
                    keyboardInput.enabled = true;
                    xboxInput.enabled = false;
                }
                if (type.Equals(InputType.Xbox))
                {
                    xboxInput.enabled = true;
                    keyboardInput.enabled = false;
                }
            }
        }

        #endregion
    }
}