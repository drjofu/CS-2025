using System.Xml.Linq;

XDocument xDoc = XDocument.Load("mondial.xml");

var xContinents = xDoc
  .Root!
  .Elements("continent");

foreach (var xContinent in xContinents)
{
  Console.WriteLine(xContinent.Element("name")!.Value);
}


Console.ReadLine();