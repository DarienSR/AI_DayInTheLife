using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public enum TileType 
    {
        GRASS,
        WATER,
        HOUSE,
        STORAGE,
        
    }

    public int xPos {get; set;}
    public int yPos {get; set;}
    
    public int zPos {get; set;}
    public TileType type;

    GameObject plane; 

    public Tile(float x, float y, float z) 
    {
        plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        type = TileType.GRASS;
        UpdatePosition(x, y, z);
    }

    public void UpdatePosition(float x, float y, float z)
    {
        plane.transform.position = new Vector3(x, y, z);
    }
}
