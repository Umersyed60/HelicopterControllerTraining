using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    public class my_HeliMain_Rotor : MonoBehaviour, my_IHeliRotor
    {
        #region Variables
        [Header("Main Rotor Properties")]
        public Transform lRotor;
        public Transform rRotor;
        public float maxPitch = 35f;
        #endregion

        #region Properties
        private float currentRPMs;
        public float CurrentRPMs
        {
            get { return currentRPMs; }
        }
        #endregion

        #region BuiltIn Methods
        // Start is called before the first frame update
        void Start()
        {

        }
        #endregion

        #region Interface Methods
        public void UpdateRotor(float dps, my_Input_Controller input)
        {
            //Debug.Log("Updating Main Rotor");
            currentRPMs = (dps / 360) * 60f;
            transform.Rotate(Vector3.up, dps * Time.deltaTime * 0.5f);

            //Pitch the blades up and down
            if (lRotor && rRotor)
            {
                lRotor.localRotation = Quaternion.Euler(-input.StickyCollectiveInput * maxPitch, 0f, 0f);
                rRotor.localRotation = Quaternion.Euler(input.StickyCollectiveInput * maxPitch, 0f, 0f);
            }
        }
        #endregion

    }
}