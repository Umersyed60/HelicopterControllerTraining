using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    [RequireComponent(typeof(my_KeyboardHeli_Input), typeof(my_XboxHeli_Input))]
    public class my_Input_Controller : MonoBehaviour
    {
        public enum InputType { Keyboard, Xbox, Mobile }

        #region Variables
        [Header("Input Components")]
        public InputType inputType = InputType.Keyboard;
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
            switch (inputType)
            {
                case InputType.Keyboard:
                    throttleInput = keyboardInput.RawThrottleInput;
                    collectiveInput = keyboardInput.CollectiveInput;
                    stickycollectiveInput = keyboardInput.StickyCollectiveInput;
                    cyclicInput = keyboardInput.CyclicInput;
                    pedalInput = keyboardInput.PedaleInput;
                    stickyThrottle = keyboardInput.StickyThrottle;
                    break;
                case InputType.Xbox:
                    throttleInput = xboxInput.RawThrottleInput;
                    collectiveInput = xboxInput.CollectiveInput;
                    stickycollectiveInput = xboxInput.StickyCollectiveInput;
                    cyclicInput = xboxInput.CyclicInput;
                    pedalInput = xboxInput.PedaleInput;
                    stickyThrottle = xboxInput.StickyThrottle;
                    break;
                default:
                    break;
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