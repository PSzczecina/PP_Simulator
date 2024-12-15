using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimConsole
{
    public class LogVisulizer
    {
        SimulationHistory Log { get; }
        public LogVisulizer(SimulationHistory log)
        {
            Log = log;
        }

        public void Draw(int turnIndex)
        {
            //wypisuje Mappabla, jego info i pozycję oraz jaki ruch wykonał aby się dostać na swoją pozycję
            var curturn = Log.TurnLogs[turnIndex];
            Console.WriteLine(curturn.Mappable);
            Console.WriteLine("wykonał ruch: "+curturn.Move);
            //Console.WriteLine(curturn.Symbols.First());
        }
    }
}
