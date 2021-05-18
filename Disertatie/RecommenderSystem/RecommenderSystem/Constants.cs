using System.Collections.Generic;

namespace RecommenderSystem
{
    public static class Constants
    {
        #region DataCleanere constants
        public static readonly string[] Genres = new string[] {
            "Drama", "Documentary", "Adventure", "Animation", "Family",
            "Crime", "Mystery", "Action", "Sci-Fi", "War", "Comedy", "Romance",
            "Horror", "Thriller", "Sport", "Fantasy", "Biography" ,"Music",
            "Western", "History", "Musical"};

        public static readonly string MOVIE_GENRE_DRAMA = "Drama";
        public static readonly string MOVIE_GENRE_DOCUMENTARY = "Documentary";
        public static readonly string MOVIE_GENRE_ADVENTURE = "Adventure";
        public static readonly string MOVIE_GENRE_ANIMATION = "Animation";
        public static readonly string MOVIE_GENRE_FAMILY = "Family";
        public static readonly string MOVIE_GENRE_CRIME = "Crime";
        public static readonly string MOVIE_GENRE_MYSTERY = "Mystery";
        public static readonly string MOVIE_GENRE_ACTION = "Action";
        public static readonly string MOVIE_GENRE_SCIFI = "Sci-Fi";
        public static readonly string MOVIE_GENRE_WAR = "War";
        public static readonly string MOVIE_GENRE_COMEDY = "Comedy";
        public static readonly string MOVIE_GENRE_ROMANCE = "Romance";
        public static readonly string MOVIE_GENRE_HORROR = "Horror";
        public static readonly string MOVIE_GENRE_THRILLER = "Thriller";
        public static readonly string MOVIE_GENRE_SPORT = "Sport";
        public static readonly string MOVIE_GENRE_FANTASY = "Fantasy";
        public static readonly string MOVIE_GENRE_BIOGRAPHY = "Biography";
        public static readonly string MOVIE_GENRE_MUSIC = "Music";
        public static readonly string MOVIE_GENRE_WESTERN = "Western";
        public static readonly string MOVIE_GENRE_HISTORY = "History";
        public static readonly string MOVIE_GENRE_MUSICAL = "Musical";

        public static readonly string OCCUPATION_ADMINISTRATOR = "administrator";
        public static readonly string OCCUPATION_ARTIST = "artist";
        public static readonly string OCCUPATION_DOCTOR = "doctor";
        public static readonly string OCCUPATION_EDUCATOR = "educator";
        public static readonly string OCCUPATION_ENGINEER = "engineer";
        public static readonly string OCCUPATION_ENTERNTAINMENT = "entertainment";
        public static readonly string OCCUPATION_HEALTHCARE = "healthcare";
        public static readonly string OCCUPATION_LAWYER = "lawyer";
        public static readonly string OCCUPATION_HOMEMAKER = "homemaker";
        public static readonly string OCCUPATION_LIBRARIAN = "librarian";
        public static readonly string OCCUPATION_MARKETING = "marketing";
        public static readonly string OCCUPATION_NONE = "none";
        public static readonly string OCCUPATION_PROGRAMMER = "programmer";
        public static readonly string OCCUPATION_RETIRED = "retired";
        public static readonly string OCCUPATION_SALESMAN = "salesman";
        public static readonly string OCCUPATION_SCIENTIST = "scientist";
        public static readonly string OCCUPATION_STUDENT = "student";
        public static readonly string OCCUPATION_TECHINCIAN = "technician";
        public static readonly string OCCUPATION_WRITER = "writer";

        public enum ClassTypes
        {
            Movie = 1,
            MovieShort,
            MovieResult,
            Rating,
            Director,
            DirectorShort,
            Cast,
            Name,
            NameShort,
            User,
            UserRating
        }
        #endregion

        #region File names constants
        public static readonly string CONFIGURATION_FILE_NAME = "config.cfg";
        public static readonly string OUTPUT_DIRECTORY_NAME = "output";
        public static readonly string TITLES_CLEANED_FILE_NAME = "titlesCleaned.tsv";
        public static readonly string DIRECTORS_CLEANED_FILE_NAME = "directorsCleaned.tsv";
        public static readonly string CAST_CLEANED_FILE_NAME = "castCleaned.tsv";
        public static readonly string NAMES_CLEANED_FILE_NAME = "namesCleaned.tsv";
        public static readonly string RATINGS_CLEANED_FILE_NAME = "ratingsCleaned.tsv";
        public static readonly string MOVIES_NOT_CLEARED = "moviesDirty.tsv";
        public static readonly string MOVIES_OUTPUT = "movies.csv";
        public static readonly string USERS_OUTPUT = "users.csv";
        public static readonly string USER_RATINGS_OUTPUT = "userRatings.csv";
        #endregion
    }
}
