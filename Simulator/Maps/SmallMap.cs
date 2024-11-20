namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    List<Creature>?[,] _fields;
    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too wide");
        _fields = new List<Creature>[SizeX, SizeY];
    }
    //Add, Remove, At(x,y), At(point)
}
