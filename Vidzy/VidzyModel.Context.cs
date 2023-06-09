﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vidzy
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
    
        public virtual int AddVideo(string name, Nullable<System.DateTime> releaseDate, string genre, Nullable<byte> classificationId)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var releaseDateParameter = releaseDate.HasValue ?
                new ObjectParameter("ReleaseDate", releaseDate) :
                new ObjectParameter("ReleaseDate", typeof(System.DateTime));
    
            var genreParameter = genre != null ?
                new ObjectParameter("Genre", genre) :
                new ObjectParameter("Genre", typeof(string));
    
            var classificationIdParameter = classificationId.HasValue ?
                new ObjectParameter("ClassificationId", classificationId) :
                new ObjectParameter("ClassificationId", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddVideo", nameParameter, releaseDateParameter, genreParameter, classificationIdParameter);
        }
    }
}
