using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace ToWatch.ViewModels
{
    public class MovieViewModel
    {      
        public string Id { get; set; }
        public bool Adult { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IEnumerable<int> Genres { get; set; }
        public string OriginalTitle { get; set; }
        public string OriginalLanguage { get; set; }
        public string Title { get; set; }
        public double Popularity { get; set; }
        public int VoteCount { get; set; }
        public double VoteAverage { get; set; }
        public string PosterPath
        {
            get { return "https://image.tmdb.org/t/p/w500" + _posterPath; }
            set { _posterPath = value; }
        }

        private string _posterPath;
    }
}
