using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidzyCodeFirst.EntityConfigurations
{
    public class GenreConfig : EntityTypeConfiguration<Genre>
    {
        public GenreConfig()
        {
            Property(g => g.Name)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
