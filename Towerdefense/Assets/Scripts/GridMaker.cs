using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;



public class GridMaker : MonoBehaviour
{
    [SerializeField] GameObject Tile;
    [SerializeField] float Width, Height;
    [SerializeField] Transform Cam;
    public bool IsOffset;
     
    
    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generate()
    {
        for (int x = 0; x < Width; x++)
        {

            for (int y = 0; y < Height; y++)
            {
                GameObject SpawnedTile = Instantiate(Tile, new Vector3(x, y, 0), Quaternion.identity);
                SpawnedTile.name = $"Tile {x}, {y}";
                if (x % 2 == 0 && y % 2 != 0 || x % 2 != 0 && y % 2 == 0) {
                    IsOffset = true;
                }
                else
                {
                    IsOffset = false;
                }
                Tile.GetComponent<TileScript>().Init(IsOffset);
            }
        }
        
        Cam.position = new Vector3(Width/2 - 0.5f, Height/2 - 0.5f, -10f);
    }
}
