using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    public class my_Arcade_Heli_Characteristics : my_Heli_Characteristics
    {
        #region Variables
        [Header("Arcade Prperties")]
        public float bankAngle = 35f;
        public float bankSpeed = 4f;

        private float yRot = 0f;
        private float xRot = 0f;
        private float zRot = 0f;

        Quaternion finalRot = Quaternion.identity;
        #endregion

        protected override void HandleLift(Rigidbody _rb, my_Input_Controller input)
        {
            //base.HandleLift(_rb, input);
            Vector3 liftForce = Vector3.up * (Physics.gravity.magnitude * _rb.mass);
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

            xRot = input.CyclicInput.y * bankAngle;
            zRot = -input.CyclicInput.x * bankAngle;
        }

        protected override void HandlePedals(Rigidbody _rb, my_Input_Controller input)
        {
            //base.HandlePedals(_rb, input);
            yRot += input.PedalInput * tailForce;

            Quaternion wantedRot = Quaternion.Euler(0f, yRot, 0f);
            _rb.MoveRotation(wantedRot);
        }

        protected override void AutoLevel(Rigidbody rb)
        {
            Quaternion wantedRot = Quaternion.Euler(xRot, yRot, zRot);
            finalRot = Quaternion.Slerp(finalRot, wantedRot, Time.fixedDeltaTime * bankSpeed);
            rb.MoveRotation(finalRot);
        }
    }
}
