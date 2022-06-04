using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Environment
{

    /* https://docs.unity3d.com/ScriptReference/Mathf.PerlinNoise.html */
    public class Noise 
    {
        // The origin of the sampled area in the plane.
        public float xOrg = 0.5f;
        public float yOrg = 0.7654f;

        // The number of cycles of the basic noise pattern that are repeated
        // over the width and height of the texture.
        public float scale = 0.8643f;

        public float[,] CalcNoise(int size)
        {
            float[,] pix = new float[size, size];
            // For each pixel in the texture...

            for(int i = 0; i < size; i++)
            {

                for(int j = 0; j < size; j++)
                {
                    float xCoord = (xOrg + i) / size * scale * 1.34f;
                    float yCoord = (yOrg + j) / size * scale;
                    float sample = Mathf.PerlinNoise(xCoord, yCoord);
                    pix[i, j] = sample;
                }
            }
            return pix;
        }
    }
}
    
