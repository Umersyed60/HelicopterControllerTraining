using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    public class my_HeliTail_Rotor : MonoBehaviour, my_IHeliRotor
    {
        #region Variables
        [Header("Tail Rotor Properties")]
        public float rotationSpeedModifier = 1.5f;
        public Transform lRotor;
        public Transform rRotor;
        public float maxPitch = 45f;
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
            //Debug.Log("Updating Tail Rotor");
            transform.Rotate(Vector3.right, dps * rotationSpeedModifier * Time.deltaTime);

            //Pitch the blades up and down
            if (lRotor && rRotor)
            {
                lRotor.localRotation = Quaternion.Euler(0f, input.PedalInput * maxPitch, 0f);
                rRotor.localRotation = Quaternion.Euler(0f, -input.PedalInput * maxPitch, 0f);
            }
        }
        #endregion
    }
}