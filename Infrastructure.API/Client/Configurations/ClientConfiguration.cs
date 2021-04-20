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
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");

            builder.HasKey(e => e.CiClient);


            builder.Property(e => e.CiUser)
                .IsRequired();

            builder.Property(e => e.PictureClient)
                .IsRequired()
                .HasColumnType("image");

            builder.Property(e => e.DisplayNameClient)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.EmailClient)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.PasswordClient)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.PhoneClient)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.AddessClient)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.DateBirthClient)
                .IsRequired()
                .HasColumnType("date")
                .HasMaxLength(10);

            builder.Property(e => e.Status)
                .IsRequired();

            builder.HasOne(e => e.User)
                .WithMany(e => e.Clients)
                .HasForeignKey(e => e.CiUser)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);


        }
    }
}
