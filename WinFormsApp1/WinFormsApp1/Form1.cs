namespace WinFormsApp1;

public partial class Form1 : Form
{
  public Form1()
  {
    InitializeComponent();
  }

  private void Form1_Paint(object sender, PaintEventArgs e)
  {
    using (Pen stift = new Pen(Color.Red, 5))
    {
      e.Graphics.DrawEllipse(stift, 50, 50, 100, 100);
    }

    using Pen stift2 = new Pen(Color.Yellow, 5);
    e.Graphics.DrawEllipse(stift2, 150, 150, 100, 100);

    // stift.Dispose();
  }
}
