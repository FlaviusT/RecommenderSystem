using RecommenderSystem.InputGenerator.Models;
using System.Collections.Generic;
using System.IO;
using UnidecodeSharpFork;

namespace RecommenderSystem.InputGenerator
{
    public class Cleaner
    {
        public static void CleanMoviesResultsFile(string moviesResultsFile, string outputFile)
        {
            Dictionary<string, MovieResult> moviesResults =
              Parser.DeserializeFile<MovieResult>(moviesResultsFile, "\t", Constants.ClassTypes.MovieResult);

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
