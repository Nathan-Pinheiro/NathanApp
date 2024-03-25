namespace NathanApp.Views
{
    public partial class LastAnimalGif : ContentPage
    {
        public LastAnimalGif()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(150);
            gif.IsAnimationPlaying = true;
        }
    }
}
