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
    public class ProveedorConfiguration
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("Proveedores");

            builder.HasKey(e => e.ProveedorId);

            builder.Property(e => e.NameProveedor)
                .IsRequired()
                .HasMaxLength(255); 

            builder.Property(e => e.ContactProveedor)
                .IsRequired()
                .HasMaxLength(255); 

            builder.Property(e => e.PhoneProveedor)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.AddressProveedor)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.Status)
                .IsRequired();

            builder.HasMany(e => e.Products)
                  .WithMany(e => e.Proveedores);
        }
    }
}
