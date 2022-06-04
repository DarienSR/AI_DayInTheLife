using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core; // to access waypoints
using System;

/*
    Procedurally generate the map. Making multiple passes and adding the town, hunting, trees, water, etc.
    Also adds a waypointTile associated to each zone (town, trees, hunting, etc)
*/

namespace Environment
{
    public class MapGeneration : MonoBehaviour
    {
        public GameObject tilePrefab;
        public GameObject waypointTilePrefab;
        public int rows = 100; 
        public int cols = 100; 

        EnvironmentController environmentController;
        
        // Map containing all the tiles
        public Tile[,] map;

        void Start()
        {
            map = new Tile[rows, cols];
            environmentController = GetComponent<EnvironmentController>();
            GenerateMap();
            GenerateTown();
            GenerateZone();
        }

        private void GenerateMap()
        {
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    GameObject go = (GameObject) Instantiate(tilePrefab);
                    go.transform.SetParent(GameObject.Find("Environment").transform); // organize all tiles under the Environment gameobject
                    Tile tile = go.GetComponent<Tile>();
                    tile.UpdatePosition(i, 1f, j);
                    tile.xPos = i;
                    tile.zPos = j;
                    map[i, j] = tile;
                }
            }
        }   

        void GenerateTown()
        {
            Tile waypointTile = map[rows / 3, cols / 3];  
            for(int i = 0; i < 10; i ++)
            {
                for(int j = 0; j < 10; j++)
                {
                    map[waypointTile.xPos + i, waypointTile.zPos + j].UpdateTileType(Tile.TileType.TOWN);
                }
            }
            // add waypointTile
            GameObject waypointGO = (GameObject)Instantiate(waypointTilePrefab);
            Waypoint waypoint = waypointGO.GetComponent<Waypoint>();
            // add waypoint to waypoint collection
            environmentController.AddWaypoint(waypoint, Waypoint.WaypointType.TOWN, (waypointTile.xPos + (rows / 2),  waypointTile.zPos + (cols / 2)));
        }

        // Function to generate the zones for various tile types
        private void GenerateZone()
        {            
            Noise noise = new Noise();
            float[,] noiseMap = noise.CalcNoise(rows);
            for(int i = 0; i < rows; i ++)
            {
                for(int j = 0; j < rows; j++)
                {
                    if(map[i, j].tileType == Tile.TileType.TOWN) break; // do not replace the town
                    Tile.TileType type = DetermineType(noiseMap[i, j]);
                    map[i, j].UpdateTileType(type);             
                }
            }
        }

        public Tile.TileType DetermineType(float noiseValue)
        {
            if(noiseValue < 0.3f)
                return Tile.TileType.WATER;    
            else if(noiseValue < 0.5f)            
                return Tile.TileType.HUNTING;
            else   
                return Tile.TileType.GRASS;
            
        }
    }
}
