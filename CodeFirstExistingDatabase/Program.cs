using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExistingDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            #region ExplicitLoading
            //var author = context.Authors.Single(a => a.Id == 1);

            ////MSDN Way
            //context.Entry(author).Collection(a => a.Courses).Query().Where(c => c.FullPrice == 0).Load();

            ////Mosh Way
            //context.Courses.Where(c => c.Author_Id == author.Id && c.FullPrice == 0).Load();

            //foreach (var course in author.Courses)
            //{
            //    Console.WriteLine("{0} by {1}", course.Name);
            //}
            #endregion

            #region AddData

            //var course = new Course()
            //{
            //    Name = "New Course",
            //    Description = "New Description",
            //    FullPrice = 19.95f,
            //    Level = 1,
            //    Author = context.Authors.Find(1)
            //};

            //context.Courses.Add(course);
            //context.SaveChanges();

            #endregion

            #region UpdateData

            //var course = context.Courses.Find(4);
            //course.Name = "New Name";
            //course.Author_Id = 2;

            //context.SaveChanges();

            #endregion

            #region RemoveData

            //var course = context.Courses.Find(3);
            //context.Courses.Remove(course);

            //context.SaveChanges();

            #endregion

        }
    }
}
