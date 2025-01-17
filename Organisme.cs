using System.Diagnostics;
using System.IO;
public class Organisme
{
    string naam;

    string type;

    string oorsprong;

   List<Organisme> organismes = new List<Organisme>();


    public virtual string Beschrijving()
    {
        return "De egel is een inheems dier..";
    }



    public void LaadOrganismesVanBestand()
    {
        
    if (File.Exists("organismes.txt"))
    {
        File.ReadAllLines("organismes.txt");
        if(File.ReadAllLines("organismes.txt").Length == 0)
        {
            Console.WriteLine("Bestand is leeg");
            File.Delete("organismes.txt");
            LaadOrganismesVanBestand();
            return;
        }
        organismes.Clear();
        foreach (var line in File.ReadAllLines("organismes.txt"))
        {
            var parts = line.Split(", ");
            if (parts.Length == 3)
            {
                organismes.Add(new Organisme { naam = parts[0], type = parts[1], oorsprong = parts[2] });
            }
        }
    }
    else
    {
        FileStream fs = new FileStream("organismes.txt", FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);

        organismes.Add(new Plant { naam = "Eik", type = "Plant", oorsprong = "Inheems" });
        organismes.Add(new Dier { naam = "Egel", type = "Dier", oorsprong = "Inheems" });
        organismes.Add(new Plant { naam = "Beuk", type = "Plant", oorsprong = "Inheems" });
        organismes.Add(new Plant { naam = "Berk", type = "Plant", oorsprong = "Inheems" });
        organismes.Add(new Dier { naam = "Vos", type = "Dier", oorsprong = "Inheems" });
        organismes.Add(new Dier { naam = "Hert", type = "Dier", oorsprong = "Inheems" });
        organismes.Add(new Plant { naam = "Bamboe", type = "Plant", oorsprong = "Exoot" });
        organismes.Add(new Dier { naam = "Wasbeer", type = "Dier", oorsprong = "Exoot" });

        foreach (var organisme in organismes)
        {
            sw.WriteLine($"{organisme.naam}, {organisme.type}, {organisme.oorsprong}");
        }
        sw.Close();
        fs.Close();

        organismes.Clear();
        LaadOrganismesVanBestand();
        
    }
}


    public void ToonOrganismes()
    {
        StreamReader sr = new StreamReader("organismes.txt");
        for (int i = 0; i < File.ReadAllLines("organismes.txt").Length; i++)
        {
            Console.WriteLine(sr.ReadLine());
        }
    }

    public void MaakOrganisme(string naam, string type, string oorsprong)
    {
        Organisme organisme = new Organisme();
        organisme.organismes.Add(new Organisme { naam = naam, type = type, oorsprong = oorsprong });
        StreamWriter sr = new StreamWriter("organismes.txt", true);
        sr.WriteLine($"{naam}, {type}, {oorsprong}");
        sr.Close();
    }

    public void ZoekOrganismeOpType(string type, string naam)
    {   
        LaadOrganismesVanBestand(); // Laad data in de lijst
        var results = organismes.Where(o => o.type == type && o.naam == naam).ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("Geen resultaten gevonden");
        }
        else
        {
            results.ForEach(o => Console.WriteLine($"{o.naam}, {o.type}, {o.oorsprong}"));
        }
    }   


    public void ZoekOrganismeOpOorsprong(string oorsprong, string naam)
    {
        LaadOrganismesVanBestand(); // Laad data in de lijst
        var results = organismes.Where(o => o.oorsprong == oorsprong && o.naam == naam).ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("Geen resultaten gevonden");
        }
        else
        {
            results.ForEach(o => Console.WriteLine($"{o.naam}, {o.type}, {o.oorsprong}"));
        }
    }

    class Plant : Organisme
    {
        public override string Beschrijving()
        {
            return "De eik is een inheemse boom van 2 meter..";
        }

    }

    class Dier : Organisme
    {
        public override string Beschrijving()
        {
            return "De egel is een inheems dier dat nog rondloopt..";
        }
    }
}