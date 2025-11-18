using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    public class my_XboxHeli_Input : my_KeyboardHeli_Input
    {
        #region BuiltIn Methods
        #endregion

        #region Custom Methods
        protected override void HandleThrottle()
        {
            throttleInput = Input.GetAxis("XboxThrottleUp") + -(Input.GetAxis("XboxThrottleDown"));
        }

        protected override void HandleCollective()
        {
            collectiveInput = Input.GetAxis("XboxCollective");
        }

        protected override void HandleCyclic()
        {
            cyclicInput.x = Input.GetAxis("XboxCyclicHorizontal");
            cyclicInput.y = Input.GetAxis("XboxCyclicVertical");
        }

        protected override void HandlePedal()
        {
            pedaleInput = Input.GetAxis("XboxPedal");
        }

        protected override void HandleCamButton()
        {
            camInput = Input.GetButtonDown("XboxCamBtn");
        }

        #endregion
    }
}
