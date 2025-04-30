namespace WebApiBeispiel
{
  public interface INameCalculator
  {
    int CalculateName(string name);
  }

  public class NameCalculator : INameCalculator
  {
    public int CalculateName(string name)
    {
      return name.Length;
    }
  }
}
