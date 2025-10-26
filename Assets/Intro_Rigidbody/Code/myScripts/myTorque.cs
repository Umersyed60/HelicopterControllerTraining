using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using My_Practice;

public class myTorque : my_Base_RBController
{
    #region Variables

    //private Rigidbody _rb;
    public float torqueSpeed = 1f;

    #endregion

    #region Builtin Methods
    #endregion

    #region Custom Methods
    protected override void HandlePhysics()
    {
        _rb.AddTorque(Vector3.up * torqueSpeed);
    }
    #endregion
}
