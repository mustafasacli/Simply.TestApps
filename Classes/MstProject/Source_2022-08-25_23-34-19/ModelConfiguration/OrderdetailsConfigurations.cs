using System.Data.Entity.ModelConfiguration;

namespace Mst.Project.EntityConfiguration
{
    public class OrderdetailsConfigurations : EntityTypeConfiguration<Orderdetails>
    {
        public OrderdetailsConfigurations()
        {
            this.HasKey(p => new { p.OrderNumber, p.ProductCode })

            this.Property(e => e.OrderNumber)
            .HasColumnName("orderNumber")
            .HasColumnType("int")
            .HasColumnOrder(1)
            .IsRequired();

            this.Property(e => e.ProductCode)
            .HasColumnName("productCode")
            .HasColumnType("varchar")
            .HasColumnOrder(2)
            .IsRequired()
            .HasMaxLength(15);

            this.Property(e => e.QuantityOrdered)
            .HasColumnName("quantityOrdered")
            .HasColumnType("int")
            .HasColumnOrder(3)
            .IsRequired();

            this.Property(e => e.PriceEach)
            .HasColumnName("priceEach")
            .HasColumnType("decimal")
            .HasColumnOrder(4)
            .IsRequired();

            this.Property(e => e.OrderLineNumber)
            .HasColumnName("orderLineNumber")
            .HasColumnType("smallint")
            .HasColumnOrder(5)
            .IsRequired();
        }
    }
}