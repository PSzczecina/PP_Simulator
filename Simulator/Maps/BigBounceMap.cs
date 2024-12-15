namespace Simulator.Maps;

public class BigBounceMap : BigMap
{
    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    //ciekawe jest zachowanie latających ptaków -
    //kolejno: idą w ścianę pierwszy krok > odbijają się w drugą stronę > idą drugi krok do ścian.
    //Kończą w tym samym miejscu co wcześniej

    //ten konstruktor jest potrzebny aby działał simulationHistory. Być może usunę, jak uznam że jest lepszy sposób na to.
    public BigBounceMap(int sizeX, int sizeY, Dictionary<Point, List<IMappable>> _fields) : base(sizeX, sizeY) { 
        this._fields = _fields;
    }
    public BigBounceMap DeepCopy()
    {
        return new BigBounceMap(this.SizeX, this.SizeY, this._fields);
    }

    //update - teraz po prostu odbija się od ściany o 1 - czemu, to już inne pytanie
    //jak stoją 1 pole od ściany i udeżyłyby w nią - stoją w miejscu
    //?
    //?
    public override Point Next(Point p, Direction d)
    {
        int x, y;
        Point check = new Point(p.X, p.Y);
        check = check.Next(d);

        (x, y) = ImplementBounce(SizeX, SizeY, check, p);
        if ((x, y) == (0, 0)) return p;
        return new Point(x, y);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        int x, y;
        Point check = new Point(p.X, p.Y);
        check = check.NextDiagonal(d);

        (x, y) = ImplementBounce(SizeX, SizeY, check, p);
        if ((x, y) == (0, 0)) return p;
        return new Point(x, y);
    }

    private (int, int) ImplementBounce(int SizeX, int SizeY, Point outcome, Point current)
    {
        int x, y;
        if (!_map.Contains(outcome))
        {
            x = 2 * current.X - outcome.X;
            y = 2*current.Y - outcome.Y;
            if (!_map.Contains(new Point(x, y))) { return (0, 0); }
            return (x, y);
        }
        return (outcome.X, outcome.Y);
    }
}
