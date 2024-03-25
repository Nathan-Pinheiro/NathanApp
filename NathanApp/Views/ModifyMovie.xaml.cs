using System.Collections.ObjectModel;


namespace NathanApp.Views
{
    public partial class ModifyMovie : ContentPage
    {
        private readonly MovieCollection movieCollection;
        private readonly MovieItem movieItem;
        private String fullPath;

        public ModifyMovie(MovieCollection _movieCollection, MovieItem _movieItem)
        {
            InitializeComponent();
            movieCollection = _movieCollection;

            movieItem = _movieItem;

            Title.Text = movieItem.Title;
            Overview.Text = movieItem.Overview;
            fullPath = movieItem.PosterPath;
            Poster.Text = movieItem.ShortPath;
            Date.Text = movieItem.ReleaseDate;
            Average.Text = movieItem.VoteAverage;
        }
        private async void ChooseImageClicked(object sender, EventArgs e)
        {
            var options = new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Select an image"
            };

            var result = await PickAndShow(options);

            if (result != null)
            {
                Poster.Text = result.FileName;
                fullPath = result.FullPath;
            }
        }

        public async Task<FileResult?> PickAndShow(PickOptions options)
        {
            try
            {
                var result = await FilePicker.Default.PickAsync(options);
                if (result != null)
                {
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        using var stream = await result.OpenReadAsync();
                        var image = ImageSource.FromStream(() => stream);
                    }
                }

                return result;
            }
            catch (Exception ex) { }
            return null;
        }

        public void ModifyButtonClicked(object sender, EventArgs e)
        {
            movieCollection.RemoveItem(movieItem);
            MovieItem newItem = new MovieItem(Title.Text, Overview.Text, Date.Text, fullPath, Poster.Text, Average.Text);
            movieCollection.AddMovieItem(newItem);
            Navigation.PopAsync();
        }

        public void DeleteButtonClicked(object sender, EventArgs e)
        {
            movieCollection.RemoveItem(movieItem);
            Navigation.PopAsync();
        }
    }
}