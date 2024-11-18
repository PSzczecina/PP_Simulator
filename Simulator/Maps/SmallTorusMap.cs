namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public int Size { get; }

    public SmallTorusMap(int size)
    {
        if (size < 5 || size >20) throw new ArgumentOutOfRangeException("size");
        else Size = size;
    }
    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.Y >= 0 && p.X<Size && p.Y<Size;
    }

    public override Point Next(Point p, Direction d)
    {
        int x, y;
        Point check = new Point(p.X, p.Y);
        check = check.Next(d);

        (x, y) = ImplementProperTorusMovement(Size, check);
        return new Point(x, y);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        int x, y;
        Point check = new Point(p.X, p.Y);
        check = check.NextDiagonal(d);

        (x, y) = ImplementProperTorusMovement(Size, check);
        return new Point(x, y);
    }

    private (int, int) ImplementProperTorusMovement(int size, Point outcome)
    {
        int x, y;
        if (outcome.X < 0) x = outcome.X + Size;
        else if (outcome.X >= Size) x = outcome.X - Size;
        else x = outcome.X;

        if (outcome.Y < 0) y = outcome.Y + Size;
        else if (outcome.Y >= Size) y = outcome.Y - Size;
        else y = outcome.Y;
        return (x, y);
    }

}
