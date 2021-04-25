using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.API.Configurations
{
    class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
        {
            builder.ToTable("Segurity");

            builder.HasKey(e => e.Id);


            builder.Property(e => e.Id)
                .HasColumnName("IdSegurity");

            builder.Property(e => e.Users)
                .HasColumnName("Users")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.UserName)
                .HasColumnName("NameUser")
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Passwordu)
                .HasColumnName("Passwordu")
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Roleu)
                .HasColumnName("Roleu")
                .IsRequired()
                .HasMaxLength(15)
                .HasConversion(
                  x => x.ToString(),
                  x => (RoleType)Enum.Parse(typeof(RoleType), x)
                );
        }
    }
}
