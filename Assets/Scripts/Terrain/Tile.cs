using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum TileType 
    {
        GRASS,
        WATER,
        HOUSE,
        STORAGE,
    }

    public Material grassTexture;
    public Material waterTexture;

    public int xPos {get; set;}
    public int yPos {get; set;}
    
    public int zPos {get; set;}
    public TileType tileType;

    Tile plane; 

    public void Start() 
    {
        this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        tileType = TileType.GRASS;
    }

    public void UpdatePosition(float x, float y, float z)
    {
        this.transform.position = new Vector3(x, y, z);
    }

    public void UpdateTileType(TileType type)
    {
        tileType = type;
        UpdateTexture();
    }

    public void UpdateTexture()
    {
        if(tileType == TileType.GRASS) this.GetComponent<MeshRenderer>().material = grassTexture;
        else if(tileType == TileType.WATER) this.GetComponent<MeshRenderer>().material = waterTexture;
    }
}
