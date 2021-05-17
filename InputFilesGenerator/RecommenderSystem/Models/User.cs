using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommenderSystem.Models
{
    public class User
    {
        public string userId { get; set; }
        public string age { get; set; }
        public string gender { get; set; }
        public string occupation { get; set; }
    }

    public class UserRating
    {
        public string userId { get; set; }

        public string movieId { get; set; }

        public string userRating { get; set; }
    }
}
