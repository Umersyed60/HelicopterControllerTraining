using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace My_Practice
{
    public class my_Base_HeliCamera : MonoBehaviour
    {
        #region Variables
        [Header("Base Camera Properties")]
        public Rigidbody rb;
        public Transform lookAtTarget;

        protected Vector3 wantedPos;
        protected Vector3 refVelocity;
        protected UnityEvent updateEvent = new UnityEvent();
        #endregion

        #region BuiltIn Methods
        // Start is called before the first frame update
        void Start()
        {

        }

        // Physics Update
        private void FixedUpdate()
        {
            if (rb)
            {
                updateEvent.Invoke();
            }
        }
        #endregion
    }
}
