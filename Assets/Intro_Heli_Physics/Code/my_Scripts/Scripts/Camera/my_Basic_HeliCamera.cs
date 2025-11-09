using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    public class my_Basic_HeliCamera : my_Base_HeliCamera, my_IHeliCamera
    {
        #region Variables
        [Header("Basic Camera Properties")]
        public float height = 2f;
        public float distance = 2f;
        public float smoothSpeed = 0.35f;
        #endregion

        #region Builtin Methods
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
            //Debug.Log("Camera is Updating");
            Vector3 flatfwd = rb.transform.forward;
            flatfwd.y = 0f;
            flatfwd = flatfwd.normalized;

            //Wanted Position
            wantedPos = rb.position + (flatfwd * distance) + (Vector3.up * height);

            //Positioning The Camera
            transform.position = Vector3.SmoothDamp(transform.position, wantedPos, ref refVelocity, smoothSpeed);
            transform.LookAt(lookAtTarget);
        }
        #endregion
    }

}