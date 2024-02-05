using System;
using System.Windows;

namespace FerryPort
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var gui = new FerryPort();

            var window = new Window
            {
                Title = "Ferry Port",
                Content = gui,
                Width = 750,
                Height = 500
            };

            window.ShowDialog();

        }
    }
}
