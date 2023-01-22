using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    private IGenerationTemplate generationImplementation;

    List<TileData> mapData = new List<TileData>();

    [SerializeField]
    Tilemap myTilemap;

    [SerializeField]
    Tile walkableTile, borderTile;

    // Start is called before the first frame update
    void Start()
    {
        generationImplementation = new DevOverworld();

        mapData = generationImplementation.Generate();

        Tile tileToPlace;
        foreach (var tileData in mapData)
        {
            tileToPlace = borderTile;
            if (tileData.IsWalkable) tileToPlace = walkableTile;
            myTilemap.SetTile(new Vector3Int(tileData.X, tileData.Y, 1), tileToPlace);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
