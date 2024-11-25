using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    private int creature_position_id=0; //do odliczania ruchu oraz którego potwora i pozycji tura to jest

    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature { get { return Creatures[creature_position_id%Creatures.Count]; }/* implement getter only */ }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName { get { return Moves[creature_position_id].ToString(); }/* implement getter only */ }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (creatures.Count == 0) throw new ArgumentException("Creatures are mandatory for Simulation.");
        if (positions.Count != creatures.Count) throw new ArgumentException("Numbers of creatures and positions don't align with eachother.");
        Map = map;
        Creatures = creatures;
        Positions = positions;
        for (int i = 0; i < creatures.Count; i++) {
            Creatures[i].InitMapAndPosition(Map, Positions[i]); 
        }
        Moves = DirectionParser.Parse(moves).ToString();
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() {
        if (Finished) {
            throw new Exception("End of simulation");
        }

        CurrentCreature.Go(DirectionParser.Parse(CurrentMoveName)[0]); //wykonaj ruch

        creature_position_id++;
        if (creature_position_id >= Moves.Length) Finished = true;
    }
}