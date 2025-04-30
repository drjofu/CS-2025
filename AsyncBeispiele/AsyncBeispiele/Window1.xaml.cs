using System.Windows;

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

    private CancellationTokenSource cts;
    private CancellationToken cancellationToken;

    private async void BTN_START_Click(object sender, RoutedEventArgs e)
    {
      cts = new CancellationTokenSource();
      try
      {
        cancellationToken = cts.Token;

        BTN_START.IsEnabled = false;
        BTN_STOPP.IsEnabled = true;

        //Task
        //  .Run(Inkrementieren)
        //  .ContinueWith(t => BTN_START.IsEnabled = true, TaskScheduler.FromCurrentSynchronizationContext());

        Task task= Task.Run(Inkrementieren, cancellationToken);
        try
        {
          await task.ConfigureAwait(true);

          int x = await Berechnen(cancellationToken);
          LBL.Content = x;
          await Task.Delay(2000, cancellationToken);
        }
        catch (Exception ex)
        {

        }

        LBL.Content=task.Status;

        BTN_START.IsEnabled = true;
        BTN_STOPP.IsEnabled = false;
      }
      finally
      {
        cts.Dispose();
      }
    }

    async Task<int> Berechnen(CancellationToken cancellationToken)
    {
      await Task.Delay(1000, cancellationToken);
      return 42;
    }

    private void Inkrementieren()
    {
      //throw new ApplicationException("hoppla...");

      for (int i = 0; i < 5; i++)
      {
        if (cancellationToken.IsCancellationRequested)
        {
          // aufräumen...
          cancellationToken.ThrowIfCancellationRequested();
        }

        Thread.Sleep(1000);
        // LBL.Content = i;
        //Dispatcher.BeginInvoke(new Action<int>(x => LBL.Content = x), i);
        //Dispatcher.BeginInvoke(() => LBL.Content = i);

        int index = i;
        Dispatcher.BeginInvoke(() => LBL.Content = index);
        //Dispatcher.BeginInvoke(() => Debug.WriteLine(index));
      }
    }

    private void BTN_STOPP_Click(object sender, RoutedEventArgs e)
    {
      cts?.Cancel();
    }
  }
}
