using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.API.Consigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(e => e.IdOrder);


            builder.Property(e => e.CiClient)
                .IsRequired();

            builder.Property(e => e.IdProduct)
                .IsRequired();

            builder.Property(e => e.CantProduct)
                .IsRequired();

            builder.Property(e => e.DeliveryPrice)
                .IsRequired();

            builder.Property(e => e.PriceOrder)
                .IsRequired();

            builder.Property(e => e.AddressOrder)
                .IsRequired();

            builder.Property(e => e.StatusOrder)
                .IsRequired();

            builder.HasOne(e => e.Client)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.CiClient)
                .IsRequired(false);


            builder.HasMany(e => e.Products)
                   .WithMany(e => e.Orders);



        }
    }
}
