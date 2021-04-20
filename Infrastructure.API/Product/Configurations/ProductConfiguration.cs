using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.API.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(e => e.ProductId);

            builder.Property(e => e.ProveedorId)
                .IsRequired();

            builder.Property(e => e.CiUser)
                .IsRequired();

            builder.Property(e => e.StateProduct)
                .IsRequired();

            builder.Property(e => e.IdCategory)
                .IsRequired();

            builder.Property(e => e.NameProduct)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.ImageProduct)
                .IsRequired()
                .HasColumnType("image");

            builder.Property(e => e.PriceProduct)
                .IsRequired();

            builder.Property(e => e.StockProduct)
                .IsRequired();

            builder.Property(e => e.DetailProduct)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.SalesProduct)
                .IsRequired(true);

            builder.HasOne(e => e.User)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.CiUser)
                .IsRequired(false);

            builder.HasMany(e => e.Proveedores)
                .WithMany(e => e.Products);

            builder.HasOne(e => e.Category)
                .WithMany(e => e.Products);


        }
    }
}
