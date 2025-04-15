using System;
using System.Windows.Forms;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
class Form1 : Form
{
    Button MyButton = new Button(); Button MyKasuj = new Button();
    public Form1()
    {
        MyButton.Text = "Nacisnij"; MyButton.Location = new Point(50, 200);
        MyButton.Click += MyButtonClick; Controls.Add(MyButton);
        MyKasuj.Text = "Kasuj"; MyKasuj.Location = new Point(150, 200);
        MyKasuj.Click += MyKasujClick; Controls.Add(MyKasuj);
    }
    public static void Main()
    {
        Form1 MyForm = new Form1(); Application.Run(MyForm);
    }
    protected void MyButtonClick(object who, EventArgs e)
    {
        Console.WriteLine("akcja");
    }
    protected void MyKasujClick(object who, EventArgs e)
    {
        MyButton.Click -= MyButtonClick;
    }
}
