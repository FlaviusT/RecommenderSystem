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
    public class Name
    {
        public string nconst { get; set; }
        public string primaryName { get; set; }
        public string birthYear { get; set; }
        public string deathYear { get; set; }
        public string primaryProfession { get; set; }
        public string knownForTitles { get; set; }
    }

    public class NameShort
    {
        public string nconst { get; set; }

        public string primaryName { get; set; }
    }
}
