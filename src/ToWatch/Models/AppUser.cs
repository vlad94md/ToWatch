using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToWatch.Models
{
    public class AppUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<SavedMovie> WatchList { get; set; }
    }
}
