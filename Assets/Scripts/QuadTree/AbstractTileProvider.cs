using UnityEngine;

public abstract class AbstractTileProvider : MonoBehaviour, ITileProvider
{
    public abstract Tile GetTileAt( ITileLocation tileLocation );
}
