using System.Collections.ObjectModel;


namespace NathanApp.Views
{
    public partial class AddMovie : ContentPage
    {
        private readonly MovieCollection movieCollection;

        public AddMovie(MovieCollection _movieCollection)
        {
            InitializeComponent();
            movieCollection = _movieCollection;
        }

        public void AddButtonClicked(object sender, EventArgs e)
        {
            MovieItem newItem = new MovieItem(Title.Text, Overview.Text, Date.Text, Poster.Text, Average.Text);
            movieCollection.AddMovieItem(newItem);
        }
    }
}