
B b = new B();
A a = b;

a.TuWas();
b.TuWas();

IDingsbums d = b;
d.TuWasAnderes();


string text = "Hallo Welt";
Console.WriteLine(text.ToUpper());

Console.WriteLine("😀😀😊😫😁 \u1000");

text = @"eins
         zwei
         drei";

Console.WriteLine(text);
Console.ReadLine();

class A
{
  public A(string text)
  {
    Console.WriteLine("CTOR A");
    //TuWas();
  }
  public virtual void TuWas()
  {
    Console.WriteLine("TuWas A");
  }
}

sealed class B : A, IDingsbums
{
  public B() : base("Hallo Welt")
  {
    Console.WriteLine("CTOR B");
  }

  public override void TuWas()
  {
    Console.WriteLine("TuWas B");
    //base.TuWas();
  }

  public void TuWasAnderes()
  {
    Console.WriteLine("TuWasAnderes B");
  }
}

interface IDingsbums
{
  void TuWasAnderes() { Console.WriteLine("Hallo"); }
}

// MustInherit NotInheritable
//public abstract sealed class C
public static class C
{

}