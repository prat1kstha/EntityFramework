using System.Collections.Generic;

namespace VidzyCodeFirst
{
    public class Tag
    {
        public Tag()
        {
            Videos = new HashSet<Video>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Video> Videos { get; set; }
    }
}