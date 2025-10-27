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
        #endregion

        #region BuiltIn Methods
        #endregion

        #region Custom Methods
        public void UpdateCharacteristics(Rigidbody _rb, my_Input_Controller input)
        {
            HandleLift(_rb, input);
            HandleCyclic(_rb, input);
            HandlePedals(_rb, input);
        }

        protected virtual void HandleLift(Rigidbody _rb, my_Input_Controller input)
        {
            //Debug.Log("Handling Lift");
            Vector3 liftForce = transform.up * Physics.gravity.magnitude * _rb.mass;
            _rb.AddForce(liftForce, ForceMode.Force);
            //if (mainRotor)
            //{
            //    Vector3 liftForce = transform.up * (Physics.gravity.magnitude + maxLiftForce) * _rb.mass;
            //    float normalizedRPMs = mainRotor.CurrentRPMs / 500f;
            //    _rb.AddForce(liftForce * Mathf.Pow(input.StickyCollectiveInput, 2f), ForceMode.Force);
            //}
        }

        protected virtual void HandleCyclic(Rigidbody _rb, my_Input_Controller input)
        {
            Debug.Log("Handling Cyclic");
        }
        protected virtual void HandlePedals(Rigidbody _rb, my_Input_Controller input)
        {
            Debug.Log("Handling Pedals");
        }
        #endregion
    }
}
