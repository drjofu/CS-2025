
using ReflectionBeispiel;
using System.ComponentModel;
using System.Dynamic;
using System.Reflection;

object obj = new ReflectionBeispiel.Beispielklasse();

Analysieren(obj);

Console.WriteLine();
Console.WriteLine("Enums");

Zubehör zubehör = Zubehör.Tastatur | Zubehör.Maus;

Console.WriteLine(zubehör);

Console.WriteLine();
Console.WriteLine("dynamic");

dynamic dyn = obj;
Console.WriteLine(dyn.Zahl);
dyn.Ausgeben("dynamisch...");

dynamic x = new ExpandoObject();
x.Name = "Joachim";
x.Alter = 42;
Console.WriteLine(x.Name);

var typ = typeof(Beispielklasse);
var allTypes = Assembly.GetExecutingAssembly().GetTypes();

Console.ReadLine();


void Analysieren(object obj)
{
  var typ = obj.GetType();

  Console.WriteLine($"Typ: {typ.Name}");
  Console.WriteLine(typ.FullName);
  Console.WriteLine();

  Console.WriteLine("Properties");
  foreach (var pi in typ.GetProperties())
  {
    Console.WriteLine($"{pi.Name}: {pi.GetValue(obj)} [{pi.PropertyType.Name}]");
    var descAttr = pi.GetCustomAttribute<DescriptionAttribute>();
    if (descAttr != null)
    {
      Console.WriteLine($"  Beschreibung: {descAttr.Description}");
    }
  }

  Console.WriteLine();
  Console.WriteLine("Fields");
  typ.GetField("geheim", BindingFlags.NonPublic | BindingFlags.Instance)?.SetValue(obj, "doch nicht so geheim");

  foreach (var fi in typ.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
  {
    Console.WriteLine($"{fi.Name}: {fi.GetValue(obj)} [{fi.FieldType.Name}]");
  }

  Console.WriteLine();
  Console.WriteLine("Methods");
  typ.GetMethod("Ausgeben")?.Invoke(obj, ["Hallo Reflection!"]);


  Console.WriteLine();
  Console.WriteLine("Attributes");

  var BeispielAttr = typ.GetCustomAttribute<ReflectionBeispiel.BeispielAttribute>();
  if (BeispielAttr != null)
  {
    Console.WriteLine($"Anzahl Fehler: {BeispielAttr.AnzahlFehler}, Progr.: {BeispielAttr.Programmierer}");
  }
}