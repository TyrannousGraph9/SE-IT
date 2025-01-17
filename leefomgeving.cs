using System;
using System.Collections.Generic;

public class Leefomgeving
{
    public string Naam;
    public List<Organisme> Organismen = new List<Organisme>();

    public Leefomgeving(string naam)
    {
        Naam = naam;
        Organismen = new List<Organisme>();
    }

    public void VoegOrganismeToe(Organisme organisme)
    {
        Organismen.Add(organisme);
    }

    public void ToonOrganismen()
    {
        Console.WriteLine($"Organismen in {Naam}:");
        foreach (var organisme in Organismen)
        {
            Console.WriteLine(organisme.Beschrijving());
        }
    }
}