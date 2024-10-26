using System.Reflection.Emit;
using System.Xml.Linq;

namespace Simulator;

internal class Creature
{
    public string Name { get; set; }
    public uint Level { get; set; }
    public string Info { get { return $"{Name} [{Level}]"; } }
    public Creature(string name, uint level=1)
    {
        Name = name;
        Level = level;
    }
    public Creature() { }

    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }
}
