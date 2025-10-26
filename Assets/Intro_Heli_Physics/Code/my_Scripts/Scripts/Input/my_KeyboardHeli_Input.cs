using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    public class my_KeyboardHeli_Input : my_BaseHeli_Input
    {
        #region Variables
        #endregion

        #region Properties
        protected float throttleInput = 0f;
        public float RawThrottleInput
        {
            get{ return throttleInput; }
        }

        protected float stickyThrottle = 0f;
        public float StickyThrottle
        {
            get { return stickyThrottle; }
        }

        protected float pedaleInput = 0f;
        public float PedaleInput
        {
            get { return pedaleInput; }
        }

        protected float collectiveInput = 0f;
        public float CollectiveInput
        {
            get { return collectiveInput; }
        }

        protected float stickyCollectiveInput = 0f;
        public float StickyCollectiveInput
        {
            get { return stickyCollectiveInput; }
        }

        protected Vector2 cyclicInput = Vector2.zero;
        public Vector2 CyclicInput
        {
            get { return cyclicInput; }
        }
        #endregion

        #region Builtin Methods
        void Start()
        {
        }
        #endregion

        #region Custom Methods
        protected override void HandleInput()
        {
            base.HandleInput();

            //Input Methods
            HandleThrottle();
            HandleCollective();
            HandleCyclic();
            HandlePedal();


            //Utility Methods
            ClampInputs();
            HandleStickyThrottle();
            HandleStickyCollective();
        }

        protected virtual void HandleThrottle()
        {
            throttleInput = Input.GetAxis("Throttle");
        }
        protected virtual void HandlePedal()
        {
            pedaleInput = Input.GetAxis("Pedal");
        }
        protected virtual void HandleCollective()
        {
            collectiveInput = Input.GetAxis("Collective");
        }
        protected virtual void HandleCyclic()
        {
            cyclicInput.y = vertical;
            cyclicInput.x = horizontal;
        }

        protected void ClampInputs()
        {
            throttleInput = Mathf.Clamp(throttleInput, -1f, 1f);
            collectiveInput = Mathf.Clamp(collectiveInput, -1f, 1f);
            cyclicInput = Vector2.ClampMagnitude(cyclicInput, 1);
            pedaleInput = Mathf.Clamp(pedaleInput, -1f, 1f);
        }

        protected void HandleStickyThrottle()
        {
            stickyThrottle += RawThrottleInput * Time.deltaTime;
            stickyThrottle = Mathf.Clamp01(stickyThrottle);
        }  

        protected void HandleStickyCollective()
        {
            stickyCollectiveInput += -collectiveInput * Time.deltaTime;
            stickyCollectiveInput = Mathf.Clamp01(stickyCollectiveInput);
        }

        #endregion
    }
}