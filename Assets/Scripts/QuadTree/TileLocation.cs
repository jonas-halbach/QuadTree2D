﻿public class TileLocation : ITileLocation
{
    public TileLocation(int row, int col)
    {
        Row = row;
        Col = col;
    }

    public int Row
    {
        get; set;
    }

    public int Col
    {
        get; set;
    }
}
