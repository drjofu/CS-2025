using System.Xml.Linq;

XDocument xDoc = XDocument.Load("mondial.xml");

var xContinents = xDoc
  .Root!
  .Elements("continent")
  .OrderBy(xContinent => (int)xContinent.Element("area")!);

foreach (var xContinent in xContinents)
{
  Console.WriteLine($"{xContinent.Element("name")!.Value,-20} {xContinent.Element("area")!.Value} km² {xContinent.Attribute("id")!.Value}");
}

Console.WriteLine("*****************************");

List<Continent> continents = xDoc
  .Root!
  .Elements("continent")
  .Select(xContinent => new Continent(
    xContinent.Element("name")!.Value,
    (int)xContinent.Element("area")!,
    xContinent.Attribute("id")!.Value))
  .OrderBy(xContinent => xContinent.Area)
  .ToList();

foreach (var continent in continents)
{
  Console.WriteLine($"{continent.Name,-20} {continent.Area} km² {continent.Id}");
}

Console.WriteLine();

var countriesInEurope =
  xDoc.Root
  .Elements("country")
  .Where(xCountry => xCountry.Element("encompassed")!.Attribute("continent")!.Value == "europe")
  .Select(xCountry => new Country(
    xCountry.Element("name")!.Value,
    (double)xCountry.Attribute("area")!,
    xCountry.Attribute("car_code")!.Value,
    (int)xCountry.Element("population")!,
    (DateTime?)xCountry.Element("indep_date")
    ))
  .ToList();

foreach (var country in countriesInEurope)
{
  Console.WriteLine(country.Name);
}

var countriesOfOpec = xDoc.Root
  .Elements("country")
  .Where(xCountry => xCountry.Attribute("memberships")?.Value.Split(' ').Contains("org-OPEC") ?? false)
  .Select(xCountry => xCountry.Element("name")!.Value);
Console.WriteLine("OPEC:");
foreach (var country in countriesOfOpec)
{
  Console.WriteLine(country);
}

Console.ReadLine();


record Continent(string Name, int Area, string Id);
record Country(string Name, double Area, string CarCode, int population, DateTime? IndependenceDate);