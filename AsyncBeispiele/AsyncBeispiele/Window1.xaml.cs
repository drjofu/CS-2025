using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AsyncBeispiele
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class Window1 : Window
  {
    public Window1()
    {
      InitializeComponent();
    }

    private void BTN_START_Click(object sender, RoutedEventArgs e)
    {
      BTN_START.IsEnabled = false;
      Task
        .Run(Inkrementieren)
        .ContinueWith(t => BTN_START.IsEnabled = true, TaskScheduler.FromCurrentSynchronizationContext());
      //BTN_START.IsEnabled = true;

    }

    private void Inkrementieren()
    {
      for (int i = 0; i < 5; i++)
      {
        Thread.Sleep(1000);
        // LBL.Content = i;
        //Dispatcher.BeginInvoke(new Action<int>(x => LBL.Content = x), i);
        //Dispatcher.BeginInvoke(() => LBL.Content = i);

        int index = i;
        Dispatcher.BeginInvoke(() => LBL.Content = index);
        //Dispatcher.BeginInvoke(() => Debug.WriteLine(index));
      }
    }
  }
}
