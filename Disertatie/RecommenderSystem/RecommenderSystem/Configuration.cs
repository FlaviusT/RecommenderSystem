namespace RecommenderSystem
{
    [System.Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public class Configuration
    {
        public string TitleFilePath { get; set; }

        public string DirectorsFilePath { get; set; }

        public string RatingsFilePath { get; set; }

        public string NamesFilePath { get; set; }

        public string CastFilePath { get; set; }

        public string OutputFolderPath { get; set; }

        public string NumberOfUsers { get; set; }

        public string MovieYearsRangeStart { get; set; }

        public string MovieYearsRangeEnd { get; set; }
    }
}
