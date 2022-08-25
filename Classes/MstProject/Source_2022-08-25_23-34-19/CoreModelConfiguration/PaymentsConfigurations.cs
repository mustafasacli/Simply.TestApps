using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mst.Project.EntityConfiguration
{
    public class PaymentsConfigurations : IEntityTypeConfiguration<Payments>
    {
        public void Configure(EntityTypeBuilder<Payments> builder)
        {
            this.HasKey(e => new { e.CustomerNumber, e.CheckNumber })

            builder.Property(e => e.CustomerNumber)
                .HasColumnName("customerNumber")
                .HasColumnType("int")
                .HasColumnOrder(1)
                .IsRequired();

            builder.Property(e => e.CheckNumber)
                .HasColumnName("checkNumber")
                .HasColumnType("varchar")
                .HasColumnOrder(2)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.PaymentDate)
                .HasColumnName("paymentDate")
                .HasColumnType("date")
                .HasColumnOrder(3)
                .IsRequired();

            builder.Property(e => e.Amount)
                .HasColumnName("amount")
                .HasColumnType("decimal")
                .HasColumnOrder(4)
                .IsRequired();
        }
    }
}