using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    public class my_Heli_Characteristics : MonoBehaviour
    {
        #region Variables
        [Header("Lift Properties")]
        public float maxLiftForce = 100f;
        public my_HeliMain_Rotor mainRotor;
        [Space]

        [Header("Tail Rotor Properties")]
        public float tailForce = 2f;

        [Header("Cyclic Properties")]
        public float cyclicForce = 2f;

        [Header("Auto Level Properties")]
        public bool useAutoLevel = true;
        public float autoLevelForce = 2f;

        private Vector3 flatFwd;
        private float forwardDot;
        private Vector3 flatRight;
        private float rightDot;
        #endregion

        #region BuiltIn Methods
        #endregion

        #region Custom Methods
        public void UpdateCharacteristics(Rigidbody _rb, my_Input_Controller input)
        {
            HandleLift(_rb, input);
            HandleCyclic(_rb, input);
            HandlePedals(_rb, input);

            CalculateAngles();
            if (useAutoLevel)
            {
                AutoLevel(_rb);
            }
        }

        protected virtual void HandleLift(Rigidbody _rb, my_Input_Controller input)
        {
            //Debug.Log("Handling Lift");
            if (mainRotor)
            {
                Vector3 liftForce = transform.up * (Physics.gravity.magnitude + maxLiftForce) * _rb.mass;
                float normalizedRPMs = mainRotor.CurrentRPMs / 500f;
                _rb.AddForce(liftForce * Mathf.Pow(normalizedRPMs, 2f) * Mathf.Pow(input.StickyCollectiveInput, 2f), ForceMode.Force);
            }
        }

        protected virtual void HandleCyclic(Rigidbody _rb, my_Input_Controller input)
        {
            //Debug.Log("Handling Cyclic");
            float cyclicZForce = input.CyclicInput.x * cyclicForce;
            _rb.AddRelativeTorque(Vector3.forward * cyclicZForce, ForceMode.Acceleration);

            float cyclicXForce = -input.CyclicInput.y * cyclicForce;
            _rb.AddRelativeTorque(Vector3.right * cyclicXForce, ForceMode.Acceleration);
        }
        protected virtual void HandlePedals(Rigidbody _rb, my_Input_Controller input)
        {
            //Debug.Log("Handling Pedals");
            _rb.AddTorque(Vector3.up * input.PedalInput * tailForce, ForceMode.Acceleration);
        }

        private void CalculateAngles()
        {
            //Calculate Flat Forward
            flatFwd = transform.forward;
            flatFwd.y = 0f;
            flatFwd = flatFwd.normalized;
            Debug.DrawRay(transform.position, flatFwd, Color.blue);

            //Calculate Flat Right
            flatRight = transform.right;
            flatRight.y = 0f;
            flatRight = flatRight.normalized;
            Debug.DrawRay(transform.position, flatRight, Color.red);

            //Calculate Angles
            forwardDot = Vector3.Dot(transform.up, flatFwd);
            rightDot = Vector3.Dot(transform.up, flatRight);
            //Debug.Log(string.Format("FWD: {0} - RWD: {1}", forwardDot.ToString("0.0"), rightDot.ToString("0.0")));
        }

        private void AutoLevel(Rigidbody rb)
        {
            float rightForce = -forwardDot * autoLevelForce;
            float forwardForce = rightDot * autoLevelForce;

            rb.AddRelativeTorque(Vector3.right * rightForce, ForceMode.Acceleration);
            rb.AddRelativeTorque(Vector3.forward * forwardForce, ForceMode.Acceleration);
        }
        #endregion
    }
}
