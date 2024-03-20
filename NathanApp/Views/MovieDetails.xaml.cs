namespace NathanApp.Views
{
    public partial class MovieDetails : ContentPage
    {
        public MovieDetails(MovieItem item)
        {
            InitializeComponent();

            Title.Text = item.Title;
            Date.Text = "Date de sortie : " + item.ReleaseDate.ToString();
            Poster.Source = item.PosterPath;
            Overview.Text = item.Overview;

        }
    }
}
