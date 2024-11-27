﻿using Simulator.Maps;
using System.ComponentModel.DataAnnotations;

namespace Simulator;
/*
 * var check_front_spaces = true;
            var check_back_spaces = true;
            while (check_front_spaces == true) //usuń spacje początkowe
            {
                if (value.Length > 0) { 
                    if (value[0].ToString() == " " && value.Length > 0) { 
                        value = value.Remove(0, 1); 
                    } else { check_front_spaces = false; }
                } else { check_front_spaces = false; }
            }
            if (value.Length > 25) value = value.Substring(0, 25); //skróć jak za długie
            while (check_back_spaces == true) //usuń spacje końcowe
            {
                if (value.Length > 0)
                {
                    if (value[value.Length - 1].ToString() == " ") { 
                        value = value.Remove(value.Length - 1, 1); 
                    } else { check_back_spaces = false; }
                } else { check_back_spaces = false; }
            }
            if (string.IsNullOrWhiteSpace(value)) { value = "Unknown"; } //sprawdź czy jest cokolwiek poza spacją - bo jak nie, to równie dobrze mogłoby nic nie być podane
            else
            {
                while (value.Length < 3) value = string.Concat(value, "#"); //dodaj # jeśli konieczne
                value = string.Concat(value[0].ToString().ToUpper(), value.Substring(1, value.Length - 1));
            }
 */

public abstract class Creature : IMappable
{
    public Map? Map { get; private set; }
    public Point Position { get; private set; }

    public void InitMapAndPosition(Map map, Point position)
    {
        Map = map;
        Position = position;
    }

    private string name = "Unknown";
    public string Name
    {
        get { return name; }
        init {
            name = Validator.Shortener(value, 3, 25, '#'); }
    }

    private int level;
    public int Level
    {
        get { return level; }
        init { level = Validator.Limiter(value,0,10); }
    }
    public virtual string Info { get { return $"{Name} [{Level}]"; } }
    public virtual string Power { get { return $"{level * 2}"; } }
    public override string ToString()
    {
        string type = GetType().Name.ToUpper();
        string output = type + ": "+ Info;
        return output;
    }
    public Creature(string name="Unknown", int level=1)
    {
        Name = name;
        Level = level;
    }
    public Creature() { }

    public virtual string Greeting()
    {
        return $"Hi, I'm {Name}, my level is {Level}.";
    }
    public void Upgrade()
    {
        if (level < 10) level++;
    }
    public void Go(Direction dir) {
        if (Map == null) throw new Exception("Stwor nie znajduje się na zadnej mapie.");
        var nextpoint = Map.Next(Position, dir);
        Map.Move(Position, nextpoint, this);
        Position = nextpoint;
    } 
}
