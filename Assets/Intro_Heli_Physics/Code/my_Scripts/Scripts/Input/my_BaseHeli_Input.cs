using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    public class my_BaseHeli_Input : MonoBehaviour
    {
        #region Variables
        [Header("Base Input Properties")]
        protected float vertical = 0f;
        protected float horizontal = 0f;
        #endregion

        #region Builtin Methods
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            HandleInput();
        }
        #endregion

        #region Custom Methods
        protected virtual void HandleInput()
        {
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");
        }

        #endregion
    }
}