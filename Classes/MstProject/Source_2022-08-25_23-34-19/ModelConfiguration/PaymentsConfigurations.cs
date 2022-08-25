using System;
using System.Data.Entity.ModelConfiguration;

namespace Mst.Project.EntityConfiguration
{
    public class PaymentsConfigurations : EntityTypeConfiguration<Payments>
    {
        public PaymentsConfigurations()
        {
            this.HasKey(p => new { p.CustomerNumber, p.CheckNumber })

            this.Property(e => e.CustomerNumber)
            .HasColumnName("customerNumber")
            .HasColumnType("int")
            .HasColumnOrder(1)
            .IsRequired();

            this.Property(e => e.CheckNumber)
            .HasColumnName("checkNumber")
            .HasColumnType("varchar")
            .HasColumnOrder(2)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(e => e.PaymentDate)
            .HasColumnName("paymentDate")
            .HasColumnType("date")
            .HasColumnOrder(3)
            .IsRequired();

            this.Property(e => e.Amount)
            .HasColumnName("amount")
            .HasColumnType("decimal")
            .HasColumnOrder(4)
            .IsRequired();
        }
    }
}