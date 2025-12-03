using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace My_Practice
{
    public class my_Cockpit_HeliCamera : my_Base_HeliCamera, my_IHeliCamera
    {
        #region Variable
        [Header("Cockpit Camera Properties")]
        public Vector3 offset = Vector3.zero;
        public float fov = 70f;

        private Vector3 startOffset;
        #endregion


        #region Builtin Methods
        private void OnEnable()
        {
            startOffset = transform.position - rb.position;
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
            Debug.DrawRay(rb.position, startOffset);
            transform.position = rb.position + startOffset;
            transform.LookAt(lookAtTarget);
        }
        #endregion
    }
}
