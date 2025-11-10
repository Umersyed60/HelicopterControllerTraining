using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace My_Practice
{
    [CustomEditor(typeof(my_Advanced_HeliCamera))]
    public class my_AdvancedHeliCamera_Editor : Editor
    {
        #region Variables
        my_Advanced_HeliCamera targetCamera;
        #endregion

        #region Methods
        private void OnEnable()
        {
            targetCamera = (my_Advanced_HeliCamera)target;
        }

        private void OnSceneGUI()
        {
            float minDist = targetCamera.minDistance;
            float maxDist = targetCamera.maxDistance;
            Vector3 targetFwd = targetCamera.rb.transform.forward;

            Handles.color = Color.blue;
            Handles.DrawWireDisc(targetCamera.rb.position, Vector3.up, minDist);
            Handles.DrawWireDisc(targetCamera.rb.position, Vector3.up, maxDist);

            targetCamera.minDistance = Handles.ScaleSlider(targetCamera.minDistance, targetCamera.rb.position + (targetFwd * minDist), Vector3.forward, Quaternion.identity, 1f, 1f);
            targetCamera.maxDistance = Handles.ScaleSlider(targetCamera.maxDistance, targetCamera.rb.position + (targetFwd * maxDist), Vector3.forward, Quaternion.identity, 1f, 1f);

        }
        #endregion
    }
}
