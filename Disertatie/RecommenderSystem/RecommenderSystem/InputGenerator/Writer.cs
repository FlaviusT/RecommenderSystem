using RecommenderSystem.InputGenerator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RecommenderSystem.InputGenerator
{
    public class Writer
    {
        public static void WriteMoviesShort(string sourceFile, string outputFile, List<string> acceptedYears)
        {
            Dictionary<string, Movie> movies = Parser.DeserializeFile<Movie>(sourceFile, "\t", Constants.ClassTypes.Movie);

            List<string> allGenres = new List<string>();

            using (var writer = new StreamWriter(outputFile))
            {
                writer.WriteLine("tconst\toriginalTitle\tgenres");
                foreach (KeyValuePair<string, Movie> movie in movies)
                {
                    if (movie.Value.isAdult == "0" && acceptedYears.Contains(movie.Value.startYear)
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
            Dictionary<string, MovieShort> moviesShort = Parser.DeserializeFile<MovieShort>(moviesShortSource, "\t", Constants.ClassTypes.MovieShort);
            Dictionary<string, Director> directors = Parser.DeserializeFile<Director>(directorsFile, "\t", Constants.ClassTypes.Director);

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

            Dictionary<string, MovieShort> moviesShort = Parser.DeserializeFile<MovieShort>(moviesShortFile, "\t", Constants.ClassTypes.MovieShort);

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
                Parser.DeserializeFile<DirectorShort>(directorsFile, "\t", Constants.ClassTypes.DirectorShort);

            Dictionary<string, Cast> castShort =
               Parser.DeserializeFile<Cast>(castFile, "\t", Constants.ClassTypes.Cast);

            Dictionary<string, Name> names =
               Parser.DeserializeFile<Name>(namesFile, "\t", Constants.ClassTypes.Name);

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

            foreach (KeyValuePair<string, Cast> cast in castShort)
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
                Parser.DeserializeFile<MovieShort>(moviesShortFile, "\t", Constants.ClassTypes.MovieShort);
            Dictionary<string, Rating> ratings =
             Parser.DeserializeFile<Rating>(ratingsFile, "\t", Constants.ClassTypes.Rating);

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
               Parser.DeserializeFile<MovieShort>(moviesShortFile, "\t", Constants.ClassTypes.MovieShort);

            Dictionary<string, Rating> ratingShort =
               Parser.DeserializeFile<Rating>(ratingsShortFile, "\t", Constants.ClassTypes.Rating);

            Dictionary<string, NameShort> nameShort =
               Parser.DeserializeFile<NameShort>(namesShortFile, "\t", Constants.ClassTypes.NameShort);

            Dictionary<string, DirectorShort> directorsShort =
              Parser.DeserializeFile<DirectorShort>(directorsShortFile, "\t", Constants.ClassTypes.DirectorShort);

            Dictionary<string, Cast> castShort =
              Parser.DeserializeFile<Cast>(castShortFile, "\t", Constants.ClassTypes.Cast);

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

        public static void WriteUsers(int userNumber, string outputFile)
        {
            Random rand = new Random();

            using (var writer = new StreamWriter(outputFile))
            {
                writer.WriteLine("userId,age,gender,occupation");
                for (int userId = 0; userId < userNumber; userId++)
                {
                    int userAge = UserHelper.SelectRandomAge(rand);
                    string userOccupation = UserHelper.SelectOccupationBasedOnAge(userAge, rand);
                    string userGender = UserHelper.SelectRandomGender(rand);

                    writer.WriteLine(userId + "," + userAge + "," + userGender + "," + userOccupation);
                }
            }
        }

        public static void WriteUsersRatings(string useresFile, string moviesFilePath, string outputFile)
        {
            Random rand = new Random();

            Dictionary<string, User> users =
                Parser.DeserializeFile<User>(useresFile, ",", Constants.ClassTypes.User);
            Dictionary<string, MovieResult> movies =
                Parser.DeserializeFile<MovieResult>(moviesFilePath, ",", Constants.ClassTypes.MovieResult);

            Dictionary<string, string> usersForMovies = UserHelper.AddMoviesForUsers(users, movies, rand);

            using (var writer = new StreamWriter(outputFile))
            {
                writer.WriteLine("userId,movieId,userRating");
                foreach (KeyValuePair<string, string> userForMovie in usersForMovies.OrderBy(usrKey => usrKey.Key))
                {
                    string[] movieTitles = userForMovie.Value.Split(',');

                    foreach (string movieTitle in movieTitles)
                    {
                        string userRating = UserHelper.GetRatingForMovie(users[userForMovie.Key], movies[movieTitle], rand);

                        writer.WriteLine(userForMovie.Key + "," + movieTitle + "," + userRating);
                    }
                }
            }
        }

    }
}
