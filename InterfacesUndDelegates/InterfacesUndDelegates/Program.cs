using InterfacesUndDelegates;

List<Konto> konten = new List<Konto>()
{
  new Konto()
  {
    Kontonummer = 1,
    Inhaber = "Dagobert",
    Saldo = 9999999999
  },
  new Konto()
  {
    Kontonummer = 2,
    Inhaber = "Donald",
    Saldo = -100
  },
  new Konto()
  {
    Kontonummer = 3,
    Inhaber = "Mickey",
    Saldo = 100
  },
  new Konto()
  {
    Kontonummer = 4,
    Inhaber = "Tick",
    Saldo = 100.5
  },

  new Konto()
  {
    Kontonummer = 46,
    Inhaber = "Trick",
    Saldo = 100.3
  },

  new Konto()
  {
    Kontonummer = 14,
    Inhaber = "Track",
    Saldo = 100.7
  }
};


//foreach (Konto konto in konten)
//{
//  Console.WriteLine(konto);
//} 

Erweiterungsmethoden.Ausgeben(konten);

konten.Ausgeben("via Extension Method");
new int[] { 1, 2, 3 }.Ausgeben();
"Hallo".Ausgeben("String");

konten.Sort();

konten.Ausgeben("Sortiert");

Console.ReadLine();