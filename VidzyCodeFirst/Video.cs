﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidzyCodeFirst
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public Classification Classification { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
