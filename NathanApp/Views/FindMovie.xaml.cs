using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace NathanApp.Views
{
    public partial class FindMovie : ContentPage, INotifyPropertyChanged
    {
        public ObservableCollection<MovieItem> ResearchedItems { get; private set; }
        private readonly MovieCollection movieCollection;

        public FindMovie(MovieCollection _movieCollection)
        {
            InitializeComponent();
            movieCollection = _movieCollection;
            movieCollection.LoadData();
            ResearchedItems = movieCollection.GetMovieItems();
            BindingContext = this;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                MovieItem selectedMovie = (MovieItem)e.SelectedItem;
                await Navigation.PushAsync(new ModifyMovie(movieCollection, selectedMovie));
                research.Text = "";
            }
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = e.NewTextValue.ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                ResearchedItems = movieCollection.GetMovieItems();
            }
            else
            {
                ResearchedItems = new ObservableCollection<MovieItem>(movieCollection.GetMovieItems().Where(m => m.Title.ToLower().Contains(searchText)));
            }
            OnPropertyChanged("ResearchedItems");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
