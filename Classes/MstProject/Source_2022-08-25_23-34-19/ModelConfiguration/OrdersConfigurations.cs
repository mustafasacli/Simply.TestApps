using System;
using System.Data.Entity.ModelConfiguration;

namespace Mst.Project.EntityConfiguration
{
    public class OrdersConfigurations : EntityTypeConfiguration<Orders>
    {
        public OrdersConfigurations()
        {
            this.HasKey(p => p.OrderNumber)

            this.Property(e => e.OrderNumber)
            .HasColumnName("orderNumber")
            .HasColumnType("int")
            .HasColumnOrder(1)
            .IsRequired();

            this.Property(e => e.OrderDate)
            .HasColumnName("orderDate")
            .HasColumnType("date")
            .HasColumnOrder(2)
            .IsRequired();

            this.Property(e => e.RequiredDate)
            .HasColumnName("requiredDate")
            .HasColumnType("date")
            .HasColumnOrder(3)
            .IsRequired();

            this.Property(e => e.ShippedDate)
            .HasColumnName("shippedDate")
            .HasColumnType("date")
            .HasColumnOrder(4)
            .IsOptional();

            this.Property(e => e.Status)
            .HasColumnName("status")
            .HasColumnType("varchar")
            .HasColumnOrder(5)
            .IsRequired()
            .HasMaxLength(15);

            this.Property(e => e.Comments)
            .HasColumnName("comments")
            .HasColumnType("text")
            .HasColumnOrder(6)
            .IsOptional()
            .HasMaxLength(65535);

            this.Property(e => e.CustomerNumber)
            .HasColumnName("customerNumber")
            .HasColumnType("int")
            .HasColumnOrder(7)
            .IsRequired();
        }
    }
}