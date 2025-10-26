using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    [RequireComponent(typeof(Rigidbody))]
    public class my_Base_RBController : MonoBehaviour
    {
        #region Variables
        [Header("Base Properties")]
        public float weightInLbs = 10f;
        public Transform cog;

        const float lbsToKg = 0.454f;
        const float kgToLbs = 2.205f;

        protected Rigidbody _rb;
        protected float weight;
        #endregion

        #region Builtin Methods
        void Awake()
        {

        }

        protected virtual void Start()
        {
            float finalKG = weightInLbs * lbsToKg;
            weight = finalKG;
            _rb = GetComponent<Rigidbody>();
            if (_rb)
            {
                _rb.mass = weight;
            }
        }

        protected virtual void FixedUpdate()
        {
            if (_rb)
            {
                HandlePhysics();
            }
        }
        #endregion

        #region Custom Methods
        protected virtual void HandlePhysics() { }
        #endregion
    }
}