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

//KontoVergleicher kv = new KontoVergleicher() { Kriterium = "..." };
//konten.Sort(kv);
konten.Sort();
konten.Ausgeben("Sortiert");

Comparison<Konto> vergleichsmethode = new Comparison<Konto>(VergleicheNachSaldo);
konten.Sort(vergleichsmethode);
konten.Ausgeben("Sortiert nach Saldo");

konten.Sort(VergleicheNachSaldo);
konten.Ausgeben("Sortiert nach Saldo");

// Anonyme Methode C# 2.0
int richtung = -1;
konten.Sort(delegate (Konto k1, Konto k2)
{
  return richtung * k1.Inhaber!.CompareTo(k2.Inhaber);  // richtung als Closure
});

konten.Ausgeben("Sortiert nach Inhaber");

// Lambda-Ausdruck C# 3.0
konten.Sort((k1, k2) =>
{
  return richtung * k1.Inhaber!.CompareTo(k2.Inhaber);
});

konten.Ausgeben("Sortiert nach Inhaber");

konten.Sort((k1, k2) => richtung * k1.Inhaber!.CompareTo(k2.Inhaber));
konten.Ausgeben("Sortiert nach Inhaber");

Konto? kontoDagobert = konten.Find(k => k.Inhaber == "Dagobert");
Console.WriteLine($"Gefunden: {kontoDagobert}");

konten.FindAll(k => k.Inhaber!.StartsWith("T")).Ausgeben("Alle mit T");

Console.WriteLine();

var ergebnis = konten
      .Where(k => k.Inhaber!.StartsWith("T"))
      .OrderByDescending(k => k.Kontonummer)
      .Select(k => new {k.Inhaber, k.Kontonummer});


      ergebnis.Ausgeben("Alle mit T");

//IEnumerable<Konto> kontoEnumerable = konten;
//IEnumerator<Konto> kontoEnumerator = kontoEnumerable.GetEnumerator();
//while (kontoEnumerator.MoveNext())
//{
//  Konto konto = kontoEnumerator.Current;
//  Console.WriteLine(konto.Inhaber);
//}

Console.ReadLine();

int VergleicheNachSaldo(Konto k1, Konto k2)
{
  return k1.Saldo.CompareTo(k2.Saldo);
}