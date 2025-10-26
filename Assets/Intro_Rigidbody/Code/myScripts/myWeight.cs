using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using My_Practice;

public class myWeight : my_Base_RBController
{
    #region Variables

    [Header("Weight Properties")]
    public float weightInLbs = 10f;
    public float weight;

    const float lbsToKg = 0.454f;
    const float kgToLbs = 2.205f;

    #endregion

    #region

    // Start is called before the first frame update
    void Start()
    {
        float finalKg = weightInLbs * lbsToKg;
        weight = finalKg;
        if (_rb)
        {
            _rb.mass = finalKg;
        }
    }
    #endregion
}
