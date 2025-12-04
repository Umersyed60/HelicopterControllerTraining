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
        public float slowDownSpeed = 2f;

        private float lastRotSpeed = 0f;
        #endregion

        #region BuiltIn Methods
        private void Update()
        {
            if (barrelGO)
            {
                lastRotSpeed -= Time.deltaTime * slowDownSpeed;
                lastRotSpeed = Mathf.Clamp(lastRotSpeed, 0f, rotationSpeed);
                barrelGO.Rotate(Vector3.up, lastRotSpeed);
            }
        }
        #endregion

        #region Override Methods
        public override void FireWeapon()
        {
            base.FireWeapon();

            //Animate the Barrels
            if (barrelGO)
            {
                barrelGO.Rotate(Vector3.up, rotationSpeed);
                lastRotSpeed = rotationSpeed;
            }
        }
        #endregion
    }
}