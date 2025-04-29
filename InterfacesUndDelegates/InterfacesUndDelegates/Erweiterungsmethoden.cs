namespace InterfacesUndDelegates;

static class Erweiterungsmethoden
{
  public static IEnumerable<T> Ausgeben<T>(this IEnumerable<T> liste, string titel = "")
  {
    Console.WriteLine($"********** {titel} **********");
    foreach (T element in liste)
    {
      Console.WriteLine(element);
    }

    Console.WriteLine("*********************************");
    return liste;
  }

  //public static void AAA(this object obj) { }
}
