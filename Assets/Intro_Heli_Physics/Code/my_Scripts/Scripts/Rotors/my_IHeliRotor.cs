using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    public interface my_IHeliRotor
    {
        #region Methods
        void UpdateRotor(float dps, my_Input_Controller input);
        #endregion
    }
}