using Simulator.Maps;
using System.Xml.Linq;

namespace Simulator;

public class Animals : IMappable
{
    public virtual char Symbol { get { return 'A'; } }
    public Map? Map { get; private set; }
    public Point Position { get; protected set; }

    private string description;
    public string Description
    {
        get { return description; }
        set { description = Validator.Shortener(value, 3, 15, '#'); }
    }
    public virtual string ToString()
    {
        string type = GetType().Name.ToUpper();
        string output = type + ": " + Info;
        return output;
    }

    public virtual void Go(Direction dir)
    {
        if (Map == null) throw new Exception("Stwor nie znajduje się na zadnej mapie.");
        var nextpoint = Map.Next(Position, dir);
        Map.Move(Position, nextpoint, this);
        Position = nextpoint;
    }

    public void InitMapAndPosition(Map map, Point position)
    {
        Map = map;
        Position = position;
    }

    public uint Size { get; set; } = 3;
    public virtual string Info { get { return $"{Description} <{Size}>"; } }
}
