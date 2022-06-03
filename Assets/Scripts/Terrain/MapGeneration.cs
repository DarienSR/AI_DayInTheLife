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
        private int rows = 100;
        private int cols = 100;

        EnvironmentController environmentController;
        
        // Map containing all the tiles
        public Tile[,] map;

        void Start()
        {
            map = new Tile[rows, cols];
            environmentController = GetComponent<EnvironmentController>();
            GenerateMap();

            GenerateZone(Tile.TileType.TOWN,  Waypoint.WaypointType.TOWN, 20, 30);
            GenerateZone(Tile.TileType.WATER,  Waypoint.WaypointType.WATER);
            GenerateZone(Tile.TileType.HUNTING,  Waypoint.WaypointType.HUNTING);

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

        // Function to generate the zones for various tile types
        private void GenerateZone(Tile.TileType tileType, Waypoint.WaypointType waypointType, int lowerLimit = 10, int upperLimit = 21)
        {
            // choose waypointTile randomly
            Tile waypointTile = waypointTile = map[UnityEngine.Random.Range(0, rows - 1), UnityEngine.Random.Range(0, rows - 1)];  

            int size = UnityEngine.Random.Range(lowerLimit, upperLimit);
            for(int i = 0; i < size; i ++)
            {
                for(int j = 0; j < size; j++)
                {
                    try
                    {
                        if(map[waypointTile.xPos + i, waypointTile.zPos + j].tileType == Tile.TileType.GRASS) // only convert grass tiles
                            map[waypointTile.xPos + i, waypointTile.zPos + j].UpdateTileType(tileType);
                    }
                    catch(Exception e)
                    {

                    }
                }
            }
            // add waypointTile
            GameObject waypointGO = (GameObject)Instantiate(waypointTilePrefab);
            Waypoint waypoint = waypointGO.GetComponent<Waypoint>();
            // add waypoint to waypoint collection
            environmentController.AddWaypoint(waypoint, waypointType, (waypointTile.xPos + (size / 2),  waypointTile.zPos + (size / 2)));
        }
    }
}
