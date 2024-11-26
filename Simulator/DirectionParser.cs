using System.Runtime.CompilerServices;

namespace Simulator;

public static class DirectionParser
{
    public static List<Direction> Parse(string text)
    {
        List<Direction> output = new();
        text = text.ToLower();
        int output_order = 0;

        for (int i = 0; i<text.Length;i++)
        {
            switch (text[i])
            {
                default:
                    break;
                case 'u':
                    output.Add(Direction.Up); output_order++;
                    break;
                case 'r':
                    output.Add(Direction.Right);output_order++;
                    break;
                case 'd':
                    output.Add(Direction.Down); output_order++;
                    break;
                case 'l':
                    output.Add(Direction.Left); output_order++;
                    break;
            }
        }
        
        return output;

    }
    public static string ToString() {
        return "";

    }
}
