using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Environment
{
    public class MapGeneration : MonoBehaviour
    {
        public GameObject tilePrefab;
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
                    GameObject go = (GameObject) Instantiate(tilePrefab);

                    Tile tile = go.GetComponent<Tile>();
                    tile.UpdatePosition(i, 1f, j);
                    map[i, j] = tile;
                }
            }
        }
    }
}
