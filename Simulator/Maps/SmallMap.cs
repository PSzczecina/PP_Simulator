using System.Drawing;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    readonly List<Creature>? [,] _fields;
    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too wide");
        _fields = new List<Creature>[SizeX, SizeY];
    }
    public override void Add(Point point, Creature creature) { //dodaje potwora na pole
        if (_fields[point.X, point.Y] is null) _fields[point.X, point.Y] = new List<Creature>();
        _fields[point.X, point.Y].Add(creature);
    }
    public override void Remove(Point point, Creature creature) { //usuwa potwora z pola
        _fields[point.X, point.Y]?.Remove(creature);    
    }

    public override void Move(Point oldpoint, Point newpoint, Creature creature)
    {
        var y = SizeY - newpoint.Y - 1;
        Remove(oldpoint, creature);
        Add(newpoint, creature);
    }

    public override List<Creature>? At(int x, int y)
    {
        return _fields[x, y];
    }
    public override List<Creature>? At(Point point)
    {
        return _fields[point.X, point.Y];
    }
    //Add, Remove, At(x,y), At(point)
}
