using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    public class my_RapidFire_Weapon : my_Base_Weapon, my_IWeapon
    {
        #region Variables
        [Header("Rapid Fire Properties")]
        public float fireRate = 0.15f;

        private float laserFireTime = 0f;
        #endregion

        #region OverRide Methods
        public override void FireWeapon()
        {
            if(Time.time >= laserFireTime + fireRate)
            {
                Fire();
                laserFireTime = Time.time;
            }
        }
        #endregion
    }

}