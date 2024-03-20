using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;

namespace NathanApp
{
    public class MovieCollection : INotifyPropertyChanged
    {
        private ObservableCollection<MovieItem> MovieItems;

        public event PropertyChangedEventHandler? PropertyChanged;

        public MovieCollection()
        {
            MovieItems = new ObservableCollection<MovieItem>();
            OnPropertyChanged(nameof(MovieItems));
        }
        public ObservableCollection<MovieItem> GetMovieItems()
        {
            return MovieItems;
        }

        public void AddMovieItem(MovieItem item)
        {
            MovieItems.Add(item);
        }

        public async void LoadData()
        {
            try
            {
                Uri uri = new("http://filmotheque.e-mingo.net/api/catalog/movie/?sort=vote");
                HttpClient client = new();
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    List<MovieItem> items = DeserializeJson(content);

                    MovieItems.Clear();
                    foreach (var item in items)
                    {
                        MovieItems.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        private List<MovieItem> DeserializeJson(string json)
        {
            var vineItems = new List<MovieItem>();

            try
            {
                using (JsonDocument doc = JsonDocument.Parse(json))
                {
                    JsonElement root = doc.RootElement;

                    if (root.ValueKind == JsonValueKind.Array)
                    {
                        foreach (JsonElement element in root.EnumerateArray())
                        {
                            string title = element.GetProperty("title").GetString();
                            string overview = element.GetProperty("overview").GetString();
                            string release_date = element.GetProperty("release_date").GetString();
                            string poster_path = element.GetProperty("poster_path").GetString();
                            string vote_average = element.GetProperty("vote_average").GetDecimal().ToString();

                            vineItems.Add(new MovieItem(title, overview, release_date, poster_path, vote_average));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
            }

            return vineItems;
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
