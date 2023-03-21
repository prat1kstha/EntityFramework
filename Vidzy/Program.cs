using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new ApplicationDbContext();

            try
            {
                dbContext.AddVideo(name: "Video4", releaseDate: DateTime.Now, genre: "Thriller", classificationId: (byte)Classification.Gold);
                Console.WriteLine("Record added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
