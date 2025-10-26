using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace My_Practice
{
    public class my_Rotor_Blur : MonoBehaviour, my_IHeliRotor
    {
        #region Variables
        [Header("Rotor Blur Properties")]
        public float maxDps = 1000f;
        public List<GameObject> blades = new List<GameObject>();
        public GameObject blurGeo;

        public List<Texture2D> blurTextures = new List<Texture2D>();
        public Material blurMat;
        #endregion

        #region BuiltIn Methods
        void Start()
        {

        }
        #endregion

        #region Interface Methods
        public void UpdateRotor(float dps, my_Input_Controller input)
        {
            //Debug.Log("Blurring Main Rotor");
            float normalizedDPS = Mathf.InverseLerp(0f, maxDps, dps);
            int blurTextID = Mathf.FloorToInt(normalizedDPS * blurTextures.Count - 1);
            blurTextID = Mathf.Clamp(blurTextID, 0, blurTextures.Count - 1);

            //Check to see if we have blur textures and a blur material
            if (blurMat && blurTextures.Count > 0)
            {
                blurMat.SetTexture("_MainTex", blurTextures[blurTextID]);
            }

            //Handle the Geo Blades Visibility
            if (blurTextID > 2 && blades.Count > 0)
            {
                HandleGeoBladeViz(false);
            }
            else
            {
                HandleGeoBladeViz(true);
            }
        }
        #endregion

        #region Custom Methods
        void HandleGeoBladeViz(bool viz)
        {
            foreach (var blade in blades)
            {
                blade.SetActive(viz);
            }
        }
        #endregion
    }
}
