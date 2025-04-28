using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesUndDelegates
{
  internal class KontoVergleicher : IComparer<Konto>
  {
    public string Kriterium { get; set; }
    public bool Aufsteigend { get; set; }

    public int Compare(Konto? x, Konto? y)
    {
      switch (Kriterium)
      {
        default:
          break;
      }
      return 42;
    }
  }
}
