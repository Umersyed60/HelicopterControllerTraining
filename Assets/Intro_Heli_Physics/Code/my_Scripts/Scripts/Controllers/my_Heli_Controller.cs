using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    [RequireComponent(typeof(my_Input_Controller))]
    public class my_Heli_Controller : my_Base_RBController
    {
        #region Variables
        [Header("Helicopter Properties")]
        public List<my_Heli_Engine> engines = new List<my_Heli_Engine>();

        [Header("Helicopter Rotors")]
        public my_Heli_Rotor_Controller rotorCtrl;

        private my_Input_Controller input;
        private my_Heli_Characteristics characteristics;
        private my_HeliWeapon_Controller weapons;
        #endregion

        #region BuiltIn Methods

        private void Awake()
        {
            
        }

        protected override void Start()
        {
            base.Start();
            characteristics = GetComponent<my_Heli_Characteristics>();
            weapons = GetComponentInChildren<my_HeliWeapon_Controller>();
        }

        #endregion

        #region Custom Methods

        protected override void HandlePhysics()
        {
            input = GetComponent<my_Input_Controller>();
            if (input)
            {
                HandleEngines();
                HandleRotors();
                HandleCharacteristics();
                HandleWeapons();
            }
        }

        #endregion

        #region Helicopter Control Methods
        protected virtual void HandleEngines()
        {
            for (int i=0; i<engines.Count; i++)
            {
                engines[i].UpdateEngine(input.StickyThrottle);
                //float finalPower = engines[i].CurrentHP;
                //Debug.Log(finalPower);
            }
        }

        protected virtual void HandleRotors()
        {
            if (rotorCtrl && engines.Count > 0)
            {
                rotorCtrl.UpdateRotors(input, engines[0].CurrentRPM);
            }
        }

        protected virtual void HandleCharacteristics()
        {
            if (characteristics)
            {
                characteristics.UpdateCharacteristics(_rb, input);
            }
        }

        protected virtual void HandleWeapons()
        {
            if (weapons)
            {
                weapons.UpdateWeapons(input);
            }
        }
        #endregion

    }

}