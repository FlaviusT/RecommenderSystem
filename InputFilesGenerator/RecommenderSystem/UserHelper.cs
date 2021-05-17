using RecommenderSystem.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace RecommenderSystem
{
    public class UserHelper
    {
        public static void CreateUsers(int userNumber, string outputFile)
        {
            Random rand = new Random();

            using (var writer = new StreamWriter(outputFile))
            {
                writer.WriteLine("userId,age,gender,occupation");
                for (int userId = 0; userId < userNumber; userId++)
                {
                    int userAge = SelectRandomAge(rand);
                    string userOccupation = SelectRandomOccupation(userAge, rand);
                    string userGender = SelectRandomGender(rand);

                    writer.WriteLine(userId + "," + userAge + "," + userGender + "," + userOccupation);
                }
            }
        }

        public static void CreateUsersRatings(string useresFile, string moviesFilePath, string outputFile)
        {
            Random rand = new Random();

            Dictionary<string, User> users =
                Parsers.DeserializeFile<User>(useresFile, ",", Constants.ClassTypes.Users);
            Dictionary<string, MovieResult> movies =
                Parsers.DeserializeFile<MovieResult>(moviesFilePath, ",", Constants.ClassTypes.MoviesResult);

            Dictionary<string, string> usersForMovies = AddMoviesForUsers(users, movies, rand);

            using (var writer = new StreamWriter(outputFile))
            {
                writer.WriteLine("userId,movieId,userRating");
                foreach (KeyValuePair<string, string> userForMovie in usersForMovies.OrderBy(usrKey => usrKey.Key))
                {
                    string[] movieTitles = userForMovie.Value.Split(',');

                    foreach (string movieTitle in movieTitles)
                    {
                        string userRating = GetRatingForMovie(users[userForMovie.Key], movies[movieTitle], rand);

                        writer.WriteLine(userForMovie.Key + "," + movieTitle + "," + userRating);
                    }
                }
            }
        }

        private static int SelectRandomAge(Random r)
        {
            int age = 0;
            age = r.Next(7, 85);
            return age;
        }

        private static string SelectRandomGender(Random r)
        {
            int someValue = r.Next(1, 100);

            string gender;

            if (someValue % 2 == 0)
            {
                gender = "F";
            }
            else
            {
                gender = "M";
            }

            return gender;
        }

        private static string SelectRandomOccupation(int age, Random rand)
        {
            string occup = "";
            List<string> occupationsToSelect = new List<string>();

            if (age <= 25)
            {
                occupationsToSelect.Add(Constants.OCCUPATION_STUDENT);
                occupationsToSelect.Add(Constants.OCCUPATION_ARTIST);
                occupationsToSelect.Add(Constants.OCCUPATION_ENTERNTAINMENT);
            }
            else if (age > 25 && age < 30)
            {
                occupationsToSelect.Add(Constants.OCCUPATION_STUDENT);
                occupationsToSelect.Add(Constants.OCCUPATION_ARTIST);
                occupationsToSelect.Add(Constants.OCCUPATION_ENTERNTAINMENT);
                occupationsToSelect.Add(Constants.OCCUPATION_EDUCATOR);
                occupationsToSelect.Add(Constants.OCCUPATION_HEALTHCARE);
                occupationsToSelect.Add(Constants.OCCUPATION_HOMEMAKER);
                occupationsToSelect.Add(Constants.OCCUPATION_NONE);
                occupationsToSelect.Add(Constants.OCCUPATION_PROGRAMMER);
            }
            else if (age >= 30 && age < 40)
            {
                occupationsToSelect.Add(Constants.OCCUPATION_ARTIST);
                occupationsToSelect.Add(Constants.OCCUPATION_ENTERNTAINMENT);
                occupationsToSelect.Add(Constants.OCCUPATION_EDUCATOR);
                occupationsToSelect.Add(Constants.OCCUPATION_HEALTHCARE);
                occupationsToSelect.Add(Constants.OCCUPATION_HOMEMAKER);
                occupationsToSelect.Add(Constants.OCCUPATION_NONE);
                occupationsToSelect.Add(Constants.OCCUPATION_PROGRAMMER);
                occupationsToSelect.Add(Constants.OCCUPATION_ADMINISTRATOR);
                occupationsToSelect.Add(Constants.OCCUPATION_DOCTOR);
                occupationsToSelect.Add(Constants.OCCUPATION_ENGINEER);
                occupationsToSelect.Add(Constants.OCCUPATION_LAWYER);
                occupationsToSelect.Add(Constants.OCCUPATION_MARKETING);
                occupationsToSelect.Add(Constants.OCCUPATION_SALESMAN);
                occupationsToSelect.Add(Constants.OCCUPATION_SCIENTIST);
                occupationsToSelect.Add(Constants.OCCUPATION_TECHINCIAN);
                occupationsToSelect.Add(Constants.OCCUPATION_WRITER);
            }
            else if (age >= 40 && age < 55)
            {
                occupationsToSelect.Add(Constants.OCCUPATION_ARTIST);
                occupationsToSelect.Add(Constants.OCCUPATION_ENTERNTAINMENT);
                occupationsToSelect.Add(Constants.OCCUPATION_EDUCATOR);
                occupationsToSelect.Add(Constants.OCCUPATION_HEALTHCARE);
                occupationsToSelect.Add(Constants.OCCUPATION_HOMEMAKER);
                occupationsToSelect.Add(Constants.OCCUPATION_NONE);
                occupationsToSelect.Add(Constants.OCCUPATION_PROGRAMMER);
                occupationsToSelect.Add(Constants.OCCUPATION_ADMINISTRATOR);
                occupationsToSelect.Add(Constants.OCCUPATION_DOCTOR);
                occupationsToSelect.Add(Constants.OCCUPATION_ENGINEER);
                occupationsToSelect.Add(Constants.OCCUPATION_LAWYER);
                occupationsToSelect.Add(Constants.OCCUPATION_LIBRARIAN);
                occupationsToSelect.Add(Constants.OCCUPATION_MARKETING);
                occupationsToSelect.Add(Constants.OCCUPATION_SALESMAN);
                occupationsToSelect.Add(Constants.OCCUPATION_SCIENTIST);
                occupationsToSelect.Add(Constants.OCCUPATION_TECHINCIAN);
                occupationsToSelect.Add(Constants.OCCUPATION_WRITER);
            }
            else if (age >= 55 && age < 60)
            {
                occupationsToSelect.Add(Constants.OCCUPATION_ENTERNTAINMENT);
                occupationsToSelect.Add(Constants.OCCUPATION_EDUCATOR);
                occupationsToSelect.Add(Constants.OCCUPATION_HEALTHCARE);
                occupationsToSelect.Add(Constants.OCCUPATION_HOMEMAKER);
                occupationsToSelect.Add(Constants.OCCUPATION_NONE);
                occupationsToSelect.Add(Constants.OCCUPATION_ADMINISTRATOR);
                occupationsToSelect.Add(Constants.OCCUPATION_DOCTOR);
                occupationsToSelect.Add(Constants.OCCUPATION_ENGINEER);
                occupationsToSelect.Add(Constants.OCCUPATION_LAWYER);
                occupationsToSelect.Add(Constants.OCCUPATION_LIBRARIAN);
                occupationsToSelect.Add(Constants.OCCUPATION_RETIRED);
                occupationsToSelect.Add(Constants.OCCUPATION_SCIENTIST);
                occupationsToSelect.Add(Constants.OCCUPATION_WRITER);
            }
            else if (age >= 60)
            {
                occupationsToSelect.Add(Constants.OCCUPATION_RETIRED);
                occupationsToSelect.Add(Constants.OCCUPATION_DOCTOR);
                occupationsToSelect.Add(Constants.OCCUPATION_LIBRARIAN);
                occupationsToSelect.Add(Constants.OCCUPATION_WRITER);
            }

            int index = rand.Next(occupationsToSelect.Count);
            occup = occupationsToSelect[index];

            return occup;
        }

        private static Dictionary<string, string> AddMoviesForUsers(Dictionary<string, User> users, Dictionary<string, MovieResult> movies,
            Random rand)
        {
            Dictionary<string, string> usersForMovies = new Dictionary<string, string>();

            int movieCounter = 0;

            foreach (KeyValuePair<string, MovieResult> movie in movies)
            {
                HashSet<int> usedUsers = new HashSet<int>();
                int totalVotesPerMovie = 0;

                if (int.Parse(movie.Value.votes) < 150)
                {
                    totalVotesPerMovie = int.Parse(movie.Value.votes);
                }
                else if (int.Parse(movie.Value.votes) > 1000000)
                {
                    totalVotesPerMovie = 350;
                }
                else if (int.Parse(movie.Value.votes) > 100000)
                {
                    totalVotesPerMovie = 300;
                }
                else
                {
                    int thousandsOfVotes = int.Parse(movie.Value.votes) / 100;
                    if (thousandsOfVotes > 150)
                    {
                        totalVotesPerMovie = rand.Next(150, 300);
                    }
                    else
                    {
                        totalVotesPerMovie = rand.Next(150, 150 + thousandsOfVotes);
                    }
                }

                for (int userCounter = 0; userCounter < totalVotesPerMovie; userCounter++)
                {
                    if (movieCounter % (movies.Count() * 5) / 100 == 0)
                    {
                        foreach (KeyValuePair<string, User> user in users)
                        {
                            if (userCounter >= totalVotesPerMovie)
                            {
                                break;
                            }

                            if (!usersForMovies.ContainsKey(user.Key))
                            {
                                usersForMovies.Add(user.Key, movie.Value.titleId);
                                usedUsers.Add(int.Parse(user.Key));
                                userCounter++;
                            }
                        }
                    }

                    if (userCounter >= totalVotesPerMovie)
                    {
                        break;
                    }

                    int userIndex = rand.Next(users.Count);

                    if (!usedUsers.Contains(userIndex))
                    {
                        usedUsers.Add(userIndex);
                    }
                    else
                    {
                        int lastIndex = userIndex;
                        for (int index = userIndex; index < users.Count; index++)
                        {
                            if (!usedUsers.Contains(index))
                            {
                                userIndex = index;
                                break;
                            }
                        }

                        if (usedUsers.Contains(userIndex))
                        {
                            for (int index = lastIndex; index >= 0; index--)
                            {
                                if (!usedUsers.Contains(index))
                                {
                                    userIndex = index;
                                    break;
                                }
                            }
                        }

                        usedUsers.Add(userIndex);
                    }

                    if (!usersForMovies.ContainsKey(userIndex.ToString()))
                    {
                        usersForMovies.Add(userIndex.ToString(), movie.Value.titleId);
                    }
                    else
                    {
                        usersForMovies[userIndex.ToString()] += "," + movie.Value.titleId;
                    }
                }

                usedUsers.Clear();
                movieCounter++;
            }

            foreach (KeyValuePair<string, User> user in users)
            {
                if (!usersForMovies.ContainsKey(user.Key))
                {
                    for (int movieCnt = 0; movieCnt < 5; movieCnt++)
                    {
                        usersForMovies.Add(user.Key, movies[rand.Next(0, movies.Count()).ToString()].titleId);
                    }
                }
            }

            return usersForMovies;
        }

        private static string GetRatingForMovie(User user, MovieResult movie, Random rand)
        {
            string rating = "";

            string movieGenres = movie.genres;
            string userFavGenres = GetUserFavoriteGenres(user.age, user.occupation, user.gender, rand);
            string movieAvgScore = movie.imdbscore;



            string[] movieGenresparts = movieGenres.Split('|');
            foreach (string mov in movieGenresparts)
            {
                if (!Constants.Genres.Contains(mov))
                {
                    throw new Exception();
                }
            }

            if (string.IsNullOrEmpty(userFavGenres))
            {
                throw new Exception();
            }

            rating = ComputeRatingForUser(movieGenres, userFavGenres, movieAvgScore, rand);

            return rating;
        }

        private static string GetUserFavoriteGenres(string age, string occupation, string gender, Random rand)
        {
            int userAge = int.Parse(age);
            string userFavGenres = "";

            List<string> favGenres = new List<string>();

            // Compute a value that will try to mimic the person character 
            // and preferences (we will add 30% exceptions later)
            // Value from 0 to 100. 100 means very serious
            int seriousnessValue = 0;
            int romantismValue = 0;
            int sportValue = 0;
            int actionValue = 0;
            int curiosityValue = 0;
            int scaryValue = 0;

            if (userAge >= 7 && userAge < 12)
            {
                seriousnessValue = rand.Next(5, 15);
                romantismValue = rand.Next(2, 8);
                sportValue = rand.Next(8, 18);
                actionValue = rand.Next(10, 20);
                curiosityValue = rand.Next(25, 40);
                scaryValue = rand.Next(2, 6);
            }
            else if (userAge >= 12 && userAge < 16)
            {
                seriousnessValue = rand.Next(15, 25);
                romantismValue = rand.Next(15, 30);
                sportValue = rand.Next(2, 30);
                actionValue = rand.Next(15, 45);
                curiosityValue = rand.Next(10, 25);
                scaryValue = rand.Next(5, 25);
            }
            else if (userAge >= 16 && userAge < 22)
            {
                seriousnessValue = rand.Next(20, 30);
                romantismValue = rand.Next(25, 40);
                sportValue = rand.Next(5, 35);
                actionValue = rand.Next(10, 35);
                curiosityValue = rand.Next(10, 25);
                scaryValue = rand.Next(5, 30);
            }
            else if (userAge >= 22 && userAge < 28)
            {
                seriousnessValue = rand.Next(20, 35);
                romantismValue = rand.Next(20, 45);
                sportValue = rand.Next(10, 50);
                actionValue = rand.Next(10, 30);
                curiosityValue = rand.Next(10, 20);
                scaryValue = rand.Next(5, 30);
            }
            else if (userAge >= 28 && userAge < 35)
            {
                seriousnessValue = rand.Next(25, 35);
                romantismValue = rand.Next(20, 35);
                sportValue = rand.Next(10, 50);
                actionValue = rand.Next(10, 20);
                curiosityValue = rand.Next(25, 40);
                scaryValue = rand.Next(5, 25);
            }
            else if (userAge >= 35 && userAge < 44)
            {
                seriousnessValue = rand.Next(30, 50);
                romantismValue = rand.Next(15, 30);
                sportValue = rand.Next(5, 50);
                actionValue = rand.Next(15, 35);
                curiosityValue = rand.Next(5, 25);
                scaryValue = rand.Next(2, 15);
            }
            else if (userAge >= 44 && userAge < 52)
            {
                seriousnessValue = rand.Next(35, 60);
                romantismValue = rand.Next(13, 25);
                sportValue = rand.Next(5, 50);
                actionValue = rand.Next(20, 45);
                curiosityValue = rand.Next(5, 25);
                scaryValue = rand.Next(1, 5);
            }
            else if (userAge >= 52 && userAge < 60)
            {
                seriousnessValue = rand.Next(30, 70);
                romantismValue = rand.Next(10, 22);
                sportValue = rand.Next(5, 45);
                actionValue = rand.Next(20, 40);
                curiosityValue = rand.Next(5, 25);
                scaryValue = rand.Next(1, 5);
            }
            else if (userAge >= 60)
            {
                seriousnessValue = rand.Next(35, 65);
                romantismValue = rand.Next(7, 17);
                sportValue = rand.Next(15, 55);
                actionValue = rand.Next(20, 40);
                curiosityValue = rand.Next(5, 25);
                scaryValue = rand.Next(1, 5);
            }


            if (occupation.Equals(Constants.OCCUPATION_ADMINISTRATOR))
            {
                seriousnessValue += rand.Next(10, 15);
                romantismValue = rand.Next(2, 5);
                sportValue = rand.Next(5, 10);
                actionValue = rand.Next(5, 10);
                curiosityValue = rand.Next(5, 10);
                scaryValue = rand.Next(1, 5);
            }
            else if (occupation.Equals(Constants.OCCUPATION_ARTIST))
            {
                seriousnessValue += rand.Next(4, 10);
                romantismValue += rand.Next(5, 10);
                sportValue += rand.Next(2, 10);
                actionValue += rand.Next(5, 10);
                curiosityValue += rand.Next(5, 10);
                scaryValue += rand.Next(1, 5);
            }
            else if (occupation.Equals(Constants.OCCUPATION_DOCTOR))
            {
                seriousnessValue += rand.Next(10, 15);
                romantismValue += rand.Next(5, 10);
                sportValue += rand.Next(2, 10);
                actionValue += rand.Next(5, 10);
                curiosityValue += rand.Next(15, 20);
                scaryValue += rand.Next(1, 5);
            }
            else if (occupation.Equals(Constants.OCCUPATION_EDUCATOR))
            {
                seriousnessValue += rand.Next(10, 15);
                romantismValue += rand.Next(5, 10);
                sportValue += rand.Next(2, 10);
                actionValue += rand.Next(5, 10);
                curiosityValue += rand.Next(5, 10);
                scaryValue += rand.Next(1, 3);
            }
            else if (occupation.Equals(Constants.OCCUPATION_ENGINEER))
            {
                seriousnessValue += rand.Next(10, 15);
                romantismValue += rand.Next(5, 10);
                sportValue += rand.Next(2, 10);
                actionValue += rand.Next(5, 10);
                curiosityValue += rand.Next(5, 10);
                scaryValue += rand.Next(1, 3);
            }
            else if (occupation.Equals(Constants.OCCUPATION_ENTERNTAINMENT))
            {
                seriousnessValue += rand.Next(8, 12);
                romantismValue += rand.Next(5, 10);
                sportValue += rand.Next(2, 10);
                actionValue += rand.Next(10, 15);
                curiosityValue += rand.Next(5, 10);
                scaryValue += rand.Next(1, 3);
            }
            else if (occupation.Equals(Constants.OCCUPATION_HEALTHCARE))
            {
                seriousnessValue += rand.Next(6, 11);
                romantismValue += rand.Next(5, 10);
                sportValue += rand.Next(2, 10);
                actionValue += rand.Next(5, 10);
                curiosityValue += rand.Next(5, 10);
                scaryValue += rand.Next(1, 3);
            }
            else if (occupation.Equals(Constants.OCCUPATION_LAWYER))
            {
                seriousnessValue += rand.Next(15, 20);
                romantismValue += rand.Next(5, 10);
                sportValue += rand.Next(2, 10);
                actionValue += rand.Next(5, 10);
                curiosityValue += rand.Next(10, 15);
                scaryValue += rand.Next(1, 3);
            }
            else if (occupation.Equals(Constants.OCCUPATION_HOMEMAKER))
            {
                seriousnessValue += rand.Next(6, 11);
                romantismValue += rand.Next(5, 10);
                sportValue += rand.Next(2, 10);
                actionValue += rand.Next(5, 10);
                curiosityValue += rand.Next(5, 10);
                scaryValue += rand.Next(1, 3);
            }
            else if (occupation.Equals(Constants.OCCUPATION_LIBRARIAN))
            {
                seriousnessValue += rand.Next(7, 11);
                romantismValue += rand.Next(5, 20);
                sportValue += rand.Next(2, 10);
                actionValue += rand.Next(5, 10);
                curiosityValue += rand.Next(10, 20);
                scaryValue += rand.Next(1, 3);
            }
            else if (occupation.Equals(Constants.OCCUPATION_MARKETING))
            {
                seriousnessValue += rand.Next(6, 9);
                romantismValue += rand.Next(5, 10);
                sportValue += rand.Next(2, 10);
                actionValue += rand.Next(5, 10);
                curiosityValue += rand.Next(5, 10);
                scaryValue += rand.Next(1, 3);
            }
            else if (occupation.Equals(Constants.OCCUPATION_NONE))
            {
                seriousnessValue += rand.Next(4, 7);
                romantismValue += rand.Next(5, 10);
                sportValue += rand.Next(2, 10);
                actionValue += rand.Next(5, 10);
                curiosityValue += rand.Next(5, 10);
                scaryValue += rand.Next(1, 3);
            }
            else if (occupation.Equals(Constants.OCCUPATION_PROGRAMMER))
            {
                seriousnessValue += rand.Next(3, 5);
                romantismValue += rand.Next(5, 10);
                sportValue += rand.Next(1, 3);
                actionValue += rand.Next(5, 10);
                curiosityValue += rand.Next(15, 25);
                scaryValue += rand.Next(1, 3);
            }
            else if (occupation.Equals(Constants.OCCUPATION_RETIRED))
            {
                seriousnessValue += rand.Next(10, 15);
                romantismValue += rand.Next(5, 10);
                sportValue += rand.Next(1, 3);
                actionValue += rand.Next(5, 10);
                curiosityValue += rand.Next(5, 15);
                scaryValue += rand.Next(1, 2);
            }
            else if (occupation.Equals(Constants.OCCUPATION_SALESMAN))
            {
                seriousnessValue += rand.Next(5, 11);
                romantismValue += rand.Next(5, 10);
                sportValue += rand.Next(1, 3);
                actionValue += rand.Next(5, 10);
                curiosityValue += rand.Next(4, 15);
                scaryValue += rand.Next(1, 2);
            }
            else if (occupation.Equals(Constants.OCCUPATION_SCIENTIST))
            {
                seriousnessValue += rand.Next(15, 25);
                romantismValue += rand.Next(5, 10);
                sportValue += rand.Next(1, 3);
                actionValue += rand.Next(5, 10);
                curiosityValue += rand.Next(15, 30);
                scaryValue += rand.Next(1, 2);
            }
            else if (occupation.Equals(Constants.OCCUPATION_STUDENT))
            {
                seriousnessValue += rand.Next(2, 8);
                romantismValue += rand.Next(15, 25);
                sportValue += rand.Next(5, 20);
                actionValue += rand.Next(5, 15);
                curiosityValue += rand.Next(10, 30);
                scaryValue += rand.Next(5, 15);
            }
            else if (occupation.Equals(Constants.OCCUPATION_TECHINCIAN))
            {
                seriousnessValue += rand.Next(7, 12);
                romantismValue += rand.Next(2, 6);
                sportValue += rand.Next(1, 3);
                actionValue += rand.Next(5, 10);
                curiosityValue += rand.Next(5, 14);
                scaryValue += rand.Next(1, 2);
            }
            else if (occupation.Equals(Constants.OCCUPATION_WRITER))
            {
                seriousnessValue += rand.Next(4, 11);
                romantismValue += rand.Next(10, 20);
                sportValue += rand.Next(1, 5);
                actionValue += rand.Next(5, 15);
                curiosityValue += rand.Next(10, 25);
                scaryValue += rand.Next(1, 8);
            }

            if (gender.Equals("F"))
            {
                romantismValue += rand.Next(5, 15);
            }
            else
            {
                sportValue += rand.Next(10, 20);
                curiosityValue += rand.Next(10, 25);
                scaryValue += rand.Next(1, 4);
            }

            // For DRAMA
            if (GuessGenre(30, 25, 10, 20, 20, 15, seriousnessValue, romantismValue, sportValue, actionValue, curiosityValue, scaryValue))
            {
                favGenres.Add(Constants.MOVIE_GENRE_DRAMA);
            }
            // For DOCUEMNTARY
            if (GuessGenre(45, 10, 10, 10, 40, 5, seriousnessValue, romantismValue, sportValue, actionValue, curiosityValue, scaryValue))
            {
                favGenres.Add(Constants.MOVIE_GENRE_DOCUMENTARY);
            }
            // For ADVENTURE
            if (GuessGenre(25, 10, 10, 35, 15, 5, seriousnessValue, romantismValue, sportValue, actionValue, curiosityValue, scaryValue))
            {
                favGenres.Add(Constants.MOVIE_GENRE_ADVENTURE);
            }
            // For ANIMATION
            if (GuessGenre(10, 15, 10, 25, 10, 5, seriousnessValue, romantismValue, sportValue, actionValue, curiosityValue, scaryValue))
            {
                favGenres.Add(Constants.MOVIE_GENRE_ANIMATION);
            }
            // For FAMILY
            if (GuessGenre(20, 5, 15, 15, 10, 3, seriousnessValue, romantismValue, sportValue, actionValue, curiosityValue, scaryValue))
            {
                favGenres.Add(Constants.MOVIE_GENRE_FAMILY);
            }
            // For CRIME
            if (GuessGenre(35, 10, 15, 15, 10, 8, seriousnessValue, romantismValue, sportValue, actionValue, curiosityValue, scaryValue))
            {
                favGenres.Add(Constants.MOVIE_GENRE_CRIME);
            }
            // For MYSTERY
            if (GuessGenre(35, 10, 15, 15, 35, 10, seriousnessValue, romantismValue, sportValue, actionValue, curiosityValue, scaryValue))
            {
                favGenres.Add(Constants.MOVIE_GENRE_MYSTERY);
            }
            // For ACTION
            if (GuessGenre(25, 10, 15, 30, 15, 5, seriousnessValue, romantismValue, sportValue, actionValue, curiosityValue, scaryValue))
            {
                favGenres.Add(Constants.MOVIE_GENRE_ACTION);
            }
            // For WAR
            if (GuessGenre(30, 5, 15, 20, 15, 10, seriousnessValue, romantismValue, sportValue, actionValue, curiosityValue, scaryValue))
            {
                favGenres.Add(Constants.MOVIE_GENRE_WAR);
            }
            // For SCIFI
            if (GuessGenre(20, 5, 5, 15, 25, 5, seriousnessValue, romantismValue, sportValue, actionValue, curiosityValue, scaryValue))
            {
                favGenres.Add(Constants.MOVIE_GENRE_SCIFI);
            }
            // For COMEDY
            if (GuessGenre(15, 25, 5, 15, 25, 2, seriousnessValue, romantismValue, sportValue, actionValue, curiosityValue, scaryValue))
            {
                favGenres.Add(Constants.MOVIE_GENRE_COMEDY);
            }
            // For ROMANCE
            if (GuessGenre(25, 35, 5, 10, 20, 1, seriousnessValue, romantismValue, sportValue, actionValue, curiosityValue, scaryValue))
            {
                favGenres.Add(Constants.MOVIE_GENRE_ROMANCE);
            }
            // For HORROR
            if (GuessGenre(25, 5, 5, 10, 25, 30, seriousnessValue, romantismValue, sportValue, actionValue, curiosityValue, scaryValue))
            {
                favGenres.Add(Constants.MOVIE_GENRE_HORROR);
            }
            // For THRILLER
            if (GuessGenre(25, 5, 5, 10, 25, 20, seriousnessValue, romantismValue, sportValue, actionValue, curiosityValue, scaryValue))
            {
                favGenres.Add(Constants.MOVIE_GENRE_THRILLER);
            }
            // For SPORT
            if (GuessGenre(20, 5, 30, 15, 10, 1, seriousnessValue, romantismValue, sportValue, actionValue, curiosityValue, scaryValue))
            {
                favGenres.Add(Constants.MOVIE_GENRE_SPORT);
            }
            // For FANTASY
            if (GuessGenre(15, 5, 5, 25, 15, 2, seriousnessValue, romantismValue, sportValue, actionValue, curiosityValue, scaryValue))
            {
                favGenres.Add(Constants.MOVIE_GENRE_FANTASY);
            }
            // For BIOGRAPHY
            if (GuessGenre(25, 5, 5, 5, 20, 2, seriousnessValue, romantismValue, sportValue, actionValue, curiosityValue, scaryValue))
            {
                favGenres.Add(Constants.MOVIE_GENRE_BIOGRAPHY);
            }
            // For MUSIC
            if (GuessGenre(15, 30, 5, 10, 15, 1, seriousnessValue, romantismValue, sportValue, actionValue, curiosityValue, scaryValue))
            {
                favGenres.Add(Constants.MOVIE_GENRE_MUSIC);
            }
            // For MUSICAL
            if (GuessGenre(15, 30, 5, 10, 15, 1, seriousnessValue, romantismValue, sportValue, actionValue, curiosityValue, scaryValue))
            {
                favGenres.Add(Constants.MOVIE_GENRE_MUSICAL);
            }
            // For WESTERN
            if (GuessGenre(25, 5, 5, 15, 15, 2, seriousnessValue, romantismValue, sportValue, actionValue, curiosityValue, scaryValue))
            {
                favGenres.Add(Constants.MOVIE_GENRE_WESTERN);
            }
            // For HISTORY
            if (GuessGenre(25, 5, 5, 10, 25, 3, seriousnessValue, romantismValue, sportValue, actionValue, curiosityValue, scaryValue))
            {
                favGenres.Add(Constants.MOVIE_GENRE_HISTORY);
            }

            int genreCounter = 1;

            foreach (string genre in favGenres.Distinct().ToList())
            {
                userFavGenres += genre;

                if (genreCounter < favGenres.Distinct().ToList().Count())
                {
                    userFavGenres += "|";
                }

                genreCounter++;
            }

            return userFavGenres;
        }

        private static bool GuessGenre(int seriousPercent, int romantismPercent, int sportPercent, int actionPercent, int curiosityPercent, int scaryPercent,
            int seriousValue, int romantismValue, int sportValue, int actionValue, int curiosityValue, int scaryValue)
        {
            bool hasGenre = true;

            int seriousGuessingValue = (seriousValue * 100) / seriousPercent;
            int romantismGuessingValue = (romantismValue * 100) / romantismPercent;
            int sportGuessingValue = (sportValue * 100) / sportPercent;
            int actionGuessingValue = (actionValue * 100) / actionPercent;
            int curiosityGuessingValue = (curiosityValue * 100) / curiosityPercent;
            int scaryGuessingValue = (scaryValue * 100) / scaryPercent;

            if (seriousGuessingValue < 40 && romantismGuessingValue < 40 && sportGuessingValue < 40 && actionGuessingValue < 40 &&
                curiosityGuessingValue < 40 && scaryGuessingValue < 40)
            {
                Dictionary<string, int> orderedPercentages = OrdonatePercents(seriousPercent, romantismPercent, sportPercent, actionPercent, curiosityPercent, scaryPercent);
                Dictionary<string, int> values = new Dictionary<string, int>() { };
                values.Add("serious", seriousValue);
                values.Add("romantism", romantismValue);
                values.Add("sport", sportValue);
                values.Add("action", actionValue);
                values.Add("curiosity", curiosityValue);
                values.Add("scary", scaryValue);

                if (((values[orderedPercentages.ElementAt(0).Key] < (orderedPercentages.ElementAt(0).Value * 0.7)) &&
                    (values[orderedPercentages.ElementAt(0).Key] > (orderedPercentages.ElementAt(0).Value * 1.3))) ||
                    ((values[orderedPercentages.ElementAt(1).Key] < (orderedPercentages.ElementAt(1).Value * 0.6)) &&
                    (values[orderedPercentages.ElementAt(1).Key] > (orderedPercentages.ElementAt(1).Value * 1.4))) ||
                    ((values[orderedPercentages.ElementAt(2).Key] < (orderedPercentages.ElementAt(2).Value * 0.5)) &&
                    (values[orderedPercentages.ElementAt(2).Key] > (orderedPercentages.ElementAt(2).Value * 1.5))))
                {
                    hasGenre = false;
                }
            }

            return hasGenre;
        }

        private static Dictionary<string, int> OrdonatePercents(int seriousPercent, int romantismPercent, int sportPercent, int actionPercent, int curiosityPercent, int scaryPercent)
        {
            Dictionary<string, int> orderedPercentages = new Dictionary<string, int>();
            orderedPercentages.Add("serious", seriousPercent);
            orderedPercentages.Add("romantism", romantismPercent);
            orderedPercentages.Add("sport", sportPercent);
            orderedPercentages.Add("action", actionPercent);
            orderedPercentages.Add("curiosity", curiosityPercent);
            orderedPercentages.Add("scary", scaryPercent);

            return orderedPercentages.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        private static string ComputeRatingForUser(string movieGenres, string userFavGenres, string movieScore, Random rand)
        {
            double rating = 0;

            string[] listOfMovieGenres = movieGenres.Split('|');
            string[] listOfUserGenres = userFavGenres.Split('|');
            double scoreOfMovie = double.Parse(movieScore);

            if (scoreOfMovie < 3)
            {
                rating = Math.Round(rand.Next(1, 4) * 2.0, MidpointRounding.AwayFromZero) / 2;
            }
            else if (scoreOfMovie > 7)
            {
                rating = Math.Round(rand.Next(7, 11) * 2.0, MidpointRounding.AwayFromZero) / 2;
            }
            else
            {
                int scoreinteger = (int)(scoreOfMovie * 2);

                rating = Math.Round(rand.Next(scoreinteger - 5, scoreinteger + 5) * 1.0, MidpointRounding.AwayFromZero) / 2;
            }

            foreach (string movieGenre in listOfMovieGenres)
            {
                if (listOfUserGenres.Contains(movieGenre))
                {
                    int coinflip = rand.Next(1, 11);
                    if (coinflip % 2 == 0)
                    {
                        rating += Math.Round(rand.Next(1, 4) * 2.0, MidpointRounding.AwayFromZero) / 2;
                    }
                }
                else
                {
                    int coinflip = rand.Next(1, 11);
                    if (coinflip % 2 == 0)
                    {
                        rating -= Math.Round(rand.Next(1, 4) * 2.0, MidpointRounding.AwayFromZero) / 2;
                    }
                }
            }

            if (rating > 10)
            {
                rating = 10;
            }
            else if (rating < 1)
            {
                rating = 1;
            }

            return rating.ToString();
        }
    }
}
