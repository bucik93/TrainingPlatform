using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlatform.DataAccess.Entities;

namespace TrainingPlatform.DataAccess.Mappings
{
    public class ExerciseMapping : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

            builder.Property(b => b.Link)
              .IsRequired()
              .HasColumnType("varchar(150)");

        
            builder.Property(b => b.Series)
                    .IsRequired();

            builder.Property(b => b.Repeat)
                    .IsRequired();    

            builder.Property(b => b.Weight)
                    .IsRequired();

           

            builder.ToTable("Exercise");
        }
    }
}
