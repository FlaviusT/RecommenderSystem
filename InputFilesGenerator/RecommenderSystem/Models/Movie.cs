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
    public class Movie
    {
        public string tconst { get; set; }

        public string titleType { get; set; }

        public string primaryTitle { get; set; }

        public string originalTitle { get; set; }

        public string isAdult { get; set; }

        public string startYear { get; set; }

        public string endYear { get; set; }

        public string runtimeMinutes { get; set; }

        public string genres { get; set; }
    }
    public class MovieShort
    {
        public string tconst { get; set; }

        public string originalTitle { get; set; }

        public string genres { get; set; }
    }

    public class MovieResult
    {
        public string titleId { get; set; }

        public string titleName { get; set; }

        public string director { get; set; }

        public string cast { get; set; }

        public string imdbscore { get; set; }

        public string votes { get; set; }

        public string genres { get; set; }
    }
}
