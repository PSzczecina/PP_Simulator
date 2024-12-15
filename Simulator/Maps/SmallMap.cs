using System.Drawing;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    //readonly List<IMappable>? [,] _fields;
    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too wide");
        _fields = new Dictionary<Point, List<IMappable>>();
    }

    public override void Move(Point oldpoint, Point newpoint, IMappable iMappable)
    {
        var y = SizeY - newpoint.Y - 1;
        Remove(oldpoint, iMappable);
        Add(newpoint, iMappable);
    }

    
    //Add, Remove, At(x,y), At(point)
}
