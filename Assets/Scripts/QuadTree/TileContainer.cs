using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileContainer : MonoBehaviour {

    [SerializeField]
    private AbstractTileProvider tileProvider;

    [SerializeField]
    private GameObject toObserve;

    [SerializeField]
    private int tileCreationDelta = 1;

    private Tile currentTile;

    void Start()
    {
        InitializeTileField();
    }

    private void InitializeTileField()
    {
        for(int row = -tileCreationDelta; row <= tileCreationDelta; row++)
        {
            for(int col = -tileCreationDelta; col <= tileCreationDelta; col++ )
            {
                CreateTile(row, col);
            }
        }
    }

    private void CreateTile(int row, int col)
    {
        ITileLocation tileLocation = new TileLocation(row, col);
        Tile currentTile = tileProvider.GetTileAt(tileLocation);
        currentTile.transform.position = currentTile.Position;
        currentTile.transform.parent = this.transform;
        currentTile.OnTileEnter += OnTileEnter;
        currentTile.OnTileExit += OnTileExit;
    }

    private void OnTileEnter(object sender, Collision collision, Tile tile)
    {
        UpdateTiles(tile, currentTile);
        
    }

    private void OnTileExit(object sender, Collision collision, Tile tile)
    {

    }

    private void UpdateTiles(Tile newTile, Tile currentTile)
    {
        int rowChange = (int) (newTile.Position.x - currentTile.Position.x);
        int colChange = (int)( newTile.Position.y - currentTile.Position.y );

        if(Mathf.Abs(colChange) > 0)
        {
            CreateTileColumn(newTile, colChange);
        }
        if(Mathf.Abs(rowChange) > 0)
        {
            CreateTileRow(newTile, rowChange);
        }


        this.currentTile = newTile;
    }

    private void CreateTileColumn(Tile newTile, int delta)
    {
        for(int col = (int) (newTile.Position.x - tileCreationDelta); col < ( newTile.Position.x - tileCreationDelta ); col++ )
        {
            CreateTile((int)newTile.Position.y, col + delta);
        }
    }

    private void CreateTileRow(Tile newTile, int delta)
    {
        for ( int row = (int)( newTile.Position.y - tileCreationDelta ); row < ( newTile.Position.x - tileCreationDelta ); row++ )
        {
            CreateTile(row + delta, (int)newTile.Position.x);
        }
    }
}
