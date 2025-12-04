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
        public float leadDistance = 0.25f;

        public float smoothTime = 0.15f;

        private Vector3 finalPosition;
        private Vector3 finalLead;
        private Vector3 refLeadVelocity;
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
            Vector3 targetPos = rb.position;
            targetPos.y = 0f;

            wantedPos = (Vector3.back * -distance) + (Vector3.up * height);

            //Adding camera view lead in direction of heli movement
            Vector3 lead = rb.velocity;
            lead.y = 0f;

            finalPosition = Vector3.SmoothDamp(finalPosition, targetPos + wantedPos, ref refVelocity, smoothTime);
            transform.position = finalPosition;

            finalLead = Vector3.SmoothDamp(finalLead, (lead * leadDistance), ref refLeadVelocity, smoothTime);
            transform.LookAt(lookAtTarget.position + finalLead);
        }
        #endregion
    }
}