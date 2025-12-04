using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    public class my_GatlingGun_Weapon : my_RapidFire_Weapon
    {
        #region Variables
        [Header("Gatling Gun Properties")]
        public Transform barrelGO;
        public float rotationSpeed = 10f;
        #endregion

        #region Override Methods
        public override void FireWeapon()
        {
            base.FireWeapon();

            //Animate the Barrels

        }
        #endregion
    }
}