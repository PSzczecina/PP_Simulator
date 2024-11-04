using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Elf : Creature
{
    private int sing_count;
    private int agility;
    public int Agility {
        get { return agility; }
        set
        {
            if (value < 0) value = 0;
            else if (value > 10) value = 10;
            agility = value;
        }
    }
    public override string Power { get { return $"{Level*8+agility*2}"; } }
    public Elf() { }
    public Elf(string name, int level = 1, int agility=1) : base(name, level) {
        if (agility <0) agility = 0; 
        else if (agility > 10) agility = 10;
        Agility = agility;
        Name = name;
        Level = level;
        sing_count = 0;
    }
    public void Sing() { 
        Console.WriteLine($"{Name} is singing.");
        sing_count++;
        if (sing_count == 3)
        {
            sing_count = 0;
            if (Agility < 10) Agility++;
        }
    }
    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
}
