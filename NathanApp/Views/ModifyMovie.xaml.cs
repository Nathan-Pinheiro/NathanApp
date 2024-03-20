using System.Collections.ObjectModel;

namespace NathanApp.Views
{
    public partial class ModifyMovie : ContentPage
    {
        public ObservableCollection<MovieItem> ResearchedItems { get; private set; }
        private readonly MovieCollection movieCollection;

        public ModifyMovie(MovieCollection _movieCollection)
        {
            InitializeComponent();
            movieCollection = _movieCollection;
            movieCollection.LoadData();
            ResearchedItems = movieCollection.GetMovieItems();

            BindingContext = this;
        }
    }
}
