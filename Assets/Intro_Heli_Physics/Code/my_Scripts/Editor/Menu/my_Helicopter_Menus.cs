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
            GameObject engineGRP = new GameObject("Engine_GRP");
            SetupEngineGRP(engineGRP, newHeliController);
            GameObject rotorGRP = new GameObject("Rotor_GRP");
            SetupRotorGRP(rotorGRP, newHeliController);

            audioGRP.transform.SetParent(newHeli.transform);
            graphicsGRP.transform.SetParent(newHeli.transform);
            colGRP.transform.SetParent(newHeli.transform);
            engineGRP.transform.SetParent(newHeli.transform);
            rotorGRP.transform.SetParent(newHeli.transform);

            //Select newHeli in Hierarchy
            Selection.activeGameObject = newHeli;
        }

        static void SetupRotorGRP(GameObject rotorgo, my_Heli_Controller controller)
        {
            my_Heli_Rotor_Controller rotorController = rotorgo.AddComponent<my_Heli_Rotor_Controller>();
            controller.rotorCtrl = rotorController;

            GameObject mainGRP = new GameObject("Main_Rotor");
            mainGRP.AddComponent<my_HeliMain_Rotor>();
            GameObject tailGRP = new GameObject("Tail_Rotor");
            tailGRP.AddComponent<my_HeliTail_Rotor>();

            mainGRP.transform.SetParent(rotorgo.transform);
            tailGRP.transform.SetParent(rotorgo.transform);
        }

        static void SetupEngineGRP(GameObject enginego, my_Heli_Controller controller)
        {
            GameObject engineGRP = new GameObject("Main_Engine");
            my_Heli_Engine engine = engineGRP.AddComponent<my_Heli_Engine>();
            controller.engines.Add(engine);

            engineGRP.transform.SetParent(enginego.transform);
        }
    }
}
