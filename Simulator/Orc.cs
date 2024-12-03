using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Orc : Creature
{
    public override string Symbol { get { return "O"; } }
    private int hunt_count;
    private int rage;
    public int Rage { 
        get { return rage; }
        set { rage = Validator.Limiter(value, 0, 10); }
    }
    public override string Info { get { return $"{Name} [{Level}][{rage}]"; } }
    public override string Power { get { return $"{Level * 7 + rage * 3}"; } }
    public void Hunt() { 
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
    public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";
}
