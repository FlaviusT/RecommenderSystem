using System;
using System.Collections.Generic;
using System.IO;
using RecommenderSystem.Models;

namespace RecommenderSystem
{
    static class MainClass
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string titleBasics = "", directorsBasics = "", ratingsBasics = "",
                namesBasics = "", titleShort = "", directorsShort = "",
                ratingsShort = "", namesShort = "", moviesFullDirty = "",
                moviesFullCleaned = "", usersOutput = "", usersRatingsOutput = "";

            int userCounter = 0;

            InitializeVariables(ref titleBasics, ref directorsBasics, ref ratingsBasics, ref namesBasics,
              ref titleShort, ref directorsShort, ref ratingsShort, ref namesShort, ref moviesFullDirty,
               ref moviesFullCleaned, ref usersOutput, ref usersRatingsOutput, ref userCounter);

            //Parsers.WriteMoviesShort(titleBasics, titleShort);

            //Parsers.WriteDirectorsShort(titleShort, directorsBasics, directorsShort);

            //Parsers.WriteNamesShort(directorsShort, namesBasics, namesShort);

            //Parsers.WriteRatingsShort(titleShort, ratingsBasics, ratingsShort);

            //Parsers.WriteMoviesResultsFile(titleShort, ratingsShort, namesShort, directorsShort, moviesFullDirty);

            //Parsers.CleanMoviesResultsFile(moviesFullDirty, moviesFullCleaned);

            //UserHelper.CreateUsers(userCounter, usersOutput);

            //UserHelper.CreateUsersRatings(usersOutput, moviesFullCleaned, usersRatingsOutput);

            CheckOutputFiles(moviesFullCleaned, usersOutput, usersRatingsOutput);
        }

        private static void InitializeVariables(ref string titleBasics, ref string directorsBasics, ref string ratingsBasics,
           ref string namesBasics, ref string titleShort, ref string directorsShort, ref string ratingsShort, ref string namesShort,
           ref string moviesFullDirty, ref string moviesFullCleaned, ref string usersOutput, ref string usersRatingsOutput,
           ref int userCounter)
        {
            titleBasics = @"C:\Users\uidj1061\Desktop\New folder\titlebasics.tsv";
            directorsBasics = @"C:\Users\uidj1061\Desktop\New folder\titlecrew.tsv";
            ratingsBasics = @"C:\Users\uidj1061\Desktop\New folder\titleratings.tsv";
            namesBasics = @"C:\Users\uidj1061\Desktop\New folder\namebasics.tsv";

            titleShort = @"C:\Users\uidj1061\Desktop\New folder\shorts\titleshort.tsv";
            directorsShort = @"C:\Users\uidj1061\Desktop\New folder\shorts\directorsshort.tsv";
            ratingsShort = @"C:\Users\uidj1061\Desktop\New folder\shorts\ratingsShort.tsv";
            namesShort = @"C:\Users\uidj1061\Desktop\New folder\shorts\namesShort.tsv";

            moviesFullDirty = @"C:\Users\uidj1061\Desktop\New folder\moviesFull.tsv";

            moviesFullCleaned = @"C:\Users\uidj1061\Desktop\dsa\big_dataset\movies.csv";
            usersOutput = @"C:\Users\uidj1061\Desktop\dsa\big_dataset\users.csv";
            usersRatingsOutput = @"C:\Users\uidj1061\Desktop\dsa\big_dataset\usersRatings.csv";

            userCounter = 30000;
        }

        private static void CheckOutputFiles(string movies, string users, string usersRating)
        {
            //Dictionary<string, MovieResult> moviesShort = Parsers.DeserializeFile<MovieResult>(movies, ",", Constants.ClassTypes.MoviesResult);


            //moviesShort.Clear();

            //Dictionary<string, User> usersShort = Parsers.DeserializeFile<User>(users, ",", Constants.ClassTypes.Users);

            //usersShort.Clear();

            Dictionary<string, List<UserRating>> userRatingsShort = Parsers.DeserializeFileSample(usersRating, ",", Constants.ClassTypes.UsersRating);
            HashSet<string> distinctUsers = new HashSet<string>();
            HashSet<string> distinctMovies = new HashSet<string>();

            foreach (KeyValuePair<string, List<UserRating>> usrRating in userRatingsShort)
            {
                if (!distinctUsers.Contains(usrRating.Key))
                {
                    distinctUsers.Add(usrRating.Key);
                }

                foreach (UserRating usR in usrRating.Value)
                {
                    if (!distinctMovies.Contains(usR.movieId))
                    {
                        distinctMovies.Add(usR.movieId);
                    }
                }
            }

            userRatingsShort.Clear();
        }
    }
}

