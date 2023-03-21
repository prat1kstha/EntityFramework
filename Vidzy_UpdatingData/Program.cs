using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Vidzy
{
    class Program
    {
        public static void AddVideo(string videoName, string genre, DateTime releaseDate, Classification classification)
        {
            using (var context = new VidzyContext())
            {
                var genreFromDb = context.Genres
                    .SingleOrDefault(g => g.Name.ToLower() == genre.ToLower());

                var video = new Video()
                {
                    Name = videoName,
                    Genre = genreFromDb,
                    ReleaseDate = releaseDate,
                    Classification = classification
                };
                context.Videos.Add(video);
                context.SaveChanges();
            }
        }

        public static void AddTag(string tagName)
        {
            using (var context = new VidzyContext())
            {
                if (context.Tags.FirstOrDefault(t => t.Name == tagName) is null)
                {
                    context.Tags.Add(new Tag() { Name = tagName });
                    context.SaveChanges();
                }
            }
        }

        public static void AddVideoTag(string videoName, params string[] tagNames)
        {
            using (var context = new VidzyContext())
            {
                var tags = context.Tags.Where(t => tagNames.Contains(t.Name)).ToList();

                foreach (var tag in tagNames)
                {
                    if (!tags.Any(t => t.Name.Equals(tag, StringComparison.CurrentCultureIgnoreCase))) 
                    {
                        tags.Add(new Tag { Name = tag });
                    }
                }

                var video = context.Videos.SingleOrDefault(v => v.Name.ToLower() == videoName.ToLower());
                tags.ForEach(t => video.AddTag(t));

                context.SaveChanges();
            }
        }

        public static void RemoveVideoTag(string videoName, params string[] tagNames)
        {
            using (var context = new VidzyContext())
            {
                var video = context.Videos.SingleOrDefault(v => v.Name.ToLower() == videoName.ToLower());

                foreach (var tagName in tagNames)
                {
                    var tag = context.Tags.SingleOrDefault(t => t.Name.Equals(tagName, StringComparison.CurrentCultureIgnoreCase));

                    if (tag != null)
                        context.Tags.Remove(tag);
                }

                context.SaveChanges();
            }
        }

        public static void RemoveVideo(string videoName)
        {
            using (var context = new VidzyContext())
            {
                var video = context.Videos.FirstOrDefault(v => v.Name.ToLower() == videoName.ToLower());
                context.Videos.Remove(video);
                context.SaveChanges();
            }
        }

        public static void RemoveGenre(string genreName)
        {
            using (var context = new VidzyContext())
            {
                var genre = context.Genres.Include(g => g.Videos).SingleOrDefault(g => g.Name.ToLower() == genreName.ToLower());
                
                context.Videos.RemoveRange(genre.Videos);
                context.SaveChanges();
            }
        }

        static void Main(string[] args)
        {
            //AddVideo(videoName: "Terminator 1",genre: "Action", releaseDate: DateTime.Parse("1984-10-26"), classification: Classification.Silver);

            //AddTag("Classics");
            //AddTag("Drama");

            //AddVideoTag("The Godfather", new string[] { "Classics", "Drama", "Comedy" });

            //RemoveVideoTag("The Godfather", new string[] { "Comedy" });

            //RemoveVideo("The Godfather");

            //RemoveGenre("Action");
        }
    }
}
