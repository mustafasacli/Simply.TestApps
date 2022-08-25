using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mst.Project.EntityConfiguration
{
    public class CustomersConfigurations : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasKey(e => e.CustomerNumber)

            builder.Property(e => e.CustomerNumber)
                .HasColumnName("customerNumber")
                .HasColumnType("int")
                .HasColumnOrder(1)
                .IsRequired();

            builder.Property(e => e.CustomerName)
                .HasColumnName("customerName")
                .HasColumnType("varchar")
                .HasColumnOrder(2)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.ContactLastName)
                .HasColumnName("contactLastName")
                .HasColumnType("varchar")
                .HasColumnOrder(3)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.ContactFirstName)
                .HasColumnName("contactFirstName")
                .HasColumnType("varchar")
                .HasColumnOrder(4)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Phone)
                .HasColumnName("phone")
                .HasColumnType("varchar")
                .HasColumnOrder(5)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.AddressLine1)
                .HasColumnName("addressLine1")
                .HasColumnType("varchar")
                .HasColumnOrder(6)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.AddressLine2)
                .HasColumnName("addressLine2")
                .HasColumnType("varchar")
                .HasColumnOrder(7)
                .IsOptional()
                .HasMaxLength(50);

            builder.Property(e => e.City)
                .HasColumnName("city")
                .HasColumnType("varchar")
                .HasColumnOrder(8)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.State)
                .HasColumnName("state")
                .HasColumnType("varchar")
                .HasColumnOrder(9)
                .IsOptional()
                .HasMaxLength(50);

            builder.Property(e => e.PostalCode)
                .HasColumnName("postalCode")
                .HasColumnType("varchar")
                .HasColumnOrder(10)
                .IsOptional()
                .HasMaxLength(15);

            builder.Property(e => e.Country)
                .HasColumnName("country")
                .HasColumnType("varchar")
                .HasColumnOrder(11)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.SalesRepEmployeeNumber)
                .HasColumnName("salesRepEmployeeNumber")
                .HasColumnType("int")
                .HasColumnOrder(12)
                .IsOptional();

            builder.Property(e => e.CreditLimit)
                .HasColumnName("creditLimit")
                .HasColumnType("decimal")
                .HasColumnOrder(13)
                .IsOptional();
        }
    }
}