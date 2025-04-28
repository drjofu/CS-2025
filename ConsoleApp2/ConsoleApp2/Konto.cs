namespace ConsoleApp2;

internal class Konto
{
  public int Kontonummer { get; set; }

  public Konto(int kontonummer)
  {
    Kontonummer = kontonummer;
  }
}

public record Konto2(int Kontonummer)
{
  public string? Inhaber { get; set; }
}
