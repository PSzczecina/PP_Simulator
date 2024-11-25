namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    internal List<Creature>?[,] _fields;
    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too wide");
        _fields = new List<Creature>[SizeX, SizeY];
    }
    public override void Add(Point point, Creature creature) { //dodaje potwora na pole
        _fields[point.X, point.Y].Add(creature);
    }
    public override void Remove(Point point, Creature creature) { //usuwa potwora z pola
        _fields[point.X, point.Y].Remove(creature);    
    }

    public override void Move(Point oldpoint, Point newpoint, Creature creature)
    {
        _fields[oldpoint.X, oldpoint.Y].Remove(creature);
        _fields[newpoint.X, newpoint.Y].Add(creature);
    }

    public override List<Creature> At(int x, int y)
    {
        return _fields[x, y];
    }
    public override List<Creature> At(Point point)
    {
        return _fields[point.X, point.Y];
    }
    //Add, Remove, At(x,y), At(point)
}
