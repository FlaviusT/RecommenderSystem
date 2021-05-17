using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommenderSystem
{
    public static class Constants
    {
        public static List<string> AcceptedYears = new List<string>() { /*"1998", "1999", "2000", "2001", "2002", "2003",
            "2004", "2005","2006", "2007", "2008", "2009", "2010", "2011", "2012", "2013", "2014",
            "2015",*/ "2016",  "2017", "2018", "2019", "2020" };

        public static string[] Genres = new string[] { "Drama", "Documentary", "Adventure"
            , "Animation", "Family", "Crime", "Mystery", "Action", "Sci-Fi",
            "War", "Comedy", "Romance", "Horror", "Thriller", "Sport",
            "Fantasy", "Biography" ,"Music", "Western", "History", "Musical"};

        public static string MOVIE_GENRE_DRAMA = "Drama";
        public static string MOVIE_GENRE_DOCUMENTARY = "Documentary";
        public static string MOVIE_GENRE_ADVENTURE = "Adventure";
        public static string MOVIE_GENRE_ANIMATION = "Animation";
        public static string MOVIE_GENRE_FAMILY = "Family";
        public static string MOVIE_GENRE_CRIME = "Crime";
        public static string MOVIE_GENRE_MYSTERY = "Mystery";
        public static string MOVIE_GENRE_ACTION = "Action";
        public static string MOVIE_GENRE_SCIFI = "Sci-Fi";
        public static string MOVIE_GENRE_WAR = "War";
        public static string MOVIE_GENRE_COMEDY = "Comedy";
        public static string MOVIE_GENRE_ROMANCE = "Romance";
        public static string MOVIE_GENRE_HORROR = "Horror";
        public static string MOVIE_GENRE_THRILLER = "Thriller";
        public static string MOVIE_GENRE_SPORT = "Sport";
        public static string MOVIE_GENRE_FANTASY = "Fantasy";
        public static string MOVIE_GENRE_BIOGRAPHY = "Biography";
        public static string MOVIE_GENRE_MUSIC = "Music";
        public static string MOVIE_GENRE_WESTERN = "Western";
        public static string MOVIE_GENRE_HISTORY = "History";
        public static string MOVIE_GENRE_MUSICAL = "Musical";

        public static readonly string OCCUPATION_ADMINISTRATOR = "administrator";
        public static string OCCUPATION_ARTIST = "artist";
        public static string OCCUPATION_DOCTOR = "doctor";
        public static string OCCUPATION_EDUCATOR = "educator";
        public static string OCCUPATION_ENGINEER = "engineer";
        public static string OCCUPATION_ENTERNTAINMENT = "entertainment";
        public static string OCCUPATION_HEALTHCARE = "healthcare";
        public static string OCCUPATION_LAWYER = "lawyer";
        public static string OCCUPATION_HOMEMAKER = "homemaker";
        public static string OCCUPATION_LIBRARIAN = "librarian";
        public static string OCCUPATION_MARKETING = "marketing";
        public static string OCCUPATION_NONE = "none";
        public static string OCCUPATION_PROGRAMMER = "programmer";
        public static string OCCUPATION_RETIRED = "retired";
        public static string OCCUPATION_SALESMAN = "salesman";
        public static string OCCUPATION_SCIENTIST = "scientist";
        public static string OCCUPATION_STUDENT = "student";
        public static string OCCUPATION_TECHINCIAN = "technician";
        public static string OCCUPATION_WRITER = "writer";

        public enum ClassTypes
        {
            Movies = 1,
            MoviesShort,
            MoviesResult,
            Ratings,
            Directors,
            DirectorsShort,
            Cast,
            CastShort,
            Names,
            NamesShort,
            Users,
            UsersRating
        }
    }
}
