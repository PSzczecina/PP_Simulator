using Simulator.Maps;

namespace Simulator;

public class SimulationHistory
{
    public Simulation simulation { get; private set; }

    //jest problem - pozycja stworów na mapie nie działa - trzeba naprawić
    public List<Map> MapStates { get; private set; }
    public List<IMappable> MovedMappables { get; }
    public List<Point> MovedToPoints { get; }
    public List<string> Moves { get; private set; }


    public SimulationHistory(Simulation sim)
    {
        simulation = sim;
        MovedMappables = new List<IMappable>();
        MovedToPoints = new List<Point>();
        MapStates = new List<Map>();
        Moves = new List<string>();

        while (!simulation.Finished)
        {
            MovedMappables.Add(sim.CurrentIMappable);
            //trzeba naprawić
            Map temp = simulation.Map;
            MapStates.Add(temp);

            simulation.Turn();
            MovedToPoints.Add(sim.MovedIMappableInfo.Position);
        }
    }

}
