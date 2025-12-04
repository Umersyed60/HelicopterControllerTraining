using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    [RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
    public class my_Base_Projectile : MonoBehaviour
    {
        #region Variables
        [Header("Base Projectile Properties")]
        public float projectileSpeed = 200f;
        public float damagePower = 10f;

        protected Rigidbody rb;
        protected SphereCollider col;
        #endregion

        #region BuiltIn Methods
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            col = GetComponent<SphereCollider>();

            col.isTrigger = true;

            if (rb)
            {
                FireProjectile();
            }
        }
        #endregion

        #region Custom Methods
        public virtual void FireProjectile()
        {
            rb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
        }
        #endregion
    }
}
