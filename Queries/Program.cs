using System;
using System.Collections.Generic;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            #region LINQ Syntax
            ////Filtering
            //var filter =
            //    from c in context.Courses
            //    where c.AuthorId == 1
            //    select c;

            ////Ordering
            //var order =
            //    from f in filter
            //    orderby f.Level descending, f.Name
            //    select f;

            ////Projection
            //var projection =
            //    from o in order
            //    select new { o.Id, o.Name };

            ////GroupBy
            //var groupBy =
            //    from c in context.Courses
            //    group c by c.Level into g
            //    select g;

            //Console.WriteLine("Example of groupBy");
            //foreach (var group in groupBy)
            //{
            //    Console.WriteLine("Level: {0} No. of Courses: {1}", group.Key, group.Count());
            //    Console.WriteLine(group.Key);
            //    foreach (var course in group)
            //    {
            //        Console.WriteLine("\t{0}", course.Name);
            //    }
            //    Console.WriteLine();
            //}

            ////Inner Join
            //var iJoin =
            //    from c in context.Courses
            //    join a in context.Authors on c.AuthorId equals a.Id
            //    select new { CourseName = c.Name, AuthorName = a.Name };

            ////Group Join
            //var gJoin =
            //    from a in context.Authors
            //    join c in context.Courses on a.Id equals c.AuthorId into g
            //    select new { AuthorName = a.Name, Courses = g.Count() };

            //Console.WriteLine("Example of Group Join");
            //foreach (var x in gJoin)
            //{
            //    Console.WriteLine("Level: {0} No. of Courses: {1}", x.AuthorName, x.Courses);
            //}
            //Console.WriteLine();

            ////Cross Join
            //var cJoin =
            //    from a in context.Authors
            //    from c in context.Courses
            //    select new { AuthorName = a.Name, CourseName = c.Name };

            //Console.WriteLine("Example of Cross Join");
            //foreach (var y in cJoin)
            //{
            //    Console.WriteLine("Author: {0} - Course: {1}", y.AuthorName, y.CourseName);
            //}
            //Console.WriteLine();
            #endregion


            #region ExtensionMethod

            ////Filtering
            //var filterEM = context.Courses
            //    .Where(c => c.Level == 1);

            ////Ordering
            //var orderEM = filterEM
            //    .OrderBy(c => c.Name)
            //    .ThenBy(c => c.Level);

            ////Projection
            //var projectEM = orderEM
            //    .Select(c => new { CourseName = c.Name, AuthorName = c.Author.Name });

            ////Distinct
            //var distinctEM = context.Courses
            //    .Where(c => c.Level == 1)
            //    .SelectMany(c => c.Tags)
            //    .Distinct();

            //Console.WriteLine("Example of SelectMany and Distinct");
            //foreach (var tag in distinctEM)
            //{
            //    Console.WriteLine(tag.Name);
            //}
            //Console.WriteLine();

            ////GroupBy
            //var groupByEM = context.Courses
            //    .GroupBy(c => c.Level);

            //Console.WriteLine("Example of groupBy");
            //foreach (var group in groupByEM)
            //{
            //    Console.WriteLine("Level: {0} No. of Courses: {1}", group.Key, group.Count());
            //    Console.WriteLine(group.Key);
            //    foreach (var course in group)
            //    {
            //        Console.WriteLine("\t{0}", course.Name);
            //    }
            //    Console.WriteLine();
            //}

            ////InnerJoin
            //var iJoinEM = context.Courses
            //    .Join(context.Authors,
            //    c => c.AuthorId,
            //    a => a.Id,
            //    (course, author) => new
            //    {
            //        CourseName = course.Name,
            //        AuthorName = author.Name
            //    });

            ////GroupJoin
            //var gJoinEM = context.Authors
            //    .GroupJoin(context.Courses, 
            //    a => a.Id, 
            //    c => c.AuthorId, 
            //    (author, courses) => new 
            //    {
            //        AuthorName = author.Name,
            //        Courses = courses.Count()
            //    });

            ////CrossJoin
            //var cJoinEM = context.Authors
            //    .SelectMany(a => context.Courses, 
            //    (author, course) => new
            //    {
            //        AuthorName = author.Name,
            //        CourseName = course.Name
            //    });

            ////Partitioning
            //var partitionEM = context.Courses
            //    .Skip(10)
            //    .Take(10);


            ////First, Last, Single Operations
            //var first = context.Courses
            //    .FirstOrDefault(c => c.FullPrice > 100);

            //var last = context.Courses
            //    .LastOrDefault(c => c.FullPrice > 100);

            //var single = context.Courses
            //    .SingleOrDefault(c => c.Id == 1);


            ////Quantifying
            //var allAbove10Dollars = context.Courses
            //    .All(c => c.FullPrice > 10);

            //var anyAbove10Dollars = context.Courses
            //    .Any(c => c.FullPrice > 10);


            ////Aggregating
            //int count = context.Courses
            //    .Count();

            //var max = context.Courses
            //    .Max(c => c.FullPrice);

            //var min = context.Courses
            //    .Min(c => c.FullPrice);

            #endregion

            
            #region DeferredExecution

            var courses = context.Courses;
            var filteredCourses = courses.Where(c => c.Level == 1);
            var sortedCourses = filteredCourses.OrderBy(c => c.Name);

            foreach (var c in courses)
            {
                Console.WriteLine(c.Name);
            }

            #endregion

        }
    }
}
