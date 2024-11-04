using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Orc : Creature
{
    private int hunt_count;
    private int rage;
    public int Rage { 
        get { return rage; }
        set {
            if (value < 0) value = 0;
            else if (value > 10) value = 10; 
            rage = value; }
    }
    public override string Power { get { return $"{Level * 7 + rage * 3}"; } }
    public void Hunt() { 
        Console.WriteLine($"{Name} is hunting.");
        hunt_count++;
        if (hunt_count==2)
        {
            hunt_count = 0;
            if (Rage < 10) Rage++;
        }
    }

    public Orc(): base() { }
    public Orc(string name, int level = 1, int rage = 1): base(name, level)
    {
        if (rage <0) rage = 0;
        else if (rage > 10) rage = 10;
        Rage = rage;
        Name = name;
        Level = level;
        hunt_count = 0;
    }
    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
}
