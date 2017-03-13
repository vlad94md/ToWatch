using System.Collections.Generic;

namespace ToWatch.ViewModels
{
    public class MovieSetApiResponse
    {
        public int Page { get; set; }
        public IEnumerable<MovieViewModel> Results { get; set; }
        public int TotalPages { get; set; }
    }
}