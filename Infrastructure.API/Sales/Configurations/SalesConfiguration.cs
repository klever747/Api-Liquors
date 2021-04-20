using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.API.Configurations
{
    public class SalesConfiguration : IEntityTypeConfiguration<Sales>
    {
        public void Configure(EntityTypeBuilder<Sales> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(e => e.IdSales);


            builder.Property(e => e.IdOrder)
                .IsRequired();

            builder.Property(e => e.CiClient)
                .IsRequired(); 

            builder.Property(e => e.PriceSale)
                .IsRequired();

            builder.Property(e => e.PriceDelivery)
                .IsRequired();

            builder.Property(e => e.PaymentMethod)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.IdPaymentSale)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(e => e.Client)
                   .WithMany(e => e.Sales)
                   .HasForeignKey(e => e.CiClient)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired(false);

            builder.HasOne(e => e.Order)
                   .WithMany(e => e.Sales)
                   .HasForeignKey(e => e.IdOrder)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired(false);


        }
    }
}
