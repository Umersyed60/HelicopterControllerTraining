using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace My_Practice
{
    public class my_HeliWeapon_Controller : MonoBehaviour
    {
        #region Variables
        [Header("Weapon Controller Properties")]
        public bool allowFiring = true;

        private List<my_IWeapon> weapons = new List<my_IWeapon>();
        #endregion

        #region BuiltIn Methods
        private void Start()
        {
            weapons = GetComponentsInChildren<my_IWeapon>().ToList<my_IWeapon>();
        }
        #endregion

        #region Custom Methods
        public void UpdateWeapons(my_Input_Controller input)
        {
            if (input.Fire)
            {
                if (weapons.Count > 0 && allowFiring)
                {
                    foreach (my_IWeapon weapon in weapons)
                    {
                        weapon.FireWeapon();
                    }
                }
            }
        }
        #endregion
    }
}
