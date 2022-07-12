using System.Drawing;

namespace ShipsGame;

public class Coord
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsAvailable { get; set; }

    public Coord(int x, int y)
    {
        X = x;
        Y = y;
        IsAvailable = true;
    }
}