using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace My_Practice
{
    public class my_Helicopter_Menus
    {
        [MenuItem("My Practice/Vehicles/Setup New Helicopter")]
        public static void BuildNewHelicopter()
        {
            //Create a new Helicopter Setup
            GameObject newHeli = new GameObject("New Helicopter", typeof(my_Heli_Controller));

            //Create the COG object for the Helicopter
            GameObject newCOG = new GameObject("COG");
            newCOG.transform.SetParent(newHeli.transform);

            //Assign the COG to the newHeli
            my_Heli_Controller newHeliController = newHeli.GetComponent<my_Heli_Controller>();
            newHeliController.cog = newCOG.transform;

            //Create other group objects for newHeli
            GameObject audioGRP = new GameObject("Audio_GRP");
            GameObject graphicsGRP = new GameObject("Graphics_GRP");
            GameObject colGRP = new GameObject("Collision_GRP");

            audioGRP.transform.SetParent(newHeli.transform);
            graphicsGRP.transform.SetParent(newHeli.transform);
            colGRP.transform.SetParent(newHeli.transform);
            
            //Select newHeli in Hierarchy
            Selection.activeGameObject = newHeli;
        }
    }
}
