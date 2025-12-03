using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace My_Practice
{
    public class my_Cockpit_HeliCamera : my_Base_HeliCamera, my_IHeliCamera
    {
        #region Variable
        [Header("Cockpit Camera Properties")]
        public Transform cockpitPosition;
        public Vector3 offset = Vector3.zero;
        public float fov = 70f;
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
            if (cockpitPosition)
            {
                transform.position = cockpitPosition.position;
                transform.LookAt(lookAtTarget);
            }
        }
        #endregion
    }
}
