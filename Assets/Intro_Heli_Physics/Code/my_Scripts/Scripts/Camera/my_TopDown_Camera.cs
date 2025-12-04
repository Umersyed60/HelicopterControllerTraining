using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    public class my_TopDown_Camera : my_Base_HeliCamera, my_IHeliCamera
    {
        #region Variables
        [Header("Top Down Camera Properties")]
        public float height = 2f;
        public float distance = 2f;
        #endregion

        #region Builtin Methods
        private void OnEnable()
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