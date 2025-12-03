using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    public class my_Arcade_Heli_Characteristics : my_Heli_Characteristics
    {
        #region Variables
        private float yRot = 0f;
        private float xRot = 0f;
        private float zRot = 0f;
        #endregion

        protected override void HandleLift(Rigidbody _rb, my_Input_Controller input)
        {
            //base.HandleLift(_rb, input);
            Vector3 liftForce = transform.up * (Physics.gravity.magnitude * _rb.mass);
            _rb.AddForce(liftForce, ForceMode.Force);

            _rb.AddForce(Vector3.up * input.ThrottleInput * maxLiftForce, ForceMode.Acceleration);
        }

        protected override void HandleCyclic(Rigidbody _rb, my_Input_Controller input)
        {
            //base.HandleCyclic(_rb, input);
            Vector3 fwdDir = input.CyclicInput.y * flatFwd;
            Vector3 rightDir = input.CyclicInput.x * flatRight;
            Vector3 finalDir = (fwdDir + rightDir).normalized;

            _rb.AddForce(finalDir * cyclicForce, ForceMode.Acceleration);
        }

        protected override void HandlePedals(Rigidbody _rb, my_Input_Controller input)
        {
            //base.HandlePedals(_rb, input);
            yRot += input.PedalInput * tailForce;

            Quaternion wantedRot = Quaternion.Euler(0f, yRot, 0f);
            _rb.MoveRotation(wantedRot);
        }
    }
}
