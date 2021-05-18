using CsvHelper;
using CsvHelper.Configuration;
using RecommenderSystem.InputGenerator.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace RecommenderSystem.InputGenerator
{
    public class Parser
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
                case Constants.ClassTypes.Movie:
                    {
                        foreach (T movie in dataList)
                        {
                            values.Add((movie as Movie).tconst, movie);
                        }
                        break;
                    }

                case Constants.ClassTypes.MovieShort:
                    {
                        foreach (T movieShort in dataList)
                        {
                            values.Add((movieShort as MovieShort).tconst, movieShort);
                        }
                        break;
                    }
                case Constants.ClassTypes.MovieResult:
                    {
                        foreach (T movieResult in dataList)
                        {
                            values.Add((movieResult as MovieResult).titleId, movieResult);
                        }
                        break;
                    }
                case Constants.ClassTypes.Rating:
                    {
                        foreach (T rating in dataList)
                        {
                            values.Add((rating as Rating).tconst, rating);
                        }
                        break;
                    }
                case Constants.ClassTypes.Director:
                    {
                        foreach (T director in dataList)
                        {
                            values.Add((director as Director).tconst, director);
                        }
                        break;
                    }
                case Constants.ClassTypes.DirectorShort:
                    {
                        foreach (T directorShort in dataList)
                        {
                            values.Add((directorShort as DirectorShort).tconst, directorShort);
                        }
                        break;
                    }
                case Constants.ClassTypes.Cast:
                    {
                        foreach (T castShort in dataList)
                        {
                            values.Add((castShort as Cast).tconst, castShort);
                        }
                        break;
                    }
                case Constants.ClassTypes.Name:
                    {
                        foreach (T name in dataList)
                        {
                            values.Add((name as Name).nconst, name);
                        }
                        break;
                    }
                case Constants.ClassTypes.NameShort:
                    {
                        foreach (T nameShort in dataList)
                        {
                            values.Add((nameShort as NameShort).nconst, nameShort);
                        }
                        break;
                    }
                case Constants.ClassTypes.User:
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
    }
}
