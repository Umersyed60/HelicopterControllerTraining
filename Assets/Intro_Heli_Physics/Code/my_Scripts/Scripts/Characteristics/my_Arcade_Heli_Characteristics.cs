using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    public class my_Arcade_Heli_Characteristics : my_Heli_Characteristics
    {
        protected override void HandleCyclic(Rigidbody _rb, my_Input_Controller input)
        {
            //base.HandleCyclic(_rb, input);
        }

        protected override void HandleLift(Rigidbody _rb, my_Input_Controller input)
        {
            //base.HandleLift(_rb, input);
        }

        protected override void HandlePedals(Rigidbody _rb, my_Input_Controller input)
        {
            //base.HandlePedals(_rb, input);
        }
    }
}
