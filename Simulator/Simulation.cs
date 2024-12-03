using Simulator.Maps;
using System.Runtime.CompilerServices;

namespace Simulator;

public class Simulation
{
    private int iMappable_position_id = 0; //do odliczania ruchu oraz którego potwora i pozycji tura to jest
    private int turnCounter = 0;
    public int TurnCounter { get { return turnCounter; } }
    private IMappable? movedIMappable;
    private string? moveTaken;
    //public string ReturnMovedIMappablePosition() => movedIMappable.Position.ToString();
    public IMappable MovedIMappableInfo;
    public string ReturnMoveTaken() => moveTaken;

    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// IMappables moving on the map.
    /// </summary>
    public List<IMappable> IMappables { get; }

    /// <summary>
    /// Starting positions of iMappables.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of iMappables moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first iMappable, second for second and so on.
    /// When all iMappables make moves, 
    /// next move is again for first iMappable and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// IMappable which will be moving current turn.
    /// </summary>
    public IMappable CurrentIMappable { get { return IMappables[iMappable_position_id%IMappables.Count]; }/* implement getter only */ }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName { get { return Moves[iMappable_position_id].ToString(); }/* implement getter only */ }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if iMappables' list is empty,
    /// if number of iMappables differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> iMappables,
        List<Point> positions, string moves)
    {
        if (iMappables.Count == 0) throw new ArgumentException("IMappables are mandatory for Simulation.");
        if (positions.Count != iMappables.Count) throw new ArgumentException("Numbers of iMappables and positions don't align with eachother.");
        Map = map;
        IMappables = iMappables;
        Positions = positions;
        for (int i = 0; i < iMappables.Count; i++) {
            IMappables[i].InitMapAndPosition(Map, Positions[i]);
            Map.Add(Positions[i], IMappables[i]);
        }
        Moves = moves;  //DirectionParser.Parse(moves).ToString();
    }

    /// <summary>
    /// Makes one move of current iMappable in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() {
        if (Finished) {
            throw new Exception("End of simulation");
        }
        MovedIMappableInfo = CurrentIMappable;
        //ten segment sprawdza czy teraźniejszy element w Moves jest poprawny. Jak nie - usuwa go i sprawdza następny
        var current_move = DirectionParser.Parse(CurrentMoveName);
        while (!current_move.Any())
        {
            Moves.Remove(iMappable_position_id);
            current_move = DirectionParser.Parse(CurrentMoveName);
        }

        CurrentIMappable.Go(current_move[0]); //wykonaj ruch
        movedIMappable = CurrentIMappable;
        moveTaken = CurrentMoveName;

        iMappable_position_id++;
        turnCounter++;
        if (iMappable_position_id >= Moves.Length) Finished = true;
    }
}