using CsvHelper;
using CsvHelper.Configuration;
using RecommenderSystem.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using UnidecodeSharpFork;

namespace RecommenderSystem
{
    public class Parsers
    {
        public static Dictionary<string, T> DeserializeFile<T>(string filename, string delimiter, Constants.ClassTypes paramType)
        {
            TextReader textReader = File.OpenText(filename);

            CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture);
            config.HasHeaderRecord = true;
            config.MissingFieldFound = null;
            config.BadDataFound = null;
            config.Delimiter = delimiter;

            var csv = new CsvReader(textReader, config);

            List<T> dataList = csv.GetRecords<T>().ToList();

            Dictionary<string, T> values = new Dictionary<string, T>();

            switch (paramType)
            {
                case Constants.ClassTypes.Movies:
                    {
                        foreach (T movie in dataList)
                        {
                            values.Add((movie as Movie).tconst, movie);
                        }
                        break;
                    }

                case Constants.ClassTypes.MoviesShort:
                    {
                        foreach (T movieShort in dataList)
                        {
                            values.Add((movieShort as MovieShort).tconst, movieShort);
                        }
                        break;
                    }
                case Constants.ClassTypes.MoviesResult:
                    {
                        foreach (T movieResult in dataList)
                        {
                            values.Add((movieResult as MovieResult).titleId, movieResult);
                        }
                        break;
                    }
                case Constants.ClassTypes.Ratings:
                    {
                        foreach (T rating in dataList)
                        {
                            values.Add((rating as Rating).tconst, rating);
                        }
                        break;
                    }
                case Constants.ClassTypes.Directors:
                    {
                        foreach (T director in dataList)
                        {
                            values.Add((director as Director).tconst, director);
                        }
                        break;
                    }
                case Constants.ClassTypes.DirectorsShort:
                    {
                        foreach (T directorShort in dataList)
                        {
                            values.Add((directorShort as DirectorShort).tconst, directorShort);
                        }
                        break;
                    }
                case Constants.ClassTypes.CastShort:
                    {
                        foreach (T castShort in dataList)
                        {
                            values.Add((castShort as CastShort).tconst, castShort);
                        }
                        break;
                    }
                case Constants.ClassTypes.Names:
                    {
                        foreach (T name in dataList)
                        {
                            values.Add((name as Name).nconst, name);
                        }
                        break;
                    }
                case Constants.ClassTypes.NamesShort:
                    {
                        foreach (T nameShort in dataList)
                        {
                            values.Add((nameShort as NameShort).nconst, nameShort);
                        }
                        break;
                    }
                case Constants.ClassTypes.Users:
                    {
                        foreach (T user in dataList)
                        {
                            values.Add((user as User).userId, user);
                        }
                        break;
                    }

            }

            return values;
        }

        public static Dictionary<string, List<UserRating>> DeserializeFileSample(string filename, string delimiter, Constants.ClassTypes paramType)
        {
            TextReader textReader = File.OpenText(filename);

            CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture);
            config.HasHeaderRecord = true;
            config.MissingFieldFound = null;
            config.BadDataFound = null;
            config.Delimiter = delimiter;

            var csv = new CsvReader(textReader, config);

            List<UserRating> dataList = csv.GetRecords<UserRating>().ToList();

            Dictionary<string, List<UserRating>> values = new Dictionary<string, List<UserRating>>();

            foreach (UserRating user in dataList)
            {
                if (!values.ContainsKey((user as UserRating).userId))
                {
                    values.Add((user as UserRating).userId, (new List<UserRating>() { user as UserRating }));
                }
                else
                {
                    ((List<UserRating>)((object)(values[(user as UserRating).userId]))).Add(user as UserRating); ;
                }

            }
            return values;
        }

        public static void WriteMoviesShort(string sourceFile, string outputFile)
        {
            Dictionary<string, Movie> movies = DeserializeFile<Movie>(sourceFile, "\t", Constants.ClassTypes.Movies);

            List<string> allGenres = new List<string>();

            using (var writer = new StreamWriter(outputFile))
            {
                writer.WriteLine("tconst\toriginalTitle\tgenres");
                foreach (KeyValuePair<string, Movie> movie in movies)
                {
                    if (movie.Value.isAdult == "0" && Constants.AcceptedYears.Contains(movie.Value.startYear)
                        && (movie.Value.titleType.Equals("tvMovie") || movie.Value.titleType.Equals("movie"))
                        && !movie.Value.genres.Equals("\\N"))
                    {
                        string[] genres = movie.Value.genres.Split(',');
                        bool found = true;
                        foreach (string genre in genres)
                        {
                            if (!Constants.Genres.Contains(genre))
                            {
                                found = false;
                                break;
                            }
                        }

                        if (!found)
                            continue;

                        writer.WriteLine(movie.Value.tconst + "\t" + movie.Value.originalTitle + "\t" +
                            movie.Value.genres);
                    }
                }
            }
        }

        public static void WriteDirectorsShort(string moviesShortSource, string directorsFile, string outputFile)
        {
            Dictionary<string, MovieShort> moviesShort = DeserializeFile<MovieShort>(moviesShortSource, "\t", Constants.ClassTypes.MoviesShort);
            Dictionary<string, Director> directors = DeserializeFile<Director>(directorsFile, "\t", Constants.ClassTypes.Directors);

            using (var writer = new StreamWriter(outputFile))
            {
                writer.WriteLine("tconst\tdirectors");

                foreach (KeyValuePair<string, Director> director in directors)
                {
                    if (moviesShort.ContainsKey(director.Value.tconst))
                    {
                        writer.WriteLine(director.Value.tconst + "\t" + director.Value.directors);
                    }
                }
            }
        }

        public static void WriteCastShort(string moviesShortFile, string castFile, string outputFile)
        {
            Dictionary<string, string> castTitles = new Dictionary<string, string>();

            using (StreamReader reader = new StreamReader(castFile))
            {
                string line = "";

                while ((line = reader.ReadLine()) != null)
                {
                    string[] lineParts = line.Split('\t');
                    if (lineParts[3].Equals("actor") || lineParts[3].Equals("actress"))
                    {
                        if (castTitles.ContainsKey(lineParts[0]))
                        {
                            castTitles[lineParts[0]] += "|" + lineParts[2];
                        }
                        else
                        {
                            castTitles.Add(lineParts[0], lineParts[2]);
                        }
                    }
                }
            }

            Dictionary<string, MovieShort> moviesShort = DeserializeFile<MovieShort>(moviesShortFile, "\t", Constants.ClassTypes.MoviesShort);

            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                writer.WriteLine("tconst\tcast");
                foreach (KeyValuePair<string, string> castWithTitle in castTitles)
                {
                    if (moviesShort.ContainsKey(castWithTitle.Key))
                    {
                        writer.WriteLine(castWithTitle.Key + "\t" + castWithTitle.Value);
                    }
                }
            }
        }

        public static void WriteNamesShort(string directorsFile, string castFile, string namesFile, string outputFile)
        {
            Dictionary<string, DirectorShort> directorsShort =
                DeserializeFile<DirectorShort>(directorsFile, "\t", Constants.ClassTypes.DirectorsShort);

            Dictionary<string, CastShort> castShort =
                DeserializeFile<CastShort>(castFile, "\t", Constants.ClassTypes.CastShort);

            Dictionary<string, Name> names =
                DeserializeFile<Name>(namesFile, "\t", Constants.ClassTypes.Names);

            HashSet<string> personNamesSet = new HashSet<string>();

            foreach (KeyValuePair<string, DirectorShort> director in directorsShort)
            {
                string[] personsNames = director.Value.directors.Split(',');

                if (!personsNames[0].Equals("\\N"))
                {
                    foreach (string persName in personsNames)
                    {
                        if (!personNamesSet.Contains(persName))
                        {
                            personNamesSet.Add(persName);
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, CastShort> cast in castShort)
            {
                string[] personsNames = cast.Value.cast.Split('|');

                if (!personsNames[0].Equals("\\N"))
                {
                    foreach (string persName in personsNames)
                    {
                        if (!personNamesSet.Contains(persName))
                        {
                            personNamesSet.Add(persName);
                        }
                    }
                }
            }

            using (var writer = new StreamWriter(outputFile))
            {
                writer.WriteLine("nconst\tprimaryName");
                foreach (string persName in personNamesSet)
                {
                    if (names.ContainsKey(persName))
                    {
                        writer.WriteLine(names[persName].nconst + "\t" + names[persName].primaryName);
                    }
                    else
                    {
                        writer.WriteLine(persName + "\t" + "\\N");
                    }
                }
            }
        }

        public static void WriteRatingsShort(string moviesShortFile, string ratingsFile, string outpurFile)
        {
            Dictionary<string, MovieShort> moviesShort =
                DeserializeFile<MovieShort>(moviesShortFile, "\t", Constants.ClassTypes.MoviesShort);
            Dictionary<string, Rating> ratings =
              DeserializeFile<Rating>(ratingsFile, "\t", Constants.ClassTypes.Ratings);

            using (var writer = new StreamWriter(outpurFile))
            {
                writer.WriteLine("tconst\taverageRating\tnumVotes");
                foreach (KeyValuePair<string, MovieShort> movie in moviesShort)
                {
                    if (ratings.ContainsKey(movie.Key))
                    {
                        writer.WriteLine(movie.Value.tconst + "\t" + ratings[movie.Key].averageRating + "\t" + ratings[movie.Key].numVotes);
                    }
                    else
                    {
                        writer.WriteLine(movie.Value.tconst + "\t\\N\t\\N");
                    }
                }
            }
        }

        public static void WriteMoviesResultsFile(string moviesShortFile, string ratingsShortFile, string namesShortFile,
            string directorsShortFile, string castShortFile, string outputFile)
        {
            Dictionary<string, MovieShort> moviesShort =
               DeserializeFile<MovieShort>(moviesShortFile, "\t", Constants.ClassTypes.MoviesShort);

            Dictionary<string, Rating> ratingShort =
               DeserializeFile<Rating>(ratingsShortFile, "\t", Constants.ClassTypes.Ratings);

            Dictionary<string, NameShort> nameShort =
               DeserializeFile<NameShort>(namesShortFile, "\t", Constants.ClassTypes.NamesShort);

            Dictionary<string, DirectorShort> directorsShort =
               DeserializeFile<DirectorShort>(directorsShortFile, "\t", Constants.ClassTypes.DirectorsShort);

            Dictionary<string, CastShort> castShort =
              DeserializeFile<CastShort>(castShortFile, "\t", Constants.ClassTypes.CastShort);

            using (var writer = new StreamWriter(outputFile))
            {
                writer.WriteLine("titleId\ttitleName\tdirector\tcast\timdbscore\tvotes\tgenres");
                foreach (KeyValuePair<string, MovieShort> movie in moviesShort)
                {
                    string directornames = "";
                    string castNames = "";

                    string[] dirNamesParts = directorsShort[movie.Key].directors.Split(',');
                    if (dirNamesParts[0].Equals("\\N"))
                    {
                        directornames = "\\N";
                    }
                    else
                    {
                        int dirCounter = 0;
                        foreach (string dirName in dirNamesParts)
                        {
                            directornames += nameShort[dirName].primaryName;
                            dirCounter++;

                            if (dirCounter < dirNamesParts.Length)
                            {
                                directornames += "|";
                            }
                        }
                    }

                    if (!castShort.ContainsKey(movie.Key) || castShort.Equals("\\N"))
                    {
                        castNames = "\\N";
                    }
                    else
                    {
                        string[] castNameParts = castShort[movie.Key].cast.Split('|');
                        int castCounter = 0;
                        foreach (string castName in castNameParts)
                        {
                            castNames += nameShort[castName].primaryName;
                            castCounter++;

                            if (castCounter < castNameParts.Length)
                            {
                                castNames += "|";
                            }
                        }
                    }

                    writer.WriteLine(movie.Value.tconst + "\t\"" + movie.Value.originalTitle + "\"\t\"" +
                       directornames + "\"\t\"" + castNames + "\"\t" + ratingShort[movie.Value.tconst].averageRating + "\t" +
                       ratingShort[movie.Value.tconst].numVotes + "\t\"" + movie.Value.genres.Replace(",", "|") + "\"");
                }
            }
        }

        public static void CleanMoviesResultsFile(string moviesResultsFile, string outputFile)
        {
            Dictionary<string, MovieResult> moviesResults =
              DeserializeFile<MovieResult>(moviesResultsFile, "\t", Constants.ClassTypes.MoviesResult);

            using (var writer = new StreamWriter(outputFile))
            {
                int titleCounter = 0;
                writer.WriteLine("titleId,titleName,director,cast,imdbscore,votes,genres");
                foreach (KeyValuePair<string, MovieResult> movieRes in moviesResults)
                {
                    if (!movieRes.Value.titleName.Equals("\\N") && !movieRes.Value.genres.Equals("\\N") && !movieRes.Value.director.Equals("\\N") &&
                        !movieRes.Value.cast.Equals("\\N") && !movieRes.Value.imdbscore.Equals("\\N") && !movieRes.Value.votes.Equals("\\N"))
                    {
                        writer.WriteLine(titleCounter + ",\"" + movieRes.Value.titleName.Unidecode() + "\",\"" +
                        movieRes.Value.director.Unidecode() + "\",\"" + movieRes.Value.cast.Unidecode() + "\"," + movieRes.Value.imdbscore + "," +
                        movieRes.Value.votes + ",\"" + movieRes.Value.genres + "\"");

                        titleCounter++;
                    }
                }
            }
        }
    }
}