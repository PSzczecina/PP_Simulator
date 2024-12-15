﻿namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public virtual void Add(Point point, IMappable iMappable)
    {
        if (!_fields.ContainsKey(point)) _fields.Add(point, new List<IMappable>());
        _fields[point].Add(iMappable);
    }

    public virtual void Remove(Point point, IMappable iMappable)
    {
        _fields[point]?.Remove(iMappable);
    }
    public abstract void Move(Point oldpoint, Point newpoint, IMappable iMappable);


    public virtual List<IMappable>? At(int x, int y){
        var p = new Point(x, y);
        if (!_fields.ContainsKey(p)) return null;
        return _fields[p];
    }
    //At(x,y)
    public virtual List<IMappable>? At(Point point)
    {
        if (!_fields.ContainsKey(point)) return null;
        return _fields[point];
    }
    //At(point)

    protected Dictionary<Point, List<IMappable>> _fields;

    public int SizeX { get; }
    public int SizeY { get; }

    protected readonly Rectangle _map;
    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow");
        if (sizeY < 5) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too narrow");
        SizeX = sizeX;
        SizeY = sizeY;
        _map = new Rectangle(0, SizeX - 1, 0, SizeY-1);
    }

    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) => _map.Contains(p);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}