using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Elf : Creature
{
    private int sing_count;
    private int agility;
    public int Agility {
        get { return agility; }
        init { agility = Validator.Limiter(value, 0, 10); }
    }
    public override string Info { get { return $"{Name} [{Level}][{agility}]"; } }
    public override string Power { get { return $"{Level*8+agility*2}"; } }
    public Elf() { }
    public Elf(string name, int level = 1, int agility=1) : base(name, level) {
        //if (agility <0) agility = 0; 
        //else if (agility > 10) agility = 10;
        Agility = agility;
        //Name = name;
        //Level = level;
        sing_count = 0;
    }
    public void Sing() { 
        sing_count++;
        if (sing_count == 3)
        {
            sing_count = 0;
            if (agility < 10) agility++;
        }
    }
    public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";
}
