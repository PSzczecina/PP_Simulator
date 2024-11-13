using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Birds : Animals
{
    private bool canFly = true;
    public bool CanFly {  
        get { return canFly; }
        set { canFly = value; }
    }
    public override string Info { get {
            string fly = "", output = " ";
            if (canFly) fly = "fly+";
            else fly = "fly-";
                output = $"{Description[0].ToString().ToUpper() + Description.Substring(1)} ({fly}) <{Size}>";
            return output; 
        } }
}
