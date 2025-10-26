using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace My_Practice
{
    public class my_Heli_Rotor_Controller : MonoBehaviour
    {
        #region Variables
        public float maxDps = 3000f;
        private List<my_IHeliRotor> rotors;
        #endregion

        #region BuiltIn Methods
        private void Start()
        {
            rotors = GetComponentsInChildren<my_IHeliRotor>().ToList<my_IHeliRotor>();
        }
        #endregion

        #region Custom Methods
        public void UpdateRotors(my_Input_Controller input, float currentRPMS)
        {
            //Debug.Log("Updating Rotors Controllers");
            //Degrees per second calculation
            float dps = ((currentRPMS * 360f) / 60f);
            dps = Mathf.Clamp(dps, 0f, maxDps);

            //Update our Rotors
            if (rotors.Count > 0)
            {
                foreach (var rotor in rotors)
                {
                    rotor.UpdateRotor(dps, input);
                }
            }
        }
        #endregion
    }
}