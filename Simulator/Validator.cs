using System.Xml.Linq;

namespace Simulator;

public static class Validator
{
    public static int Limiter(int value, int min, int max) {
        if (value < min) { value = min; }
        else if (value > max) { value = max; }
        return value;
    }
    public static string Shortener(string value, int min, int max, char placeholder)
    {
        var check_front_spaces = true;
        var check_back_spaces = true;
        while (check_front_spaces == true) //usuń spacje początkowe
        {
            if (value.Length > 0)
            {
                if (value[0].ToString() == " " && value.Length > 0)
                {
                    value = value.Remove(0, 1);
                }
                else { check_front_spaces = false; }
            }
            else { check_front_spaces = false; }
        }
        if (value.Length > max) value = value.Substring(0, max); //skróć jak za długie
        while (check_back_spaces == true) //usuń spacje końcowe
        {
            if (value.Length > 0)
            {
                if (value[value.Length - 1].ToString() == " ")
                {
                    value = value.Remove(value.Length - 1, 1);
                }
                else { check_back_spaces = false; }
            }
            else { check_back_spaces = false; }
        }
        if (string.IsNullOrWhiteSpace(value)) { value = "Unknown"; } //sprawdź czy jest cokolwiek poza spacją - bo jak nie, to równie dobrze mogłoby nic nie być podane
        else
        {
            while (value.Length < min) value = string.Concat(value, "#"); //dodaj # jeśli konieczne
            value = string.Concat(value[0].ToString().ToUpper(), value.Substring(1, value.Length - 1));
        }
        return value;
    }
}

