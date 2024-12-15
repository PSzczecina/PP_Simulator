using Simulator.Maps;
using System.Diagnostics.SymbolStore;

namespace Simulator;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        //bierze wszystkie IMappable i wrzuca je do zmiennej, aby potem dać do Turnloga
        var symbs = new Dictionary<Point, char>();
        foreach (var symb in _simulation.IMappables)
        {
            if (symbs.ContainsKey(symb.Position)) symbs[symb.Position] = 'X';
            else symbs.Add(symb.Position, symb.Symbol);
        }

        TurnLogs.Add(new SimulationTurnLog()
        {

            Mappable = _simulation.MovedIMappableInfo.ToString(),
            Move = _simulation.ReturnMoveTaken(),
            Symbols = symbs
        });

        while (!_simulation.Finished)
        {
            _simulation.Turn();
            //bierze wszystkie IMappable i wrzuca je do zmiennej, aby potem dać do Turnloga
            symbs = new Dictionary<Point, char>();
            foreach (var symb in _simulation.IMappables)
            {
                if (symbs.ContainsKey(symb.Position)) symbs[symb.Position] = 'X';
                else symbs.Add(symb.Position, symb.Symbol);
            }

            TurnLogs.Add(new SimulationTurnLog()
            {

                Mappable = _simulation.MovedIMappableInfo.ToString(),
                Move = _simulation.ReturnMoveTaken(),
                Symbols = symbs
            });
        }
    }
}