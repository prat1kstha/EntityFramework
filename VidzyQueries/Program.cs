using System;
using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            VidzyContext context = new VidzyContext();

            //Q1
            var q1 = context.Videos
                .Where(v => v.Genre.Name.ToLower() == "action")
                .OrderBy(v => v.Name);

            Console.WriteLine("Q1. Action movies sorted by name");
            foreach (var movie in q1)
            {
                Console.WriteLine(movie.Name);
            }
            Console.WriteLine();


            //Q2
            var q2 = context.Videos
                .Where(v => v.Genre.Name.ToLower() == "drama" && v.Classification == Classification.Gold)
                .OrderByDescending(v => v.ReleaseDate);

            Console.WriteLine("Q2. Gold drama movies sorted by release date (newest first)");
            foreach (var movie in q2)
            {
                Console.WriteLine(movie.Name);
            }
            Console.WriteLine();


            //Q3
            var q3 = context.Videos
                .Select(v => new { MovieName = v.Name, Genre = v.Genre.Name });

            Console.WriteLine("Q3. All movies with MovieName and Genre");
            foreach (var movie in q3)
            {
                Console.WriteLine(movie.MovieName + " - " + movie.Genre);
            }
            Console.WriteLine();


            //Q4
            var q4 = context.Videos
                .GroupBy(v => v.Classification)
                .Select(g => new 
                { 
                    Classification = g.Key.ToString(), 
                    Movie = g.OrderBy(v => v.Name)
                });

            Console.WriteLine("Q4. All movies grouped by their classification");
            foreach (var classification in q4)
            {
                Console.WriteLine("Classification: " + classification.Classification.ToString());
                foreach (var movie in classification.Movie)
                {
                    Console.WriteLine("\t" + movie.Name);
                }
            }
            Console.WriteLine();


            //Q5
            var q5 = context.Videos
                .GroupBy(v => v.Classification)
                .Select(v => new
                {
                    Name = v.Key.ToString(),
                    VideosCount = v.Count()
                })
                .OrderBy(v => v.Name);

            Console.WriteLine("Q5. List of classifications sorted alphabetically and count of videos in them");
            foreach (var classification in q5)
            {
                Console.WriteLine("{0} ({1})", classification.Name, classification.VideosCount);
            }
            Console.WriteLine();


            //Q6
            var q6 = context.Genres
                .GroupJoin(context.Videos,
                g => g.Id,
                v => v.GenreId,
                (genre, video) => new
                {
                    Genre = genre.Name,
                    MoviesCount = video.Count()
                })
                .OrderByDescending(g => g.MoviesCount);

            Console.WriteLine("Q6. List of genres and count of videos in them, sorted by the number of videos descending");
            foreach (var genre in q6)
            {
                Console.WriteLine("{0} ({1})", genre.Genre, genre.MoviesCount);
            }
            Console.WriteLine();
        }
    }
}
