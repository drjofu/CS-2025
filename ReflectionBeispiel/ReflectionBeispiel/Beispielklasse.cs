using System.ComponentModel;

namespace ReflectionBeispiel;

//[Beispiel(4, "Joachim")]
[Beispiel(AnzahlFehler = 4, Programmierer = "Joachim")]
internal class Beispielklasse
{
  private string geheim = "ganz geheim";

  private int zahl = 42;

  [Description("Tolle Property")]
  public int Zahl
  {
    get { return zahl; }
    set { zahl = value; }
  }

  public string öffentlich = "nicht geheim";

  [Description("Ein Text")]
  public string Text { get; set; } = "Hallo Welt";

  public void Ausgeben(string info)
  {
    Console.WriteLine($"Ausgeben: {info}");
  }
}
