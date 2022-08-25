using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mst.Project.EntityConfiguration
{
    public class OrdersConfigurations : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.HasKey(e => e.OrderNumber)

            builder.Property(e => e.OrderNumber)
                .HasColumnName("orderNumber")
                .HasColumnType("int")
                .HasColumnOrder(1)
                .IsRequired();

            builder.Property(e => e.OrderDate)
                .HasColumnName("orderDate")
                .HasColumnType("date")
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(e => e.RequiredDate)
                .HasColumnName("requiredDate")
                .HasColumnType("date")
                .HasColumnOrder(3)
                .IsRequired();

            builder.Property(e => e.ShippedDate)
                .HasColumnName("shippedDate")
                .HasColumnType("date")
                .HasColumnOrder(4)
                .IsOptional();

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("varchar")
                .HasColumnOrder(5)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(e => e.Comments)
                .HasColumnName("comments")
                .HasColumnType("text")
                .HasColumnOrder(6)
                .IsOptional()
                .HasMaxLength(65535);

            builder.Property(e => e.CustomerNumber)
                .HasColumnName("customerNumber")
                .HasColumnType("int")
                .HasColumnOrder(7)
                .IsRequired();
        }
    }
}