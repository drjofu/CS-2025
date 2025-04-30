namespace ReflectionBeispiel;

[AttributeUsage(AttributeTargets.Class )]
internal class BeispielAttribute : Attribute
{
  public int AnzahlFehler { get; set; }
  public string? Programmierer { get; set; }

  public BeispielAttribute()
  {   
  }

  public BeispielAttribute(int anzahlFehler, string programmierer)
  {
    AnzahlFehler = anzahlFehler;
    Programmierer = programmierer;
  }
}
