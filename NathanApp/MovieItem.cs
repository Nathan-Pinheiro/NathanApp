using Microsoft.Extensions.Logging;

namespace NathanApp
{
    public class MovieItem
    {
        public MovieItem( string title, string overview, string release_date, string poster_path, string vote_average )
        {
            this.Title = title;
            this.Overview = overview;
            this.ReleaseDate = release_date;
            this.PosterPath = poster_path;
            this.VoteAverage = vote_average;
        }

        public string Title { get; set; }
        public string Overview { get; set; }
        public string ReleaseDate { get; set; }
        public string PosterPath { get; set; }
        public string VoteAverage { get; set; }
    }
}
