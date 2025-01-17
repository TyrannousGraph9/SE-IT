using System;

class Organisme2
{
    public string _naam { get; private set; }
    public string _oorsprong { get; set; }
    public Type _type { get; set; }

    public enum Type
    {
        Plant,
        Dier
    }

    public Organisme2()
    {
        
    }

    public void TypeVanuitString(string type)
    {
        if (Enum.TryParse(type, true, out Type result))
        {
            _type = result;
        }
        else
        {
            Console.WriteLine("Ongeldige invoer.");
            Program.Main();
        }
    }

    public void WijzigNaam(string nieuweNaam)
    {
       bool isTrue = IsValidName(nieuweNaam);

       if(isTrue)
       {
           _naam = nieuweNaam;
            Console.WriteLine("Naam is gewijzigd naar: " + _naam);
       }
       else
       {
           Console.WriteLine("Naam is te kort.");
           Program.Main();
       }
    }

    private Boolean IsValidName(string naam)
    {
        if(naam.Length <= 3)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}