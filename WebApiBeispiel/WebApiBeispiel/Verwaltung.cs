namespace WebApiBeispiel;

public interface IVerwaltung
{
  IEnumerable<Person> GetPersonen();
  Person? GetPerson(string name);
  int GetLength(string name);
}

public class Verwaltung : IVerwaltung
{
  private readonly ILogger<Verwaltung> logger;
  private readonly INameCalculator nameCalculator;

  public Verwaltung(ILogger<Verwaltung> logger, INameCalculator nameCalculator)
  {
    this.logger = logger;
    this.nameCalculator = nameCalculator;
  }

  // Vorsicht! Singlton ist nicht immer die beste Wahl!
  private List<Person> Personen { get; set; } = new List<Person>() {
      new Person(){ Name = "Hans", Alter = 42, WohnortInDeutschland = "Berlin" },
      new Person(){ Name = "Petra", Alter = 35, WohnortInDeutschland = "Hamburg" },
      new Person(){ Name = "Anna", Alter = 28, WohnortInDeutschland = "München" },
      new Person(){ Name = "Maria", Alter = 30, WohnortInDeutschland = "Stuttgart" },
      new Person(){ Name = "Thomas", Alter = 50, WohnortInDeutschland = "Frankfurt" }
    };

  public int GetLength(string name)
  {
    return nameCalculator.CalculateName(name);
  }

  public Person? GetPerson(string name)
  {
    logger.LogInformation("Abfrage für {name}", name);

    return Personen.FirstOrDefault(p => p.Name == name);
  }

  public IEnumerable<Person> GetPersonen()
  {
    logger.LogError("Abfrage aller Personen");
    return Personen;
  }
}



