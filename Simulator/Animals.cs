using System.Xml.Linq;

namespace Simulator;

public class Animals
{
    private string description;
    public string Description
    {
        get { return description; }
        set { description = Validator.Shortener(value, 3, 15, '#'); }
    }
    public override string ToString()
    {
        string type = GetType().Name.ToUpper();
        string output = type + ": " + Info;
        return output;
    }
    public uint Size { get; set; } = 3;
    public virtual string Info { get { return $"{Description} <{Size}>"; } }
}
