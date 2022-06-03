using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum TileType 
    {
        GRASS,
        WATER,
        HUNTING,
        TOWN,
        STORAGE,
    }

    public Material grassTexture;
    public Material waterTexture;
    public Material huntingTexture;
    public Material townTexture;

    public int xPos {get; set;} 
    public int yPos {get; set;} // height
    
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
        else if (tileType == TileType.HUNTING) this.GetComponent<MeshRenderer>().material = huntingTexture;
        else if (tileType == TileType.TOWN) this.GetComponent<MeshRenderer>().material = townTexture;
    }

    // return list of tile neighbour positions
    public (int, int)[] GetNeighbours()
    {
        // access by list[index].x or list[index].z
        return new (int, int)[]
        {
            (zPos + 1, xPos - 1), // left corner up
            (zPos + 1, xPos), // center up
            (zPos + 1, xPos + 1), // right corner up

            (zPos, xPos - 1), // left center
            (zPos, xPos + 1), // right center

            (zPos - 1, xPos - 1), // left corner down
            (zPos - 1, xPos), // center down
            (zPos - 1, xPos + 1), // right corner down       
        };
    }
}
