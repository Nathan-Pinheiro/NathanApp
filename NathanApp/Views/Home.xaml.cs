using System.Collections.ObjectModel;

namespace NathanApp.Views
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LastAnimalGif());
        }
    }
}