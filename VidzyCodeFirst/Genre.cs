using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidzyCodeFirst
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Video> Videos { get; set; }
        public Genre()
        {
            Videos = new HashSet<Video>();
        }
    }
}
