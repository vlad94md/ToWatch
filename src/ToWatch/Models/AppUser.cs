using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToWatch.Models
{
    public class AppUser : IdentityUser
    {
        public ICollection<SavedMovie> WatchList { get; set; }
    }
}
