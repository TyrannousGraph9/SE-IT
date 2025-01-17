using System.Collections;

class Program
{
    public static void Main()
    {
        
        Organisme2 organisme2 = new Organisme2();
        organisme2._oorsprong = "Inheems";
        Console.WriteLine("Voer een ander type in dan Dier of Plant.");
        string type = Console.ReadLine();
        organisme2.TypeVanuitString(type);
        
        Console.WriteLine("Voer een naam in.");
        string naam = Console.ReadLine();
        organisme2.WijzigNaam(naam);

        // Organisme organisme = new Organisme();
        
        // organisme.Beschrijving();

        // organisme.LaadOrganismesVanBestand();

        // organisme.ToonOrganismes();


        // Organisme organisme1 = new Organisme();
        // Organisme organisme2 = new Organisme();
        

        // Leefomgeving bos = new Leefomgeving("Bos");
        

        // bos.VoegOrganismeToe(organisme1);
        // bos.VoegOrganismeToe(organisme2);
        
      
        // bos.ToonOrganismen();

        // ConsoleInteractie();

    }

    public static void ConsoleInteractie()
    {
        Organisme organisme = new Organisme();
        Console.WriteLine("Welkom bij de organismen applicatie!");
        Console.WriteLine("Wat wil je doen?");
        Console.WriteLine("1. Organismen toevoegen");
        Console.WriteLine("2. Organismen tonen");
        Console.WriteLine("Filteren op: Dier of Plant");
        Console.WriteLine("Filteren op: Inheems of Exoot");
        Console.WriteLine("5. Afsluiten");

        string input = Console.ReadLine();

        switch(input)
        {
            case "1":
                Console.WriteLine("Organismen toevoegen");
                VoegOrganisme();
                break;
            case "2":
                Console.WriteLine("Organismen tonen");
                organisme.ToonOrganismes();
                break;

            case "Dier":
                Console.WriteLine("Filteren op dieren");
                FilterSpecifiek("Dier");
                break;

            case "Plant":
                Console.WriteLine("Filteren op planten");
                FilterSpecifiek("Plant");
                break;

            case "Inheems":
                Console.WriteLine("Filteren op inheemse organismen");
                FilterSpecifiek("Inheems");
                break;
            
            case "Exoot":
                Console.WriteLine("Filteren op exotische organismen");
                FilterSpecifiek("Exoot");
                break;

            case "5":
                Console.WriteLine("Tot ziens!");
                break;

            default:
                Console.WriteLine("Ongeldige invoer");
                ConsoleInteractie();
                break;
        }
    }

    static void VoegOrganisme()
    {
        Console.WriteLine("Geef de naam van het organisme");
        string naam = Console.ReadLine();
        Console.WriteLine("Geef het type van het organisme");
        string type = Console.ReadLine();
        Console.WriteLine("Geef de oorsprong van het organisme");
        string oorsprong = Console.ReadLine();

        if(naam is null || type is null || oorsprong is null)
        {
            Console.WriteLine("Ongeldige invoer");
            VoegOrganisme();
        }

        Organisme organisme = new Organisme();
        organisme.MaakOrganisme(naam, type, oorsprong);
    }

    static void FilterSpecifiek(string filter)
    {
        Organisme organisme = new Organisme();
        switch(filter)
        {
            case "Plant":
            Console.WriteLine("Welke plant wil je zoeken?");
                string plantInput = Console.ReadLine();
                
                if(plantInput is null)
                {
                    Console.WriteLine("Ongeldige invoer");
                    FilterSpecifiek(filter);
                }

                organisme.ZoekOrganismeOpType("Plant",plantInput);
                break;

            case "Dier":
                Console.WriteLine("Welk dier wil je zoeken?");
                string dierInput = Console.ReadLine();
                
                if(dierInput is null)
                {
                    Console.WriteLine("Ongeldige invoer");
                    FilterSpecifiek(filter);
                }

                organisme.ZoekOrganismeOpType("Dier", dierInput);
                break;

            case "Inheems":
            Console.WriteLine("Welk Inheems je zoeken?");
                string inheemsInput = Console.ReadLine();
                
                if(inheemsInput is null)
                {
                    Console.WriteLine("Ongeldige invoer");
                    FilterSpecifiek(filter);
                }

                organisme.ZoekOrganismeOpOorsprong("Inheems",inheemsInput);
                break;

            case "Exoot":
                Console.WriteLine("Welk Exoot je zoeken?");
                string exootInput = Console.ReadLine();
                
                if(exootInput is null)
                {
                    Console.WriteLine("Ongeldige invoer");
                    FilterSpecifiek(filter);
                }

                organisme.ZoekOrganismeOpOorsprong("exoot",exootInput);
                break;

        }
    }



}