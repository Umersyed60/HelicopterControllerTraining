using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    public class my_Heli_Camera : MonoBehaviour, my_IHeliCamera
    {
        #region Variables
        [Header("Camera Properties")]
        public Rigidbody rb;
        public float height = 2f;
        public float distance = 2f;
        #endregion

        #region Builtin Methods
        private void FixedUpdate()
        {
            if (rb)
            {
                UpdateCamera();
            }
        }
        #endregion

        #region Interface Methods
        public void UpdateCamera()
        {
            Debug.Log("Camera is Updating");
        }
        #endregion
    }

}