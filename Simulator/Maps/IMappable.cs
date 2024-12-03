namespace Simulator.Maps;

public interface IMappable
{
    Point Position {  get; }
    string Info { get; }
    string Symbol { get; }
    void Go(Direction direction);
    void InitMapAndPosition(Map map, Point point);
}
