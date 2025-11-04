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
        public Transform lookAtTarget;
        public float height = 2f;
        public float distance = 2f;
        public float smoothSpeed = 0.35f;

        private Vector3 wantedPos;
        private Vector3 refVelocity;
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