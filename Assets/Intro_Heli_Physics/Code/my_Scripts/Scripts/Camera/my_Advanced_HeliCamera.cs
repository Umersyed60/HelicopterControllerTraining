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
        public float minGroundHeight = 4f;
        public float minDistance = 4f;
        public float maxDistance = 8f;
        public float catchUpModifier = 5f;
        public float rotationSpeed = 5f;
        public float minVelocityForOrient = 5f;

        private float finalAngle;
        private Vector3 wantedDir;
        private float finalHeight;
        #endregion

        #region BuiltIn Methods
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
            //Get the flat direction from the helicopter to the camera
            Vector3 dirToTarget = transform.position - rb.position;
            dirToTarget.y = 0f;
            Vector3 normalizedDir = dirToTarget.normalized;
            wantedDir = normalizedDir;
            Debug.DrawRay(rb.position, wantedDir, Color.green);

            //Find the angle between our Dir Vector and our Flat forward
            float angleToFwd = Vector3.SignedAngle(normalizedDir, targetFlatFwd, Vector3.up);
            //Debug.Log(angleToFwd);
            float wantedAngle = 0f;
            if (rb.velocity.magnitude > minVelocityForOrient)
            {
                wantedAngle = angleToFwd * Time.fixedDeltaTime;
            }
            finalAngle = Mathf.Lerp(finalAngle, wantedAngle, Time.fixedDeltaTime * rotationSpeed);
            wantedDir = Quaternion.AngleAxis(finalAngle, Vector3.up) * wantedDir;

            //re-position the camera based off of the min max distance
            wantedPos = rb.position + (wantedDir * dirToTarget.magnitude);
            float curMagnitude = dirToTarget.magnitude;
            if (curMagnitude < minDistance)
            {
                float delta = minDistance - curMagnitude;
                wantedPos += wantedDir * delta * Time.fixedDeltaTime * catchUpModifier;
            }

            if (curMagnitude > maxDistance)
            {
                float delta = curMagnitude - maxDistance;
                wantedPos -= wantedDir * delta * Time.fixedDeltaTime * catchUpModifier;
            }

            //Take into account the height of the ground
            float wantedheight = height;
            RaycastHit hit;
            Ray groundRay = new Ray(transform.position, Vector3.down);
            if (Physics.Raycast(groundRay, out hit, 100f))
            {
                if (hit.transform.tag == "ground" && hit.distance <= minGroundHeight)
                {
                    wantedheight += minGroundHeight - hit.distance;
                }
            }
            finalHeight = Mathf.Lerp(finalHeight, wantedheight, Time.fixedDeltaTime);

            //Apply final Tranformations
            transform.position = wantedPos + (Vector3.up * finalHeight);
            transform.LookAt(lookAtTarget);
        }
        #endregion
    }

}