using System.Xml.Linq;

namespace Simulator;

internal class Animals
{
    private string description;
    public string Description
    {
        get { return description; }
        set
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
            if (value.Length > 15) value = value.Substring(0, 15); //skróć jak za długie
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
                while (value.Length < 3) value = string.Concat(value, "#"); //dodaj # jeśli konieczne
                value = string.Concat(value[0].ToString().ToUpper(), value.Substring(1, value.Length - 1));
            }
            description = value;
        }
    }
    public uint Size { get; set; } = 3;
    public string Info { get { return $"{Description} <{Size}>"; } }
}
