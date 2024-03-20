using System.Collections.ObjectModel;
using System.Text.Json;

namespace NathanApp.Views
{
    public partial class Movies : ContentPage
    {
        public ObservableCollection<MovieItem> MovieItems { get; private set; }
        private readonly MovieCollection movieCollection;

        public Movies(MovieCollection _movieCollection)
        {   
            InitializeComponent();
            movieCollection = _movieCollection;
            movieCollection.LoadData();
            MovieItems = movieCollection.GetMovieItems();

            BindingContext = this;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                MovieItem selectedMovie = (MovieItem) e.SelectedItem;
                await Navigation.PushAsync(new MovieDetails(selectedMovie));
            }
        }
    }
}
