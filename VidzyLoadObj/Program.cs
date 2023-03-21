

using System;
using System.Data.Entity;
using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyContext();

            #region EagerLoading

            //var videos = context.Videos.Include(v => v.Genre);
            //Console.WriteLine("Using Eager Loading");
            //foreach (var video in videos)
            //{
            //    Console.WriteLine("{0} - {1}", video.Name, video.Genre.Name);
            //}
            //Console.WriteLine();

            #endregion


            #region LazyLoading

            //var videos2 = context.Videos.ToList();
            //Console.WriteLine("Using Lazy Loading");
            //foreach (var video in videos2)
            //{
            //    Console.WriteLine("{0} - {1}", video.Name, video.Genre.Name);
            //}
            //Console.WriteLine("");

            #endregion


            #region ExplicitLoading

            var videos3 = context.Videos.ToList();

            context.Genres.Load();

            Console.WriteLine("Using Explicit Loading");
            foreach (var video in videos3)
            {
                Console.WriteLine("{0} - {1}", video.Name, video.Genre.Name);
            }
            Console.WriteLine("");

            #endregion
        }
    }
}
