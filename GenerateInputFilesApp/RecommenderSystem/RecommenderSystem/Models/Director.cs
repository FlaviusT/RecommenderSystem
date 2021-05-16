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
    public class Director
    {
        public string tconst { get; set; }

        public string directors { get; set; }

        public string writers { get; set; }
    }

    public class DirectorShort
    {
        public string tconst { get; set; }

        public string directors { get; set; }
    }
}
