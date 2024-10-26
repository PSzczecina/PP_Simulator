namespace Simulator;

internal static class DirectionParser
{
    public static Direction[] Parse(string text)
    {
        Direction[] output = new Direction[text.Length];
        text = text.ToLower();
        int output_order = 0;

        for (int i = 0; i<text.Length;i++)
        {
            switch (text[i])
            {
                default:
                    break;
                case 'u':
                    output[output_order] = Direction.Up; output_order++;
                    break;
                case 'r':
                    output[output_order] = Direction.Right;output_order++;
                    break;
                case 'd':
                    output[output_order] = Direction.Down; output_order++;
                    break;
                case 'l':
                    output[output_order] = Direction.Left; output_order++;
                    break;
            }
        }
        Direction[] temp = new Direction[output_order];
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i] = output[i];
        }
        output = temp;
        return output;

    }
}
