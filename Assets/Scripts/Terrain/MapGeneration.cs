using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Environment
{
    public class MapGeneration : MonoBehaviour
    {
        private Tile tile;
        public int rows = 10;
        public int cols = 10;
        
        // Map containing all the tiles
        public Tile[,] map;

        void Start()
        {
            map = new Tile[rows, cols];
            GenerateMap();
        }

        private void GenerateMap()
        {
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    Tile tile = new Tile(i, 1f, j);
                    map[i, j] = tile;
                }
            }
        }
    }
}
