
using ConsoleApp2;

Console.WriteLine("Hello world!");
Console.WriteLine(Tuwas());

string Tuwas()
{
  return "Tuwas";
}
Console.WriteLine("toll");

Konto k1= new Konto(1);
Konto2 k2 = new Konto2(1);

k1.Kontonummer = 17;
//k2.Kontonummer = 17;
Console.WriteLine(k2.Inhaber?.ToString());
k2.Inhaber = "Dagobert";

Console.WriteLine("Hallo".GetHashCode());

Console.ReadLine();
