using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.API.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(e => e.IdCategory);


            builder.Property(e => e.NameCategory)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.ImageCategory)
                .IsRequired()
                .HasColumnType("image");


        }
    }
}
