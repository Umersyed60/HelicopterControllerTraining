using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myDrag : MonoBehaviour
{
    #region Variables

    private Rigidbody _rb;

    [Header("Drag Properties")]
    public float dragFactor = 0.05f;

    #endregion

    #region
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_rb)
        {
            float currentSpeed = _rb.velocity.magnitude;
            float finalDrag = currentSpeed * dragFactor;
            _rb.drag = finalDrag;
        }
    }
    #endregion
}
