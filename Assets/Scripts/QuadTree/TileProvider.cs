using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileProvider : AbstractTileProvider {

    [SerializeField]
    Tile tileTemplate;

    private Dictionary<ITileLocation, Tile> tiles;

    void Start()
    {
        tiles = new Dictionary<ITileLocation, Tile>();
    }

    public override Tile GetTileAt(ITileLocation tileLocation)
    {
        Tile tileAtLocation = null;
        if(tiles.ContainsKey(tileLocation))
        {
            tileAtLocation = tiles[tileLocation];
        }
        else
        {
            tileAtLocation = CreateNewTileAtLocation(tileLocation);
            tiles.Add(tileLocation, tileAtLocation);
        }

        return tileAtLocation;
    }

    private Tile CreateNewTileAtLocation(ITileLocation location)
    {
        Tile newTile = GameObject.Instantiate<Tile>(tileTemplate);
        Vector2 position = new Vector2(location.Col * newTile.Dimensions.x, location.Row * newTile.Dimensions.y);
        newTile.Position = position;
        return newTile;
    }
}
