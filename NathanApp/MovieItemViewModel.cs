using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace NathanApp
{
    public class MovieItemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string aPropertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public MovieItemViewModel(string title, string overview, string release_date, string poster_path, string vote_average) 
        {
            this.title = title;
            this.overview = overview;
            this.release_date = release_date;
            this.poster_path = poster_path;
            this.vote_average = vote_average;
        }

        public string title { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
        public string poster_path { get; set; }
        public string vote_average { get; set; }
    }
}
