using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommenderSystem.Models
{
    public class Rating
    {
        public string tconst { get; set; }

        public string averageRating { get; set; }

        public string numVotes { get; set; }
    }
}
