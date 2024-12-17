using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator.Maps;
using Simulator;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace SimWeb.Pages
{
    public class PrivacyModel : PageModel
    {
        //z góry ustalona symulacja
        public SimulationHistory SetSimHistory()
        {
            BigBounceMap map = new(8, 6);

            List<IMappable> creatures = [new Orc("Gorbag"),
            new Elf("Elandor"),
            new Birds() { CanFly = false, Description = "Strus", Size=6 },
            new Birds() { CanFly = true, Description = "orly", Size=13 },
            new Animals() { Description = "kroliki", Size = 7 }];
            List<Point> points = [new(0, 0),
            new(7, 5),
            new(2, 2),
            new(5, 5),
            new(4, 1)];
            string moves = "lrduuulrdduullrdrrud";

            Simulation sim = new(map, creatures, points, moves);
            SimulationHistory simHistory = new(sim);
            return simHistory;
        }
        public string ReturnGridHTML(SimulationHistory Histlog, int turn)
        {
            string output = "";
            for (int i = 0; i < Histlog.SizeY; i++)
            {
                for (int j = 0; j< Histlog.SizeX; j++)
                {
                    string symbol;
                    if (!Histlog.TurnLogs[turn].Symbols.ContainsKey(new Point(j, i))) symbol = "";
                    else symbol = Histlog.TurnLogs[turn].Symbols[new Point(j, i)].ToString();
                    if (symbol == "b") symbol = "Bnl";
                    else if (symbol == "B") symbol = "Bl";
                    else if (symbol == "") symbol = "Blank";
                    {
                        
                    }

                    string image = $"<img src=\"/css/{symbol}.png\">";
                    output += $"<div class=\"grid-item\">{image}</div>";
                }
            }
            return output;
        }

        public string GridHTML { get; private set; } = "";

        public SimulationHistory? SimHistory { get; private set; }
        public int Turn { get; private set; }
        public string Info { get; private set; } = "<tba>";
        public void OnGet()
        {
            Turn = HttpContext.Session.GetInt32("Turn") ?? 0;
            HttpContext.Session.SetInt32("Turn", Turn);
            SimHistory = SetSimHistory();
            GridHTML = HttpContext.Session.GetString("grid") ?? ReturnGridHTML(SimHistory, Turn);
        }


        public void OnPost()
        {
            Turn = HttpContext.Session.GetInt32("Turn") ?? 0;
            string action = Request.Form["turnchange"];
            if (action == "prev") Turn--;
            else if (action == "next") Turn++;

            if (Turn < 0) Turn = 0;
            else if (Turn > 20) Turn = 20;
            HttpContext.Session.SetInt32("Turn", Turn);
            SimHistory = SetSimHistory();
            GridHTML = ReturnGridHTML(SimHistory, Turn);
        }


    }

}
