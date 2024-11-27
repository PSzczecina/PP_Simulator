using System.Drawing;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    readonly List<IMappable>? [,] _fields;
    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too wide");
        _fields = new List<IMappable>[SizeX, SizeY];
    }
    public override void Add(Point point, IMappable iMappable) { //dodaje potwora na pole
        if (_fields[point.X, point.Y] is null) _fields[point.X, point.Y] = new List<IMappable>();
        _fields[point.X, point.Y].Add(iMappable);
    }
    public override void Remove(Point point, IMappable iMappable) { //usuwa potwora z pola
        _fields[point.X, point.Y]?.Remove(iMappable);    
    }

    public override void Move(Point oldpoint, Point newpoint, IMappable iMappable)
    {
        var y = SizeY - newpoint.Y - 1;
        Remove(oldpoint, iMappable);
        Add(newpoint, iMappable);
    }

    public override List<IMappable>? At(int x, int y)
    {
        return _fields[x, y];
    }
    public override List<IMappable>? At(Point point)
    {
        return _fields[point.X, point.Y];
    }
    //Add, Remove, At(x,y), At(point)
}
