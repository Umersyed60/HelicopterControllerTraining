using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace My_Practice
{
    public class my_Camera_Manager : MonoBehaviour
    {
        #region Variables
        [Header("Manager Properties")]
        public int startIndex = 1;

        private List<my_Base_HeliCamera> cameras = new List<my_Base_HeliCamera>();
        private int camIndex = 0;
        #endregion

        #region Builtin Methods
        // Start is called before the first frame update
        void Start()
        {
            cameras = transform.GetComponentsInChildren<my_Base_HeliCamera>().ToList<my_Base_HeliCamera>();
            camIndex = startIndex;
            SwitchCamera(camIndex);
        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        #region Custom Methods
        public void SwitchCamera()
        {
            camIndex++;
            HandleSwitch();
        }

        public void SwitchCamera(int index)
        {
            HandleSwitch();
        }

        private void HandleSwitch()
        {
            if (camIndex == cameras.Count)
            {
                camIndex = 0;
            }

            for (int i = 0; i < cameras.Count; i++)
            {
                cameras[i].gameObject.SetActive(false);
                if (i == camIndex)
                {
                    cameras[camIndex].gameObject.SetActive(true);
                }
            }
        }

        #endregion
    }

}