using System.ComponentModel;

namespace ReflectionBeispiel;

internal class Beispielklasse
{
  private string geheim = "ganz geheim";

  private int zahl = 42;

  [Description("Tolle Property")]
  [Category("Wichtige Eigenschaften")]
  public int Zahl
  {
    get { return zahl; }
    set { zahl = value; }
  }

  public string öffentlich = "nicht geheim";

  [Description("Ein Text")]
  [Category("Wichtige Eigenschaften")]
  public string Text { get; set; } = "Hallo Welt";

  public void Ausgeben(string info)
  {
    Console.WriteLine($"Ausgeben: {info}");
  }
}
