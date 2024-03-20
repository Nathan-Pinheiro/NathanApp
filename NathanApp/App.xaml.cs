using Microsoft.Maui.Controls.Internals;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace NathanApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            System.Diagnostics.Debug.WriteLine("App started !");
        }
    }
}
