namespace InterfacesUndDelegates;

class Konto : IComparable<Konto>
{
  public int Kontonummer { get; set; }
  public string? Inhaber { get; set; }
  public double Saldo { get; set; }

  public int CompareTo(Konto? other)
  {
    Konto k1 = this;
    Konto k2 = other!;

    return k1.Inhaber!.CompareTo(k2.Inhaber);
  }

  public override string ToString()
  {
    //return string.Format("Konto {0} von {1}, Saldo: {2}", Kontonummer, Inhaber, Saldo);
    return $"Konto {Kontonummer:000} von {Inhaber,-12}Saldo: {Saldo}";
  }
}
