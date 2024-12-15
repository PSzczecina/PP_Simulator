using Simulator;
using Simulator.Maps;
namespace SimConsole;

//do zrobienia - rozjebane to je
public class MapVisualizer
{
    public Map Map { get; private set; }
    public MapVisualizer(Map _map) {
        Map = _map;
    }

    public string Display { get; private set; }
    /*
     * Mapa jest rysowana tak, że X idzie w prawo, a Y w dół
     * 
     * zatem Direction.Down wskazuję *w stronę* Y=0, 
     * Direction.Up *z dala od* Y=0
     * 
     * Direction.Left w stronę X=0
     * Direction.Right z dala od X=0
     */
    public void Draw()
    {
        Display = "";
        DrawMapRows(-1);
        for (int j = 0; j < Map.SizeY; j++) //kolumny
        {
            if (j == 0) DrawMapRows(0);
            else DrawMapRows(1);
            for (int i = 0; i < Map.SizeX*2+1; i++)  { //wiersze - szerokości X*2+1, bo |o| |e| == trzy miejsca i 4 segmenty mapy
                if (i == 0) Display+=($"{j,-3}");
                if (i % 2 == 0) Display+=(Box.Vertical);
                else
                {//tutaj kod czy pojawia się stwór czy nic
                    if (Map.At(i/2, j) is not null)
                    {
                        if (Map.At(i / 2, j).Count > 1) Display+=("X");
                        else if (Map.At(i / 2, j).Count == 0) Display+=(" ");
                        else Display+=(Map.At(i / 2, j)[0].Symbol);
                    }
                    else Display+=(" ");
                }
            }
            Display+= ("\n");
        }
        DrawMapRows(2);
        Display+= ("\n");
    }

    //na wszelki stworzę nową metodę do tego - ona, zamiast brać pole _fields z mapy, bierze podany słownik stworów.
    //założenie jest takie, że wrzuci się pasujący słownik i będzie sprawdzać czy ten słownik ma punkt jaki teraz rysuje
    public void Draw(Dictionary<Point,char> entities)
    {
        Display = "";
        DrawMapRows(-1);
        for (int j = 0; j < Map.SizeY; j++) //kolumny
        {
            if (j == 0) DrawMapRows(0);
            else DrawMapRows(1);
            for (int i = 0; i < Map.SizeX * 2 + 1; i++)
            { //wiersze - szerokości X*2+1, bo |o| |e| == trzy miejsca i 4 segmenty mapy
                if (i == 0) Display += ($"{j,-3}");
                if (i % 2 == 0) Display += (Box.Vertical);
                else
                {//tutaj kod czy pojawia się stwór czy nic
                    if (entities.ContainsKey(new Point(i/2,j)) )
                    {
                        Display += entities[new Point(i / 2, j)];
                    }
                    else Display += (" ");
                }
            }
            Display += ("\n");
        }
        DrawMapRows(2);
        Display += ("\n");
    }

    private void DrawMapRows(int position) //position: 0-top, 1-middle, 2-bottom, -1-legenda do Y
    {
        if (position == -1) Display+=("y\\x");
        else Display+=("   ");
        for (int i = 0; i < Map.SizeX*2+1; i++)
        {
            if (position == 0)
            {
                if (i == 0) Display+=(Box.TopLeft);
                else if (i == Map.SizeX*2) Display+=(Box.TopRight);
                else if (i%2==0) Display+=(Box.TopMid);
                else Display+=(Box.Horizontal);
            } 
            else if (position == 1)
            {
                if (i == 0) Display+=(Box.MidLeft);
                else if (i == Map.SizeX*2) Display+=(Box.MidRight);
                else if (i % 2 == 0) Display+=(Box.Cross);
                else Display+=(Box.Horizontal);
            }
            else if (position == 2)
            {
                if (i == 0) Display+=(Box.BottomLeft);
                else if (i == Map.SizeX*2) Display+=(Box.BottomRight);
                else if (i % 2 == 0) Display+=(Box.BottomMid);
                else Display+=(Box.Horizontal);
            }
            else if (position == -1)
            {
                if (i % 2 == 1) Display+=(i / 2); 
                else Display+=(" ");
            }
        }
        Display+=("\n");
    }

    public void DisplayCreatureInfo(string info, int turn, string dir, string position="<TBA>", string start = "<TBA>")
    {
        Console.WriteLine($"Tura {turn}.");
        Console.WriteLine($"{info} ruszył z pozycji {start} na pozycje {position}.");
        Console.WriteLine($"Był to kierunek: {dir}");
    }

    public void SetMap(Map _map)
    {
        this.Map = _map;
    }

    public void DisplayMap()
    {
        Console.WriteLine(Display);
    }
}
