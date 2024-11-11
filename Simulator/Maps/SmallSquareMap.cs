namespace Simulator.Maps;

internal class SmallSquareMap : Map
{
    public int Size { get; init; }

    public SmallSquareMap(int size)
    {
        if (size < 5 || size>20) throw new ArgumentOutOfRangeException("Przedział wynosi <5;20>");
        Size = size;
    }
    public override bool Exist(Point p)
    {
        if (p.X>Size-1 || p.Y > Size-1 || p.X < 0 || p.Y < 0) return false;
        return true;
    }

    public override Point Next(Point p, Direction d){
        if (Exist(p.Next(d))) return p.Next(d);
        return p;
    }

    public override Point NextDiagonal(Point p, Direction d){
        if (Exist(p.NextDiagonal(d))) return p.NextDiagonal(d);
        return p;
    }
}
