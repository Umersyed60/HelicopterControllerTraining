using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    public class my_Advanced_HeliCamera : my_Base_HeliCamera, my_IHeliCamera
    {
        #region Variables
        #endregion

        #region BuiltIn Methods
        private void Start()
        {
            updateEvent.AddListener(UpdateCamera);
        }

        private void OnDisable()
        {
            updateEvent.RemoveListener(UpdateCamera);
        }
        #endregion

        #region Interface Methods
        public void UpdateCamera()
        {

        }
        #endregion
    }

}