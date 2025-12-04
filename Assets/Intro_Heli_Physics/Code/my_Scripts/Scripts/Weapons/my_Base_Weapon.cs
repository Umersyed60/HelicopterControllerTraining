using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    [RequireComponent(typeof(AudioSource))]
    public class my_Base_Weapon : MonoBehaviour, my_IWeapon
    {
        #region Variables
        [Header("Base Weapon Properties")]
        public Transform muzzlePos;
        public GameObject projectile;
        public int maxAmmoCount = 100;
        [Space(5)]
        public GameObject muzzleFlash;

        protected AudioSource aSource;
        protected int currentAmmoCount = 0;
        #endregion

        #region BuiltIn Methods
        // Start is called before the first frame update
        void Start()
        {
            currentAmmoCount = maxAmmoCount;
        }
        #endregion

        #region Interface Methods
        public void FireWeapon()
        {
            if (currentAmmoCount != 0)
            {
                HandleProjectile();
                HandleAudio();
                HandleVFX();

                Debug.Log("Weapon Shooting------------");
                currentAmmoCount--;
                currentAmmoCount = Mathf.Clamp(currentAmmoCount, 0, maxAmmoCount);
            }
            else
            {
                Reload();
            }
        }

        public void Reload()
        {
            Debug.Log("------------RELOAD------------");
            if (currentAmmoCount <= 0)
            {
                currentAmmoCount = maxAmmoCount;
            }
        }
        #endregion

        #region Custom Methods
        protected virtual void HandleProjectile()
        {
            if (projectile)
            {

            }
        }

        protected virtual void HandleAudio()
        {
            if (aSource)
            {

            }
        }

        protected virtual void HandleVFX()
        {
            if (muzzleFlash)
            {

            }
        }
        #endregion
    }

}