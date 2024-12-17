using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator.Maps;
using Simulator;

namespace SimWeb.Pages
{
    public class IndexModel : PageModel
    {

        public int Turn { get; private set; }
        public void OnGet()
        {
            Turn = HttpContext.Session.GetInt32("Turn") ?? 1;
        }
        public void OnPost()
        {
            Turn = HttpContext.Session.GetInt32("Turn") ?? 1;
            Turn++;
            HttpContext.Session.SetInt32("Turn", Turn);
        }
    }
}
