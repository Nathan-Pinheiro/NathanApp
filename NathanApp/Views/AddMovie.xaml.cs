using Java.Util.Streams;
using NathanApp.Services;
using System.Collections.ObjectModel;


namespace NathanApp.Views
{
    public partial class AddMovie : ContentPage
    {
        private readonly MovieCollection movieCollection;
        private String fullPath;

        public AddMovie(MovieCollection _movieCollection)
        {
            InitializeComponent();
            movieCollection = _movieCollection;
        }

        public void AddButtonClicked(object sender, EventArgs e)
        {
            MovieItem newItem = new MovieItem(Title.Text, Overview.Text, Date.Text, fullPath, Poster.Text, Average.Text);
            movieCollection.AddMovieItem(newItem);
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

        public async Task<FileResult> PickAndShow(PickOptions options)
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

    }
}