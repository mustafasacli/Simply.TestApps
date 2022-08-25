using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mst.Project.EntityConfiguration
{
    public class OrderdetailsConfigurations : IEntityTypeConfiguration<Orderdetails>
    {
        public void Configure(EntityTypeBuilder<Orderdetails> builder)
        {
            this.HasKey(e => new { e.OrderNumber, e.ProductCode })

            builder.Property(e => e.OrderNumber)
                .HasColumnName("orderNumber")
                .HasColumnType("int")
                .HasColumnOrder(1)
                .IsRequired();

            builder.Property(e => e.ProductCode)
                .HasColumnName("productCode")
                .HasColumnType("varchar")
                .HasColumnOrder(2)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(e => e.QuantityOrdered)
                .HasColumnName("quantityOrdered")
                .HasColumnType("int")
                .HasColumnOrder(3)
                .IsRequired();

            builder.Property(e => e.PriceEach)
                .HasColumnName("priceEach")
                .HasColumnType("decimal")
                .HasColumnOrder(4)
                .IsRequired();

            builder.Property(e => e.OrderLineNumber)
                .HasColumnName("orderLineNumber")
                .HasColumnType("smallint")
                .HasColumnOrder(5)
                .IsRequired();
        }
    }
}