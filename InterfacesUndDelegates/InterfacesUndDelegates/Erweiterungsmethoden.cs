namespace InterfacesUndDelegates;

static class Erweiterungsmethoden
{
  public static void Ausgeben<T>(this IEnumerable<T> liste, string titel = "")
  {
    Console.WriteLine($"********** {titel} **********");
    foreach (T element in liste)
    {
      Console.WriteLine(element);
    }

    Console.WriteLine("*********************************");
  }

  //public static void AAA(this object obj) { }
}
