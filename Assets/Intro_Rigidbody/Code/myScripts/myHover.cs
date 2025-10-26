using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using My_Practice;

public class myHover : my_Base_RBController
{
    #region Variables

    [Header("Hover Properties")]
    public float hoverHeight = 3f;
    private float weight;
    private float currentGroundDistance;

    [Header("Drag Properties")]
    public float dragFactor = 0.05f;


    #endregion

    #region Builtin Methods

    // Start is called before the first frame update
    void Start()
    {
        if (_rb)
        {
            weight = _rb.mass * Physics.gravity.magnitude;
        }
    }

    protected override void FixedUpdate()
    {
        if (_rb)
        {
            CalculateGroundDistance();
            HandleHoverForce();
            HandleDrag();
        }
    }

    #endregion

    #region Custome Methods

    void CalculateGroundDistance()
    {
        Ray hoverRay = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, hoverRay.direction, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(hoverRay, out hit, 100f))
        {
            if (hit.transform.tag.Equals("ground"))
            {
                currentGroundDistance = hit.distance;
            }
        }
    }

    void HandleHoverForce()
    {
        float groundDifference = hoverHeight - currentGroundDistance;
        Vector3 finalHoverForce = Vector3.up * (1 + groundDifference);
        _rb.AddForce(finalHoverForce * weight);
    }

    void HandleDrag()
    {
        _rb.drag = _rb.velocity.magnitude * dragFactor;
    }
    #endregion
}
