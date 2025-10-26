using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using My_Practice;

public class myForces : my_Base_RBController
{
    #region Variables

    public float maxspeed = 1f;
    public Vector3 moveDirection = new Vector3(0f, 0f, 1f);

    #endregion

    #region Builtin Methods
    #endregion

    #region Custom Methods

    protected override void HandlePhysics()
    {
        _rb.AddForce(moveDirection * maxspeed);
    }

    #endregion
}
