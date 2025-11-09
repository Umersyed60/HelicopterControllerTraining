using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    public class my_Advanced_HeliCamera : my_Base_HeliCamera, my_IHeliCamera
    {
        #region Variables
        [Header("Advanced Camera Properties")]
        public float height = 2f;
        public float minDistance = 4f;
        public float maxDistance = 8f;
        public float catchUpModifier = 5f;
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
            //Get the flat direction from the helicopter to the camera
            Vector3 dirToTarget = transform.position - rb.position;
            dirToTarget.y = 0f;
            Vector3 normalizedDir = dirToTarget.normalized;
            Debug.DrawRay(rb.position, dirToTarget, Color.green);

            //re-position the camera based off of the min max distance
            wantedPos = rb.position + dirToTarget;
            float curMagnitude = dirToTarget.magnitude;
            if (curMagnitude < minDistance)
            {
                float delta = minDistance - curMagnitude;
                wantedPos += normalizedDir * delta * Time.fixedDeltaTime * catchUpModifier;
            }

            if (curMagnitude > maxDistance)
            {
                float delta = curMagnitude - maxDistance;
                wantedPos -= normalizedDir * delta * Time.fixedDeltaTime * catchUpModifier;
            }

            transform.position = wantedPos + (Vector3.up * height);
            transform.LookAt(lookAtTarget);
        }
        #endregion
    }

}