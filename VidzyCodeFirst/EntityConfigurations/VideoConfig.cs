using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidzyCodeFirst.EntityConfigurations
{
    public class VideoConfig : EntityTypeConfiguration<Video>
    {
        public VideoConfig()
        {
            Property(v => v.Name)
                .HasMaxLength(255)
                .IsRequired();

            HasRequired(v => v.Genre)
                .WithMany(g => g.Videos)
                .HasForeignKey(v => v.GenreId);

            Property(v => v.Classification)
                .HasColumnType("tinyint");

            HasMany(v => v.Tags)
                .WithMany(t => t.Videos)
                .Map(v => 
                {
                    v.ToTable("VideoTags");
                    v.MapLeftKey("VideoId");
                    v.MapRightKey("TagId");
                });
        }
    }
}
