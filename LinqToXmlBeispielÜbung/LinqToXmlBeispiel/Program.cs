using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqToXmlBeispiel
{
  class Program
  {
    static void Main(string[] args)
    {
      XDocument xDoc = XDocument.Load("mondial.xml");
      var xContinents = xDoc.Root.Elements("continent")
        .OrderBy(xCont => (int)xCont.Element("area"));

      foreach (var xContinent in xContinents)
      {
        Console.WriteLine(xContinent.Attribute("id").Value.PadRight(10)
          + " " +
          xContinent.Element("name").Value.PadRight(18)
          + " " +
          xContinent.Element("area").Value);
      }

      var continents = xContinents.Select(xCont => new Continent
      {
        Id = xCont.Attribute("id").Value,
        Name = xCont.Element("name").Value,
        Area = (int)xCont.Element("area")
      }).ToList();

      foreach (var continent in continents)
      {
        Console.WriteLine(continent.Name + " " + continent.Area);
      }

      Console.WriteLine("**********************************");

      var countries = xDoc.Root.Elements("country")
        .Where(xCountry => xCountry.Element("encompassed")
          .Attribute("continent").Value == "asia")
        .Select(xCountry => new Country
        {
          Name = xCountry.Element("name").Value,
          CarCode = xCountry.Attribute("car_code").Value,
          Population = (int)xCountry.Element("population"),
          IndependenceDate = (DateTime?)xCountry.Element("indep_date"),
          Government = xCountry.Element("government")?.Value
        });

      foreach (var country in countries)
      {
        Console.WriteLine(country.Name);
        Console.WriteLine("  CarCode: " + country.CarCode);
        Console.WriteLine("  Pops:    " + country.Population);
        Console.WriteLine("  Indep.:  " + country.IndependenceDate?.ToShortDateString());
        Console.WriteLine("  Governm.:" + country.Government
          );
      }

      Console.WriteLine();

      // Berge
      Console.WriteLine("Höchster Berg Deutschlands:");

      var xMountains = xDoc.Root.Elements("mountain")
        .Where(xMountain => xMountain.Attribute("country").Value.Split(' ').Contains("D"))
        .OrderByDescending(xMountain=>(int)xMountain.Element("height"));
      var höchsterBerg = xMountains.FirstOrDefault();
      Console.WriteLine(höchsterBerg.Element("name").Value + ": " +
                        höchsterBerg.Element("height").Value + "m");

      // Millionenstädte
      var xCities = xDoc.Root.Descendants("city")
        .Where(xCity => (int?)xCity.Element("population") > 1000000)
        .OrderByDescending(xCity => (int?)xCity.Element("population"));

      foreach (var xCity in xCities)
      {
        Console.WriteLine(xCity.Element("name").Value + ": " + (int)xCity.Element("population"));
      }

      Console.WriteLine();
      Console.WriteLine("*********************************");
      Console.WriteLine("Countries mit Protestant > 10%");
      Console.WriteLine();


      var xProtestants = xDoc.Root.Descendants("religions")
        .Where(xReligion => xReligion.Value == "Protestant" && (double?)xReligion.Attribute("percentage") > 10);
      foreach (var xProtestant in xProtestants)
      {
        Console.WriteLine(xProtestant.Parent.Element("name").Value + ": " + 
          xProtestant.Attribute("percentage").Value + "%");
      }

      Console.WriteLine(xProtestants.Count());

      Console.WriteLine();
      Console.WriteLine("*********************************");
      Console.WriteLine("OPEC-Mitglieder");
      Console.WriteLine();

      var xUN = xDoc.Root.Elements("country")
        .Where(xCountry => xCountry.Attribute("memberships")?
              .Value.Split(' ').Contains("org-OPEC") ?? false);
      foreach (var xCountry in xUN)
      {
        Console.WriteLine(xCountry.Element("name").Value);
      }

      Console.WriteLine();
      Console.WriteLine("*********************************");
      Console.WriteLine("Mehr als 8 Nachbarländer");
      Console.WriteLine();

      foreach (var xCountry in xDoc.Root.Elements("country").Where(xCountry=>xCountry.Elements("border").Count()>8))
      {
        Console.WriteLine(xCountry.Element("name").Value + ": " +
          xCountry.Elements("border").Count() + " Nachbarländer");
      }

      Console.ReadLine();
    }
  }
}
