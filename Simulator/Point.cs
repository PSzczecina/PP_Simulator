namespace Simulator;

public readonly struct Point
{
    public readonly int X, Y;
    public Point(int x, int y) => (X,Y) = (x,y);
    public override string ToString() => $"({X}, {Y})";

    public Point Next (Direction direction, int moveMultip=1)
    {
        return direction switch
        {
            Direction.Left => new Point(X - 1*moveMultip, Y),
            Direction.Right => new Point(X + 1*moveMultip, Y),
            Direction.Up => new Point(X, Y + 1 * moveMultip),
            Direction.Down => new Point(X, Y - 1 * moveMultip),
            _ => new Point(X, Y),
        };
    }
    public Point NextDiagonal(Direction direction)
    {
        return direction switch
        {
            Direction.Left => new Point(X - 1, Y + 1),
            Direction.Right => new Point(X + 1, Y - 1),
            Direction.Up => new Point(X+1,Y+1),
            Direction.Down => new Point(X-1,Y-1),
            _ => new Point(X, Y),
        };
    }
}
