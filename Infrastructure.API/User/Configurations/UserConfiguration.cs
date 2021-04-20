using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.API.Configurations
{
    public class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(e => e.CiUser);


            builder.Property(e => e.PictureUser)
                .IsRequired()
                .HasColumnType("image");

            builder.Property(e => e.DisplaynameUser)
                .IsRequired()
                .HasMaxLength(38);

            builder.Property(e => e.EmailUser)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.PasswordUser)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.PhoneUser)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.AddessUser)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.DateBirthUser)
                .HasColumnType("date")
                .HasMaxLength(10);

            builder.Property(e => e.Status)
                .IsRequired();
     

        }
    }
}
