using System.Data.Entity.ModelConfiguration;

namespace Mst.Project.EntityConfiguration
{
    public class ProductsConfigurations : EntityTypeConfiguration<Products>
    {
        public ProductsConfigurations()
        {
            this.HasKey(p => p.ProductCode)

            this.Property(e => e.ProductCode)
            .HasColumnName("productCode")
            .HasColumnType("varchar")
            .HasColumnOrder(1)
            .IsRequired()
            .HasMaxLength(15);

            this.Property(e => e.ProductName)
            .HasColumnName("productName")
            .HasColumnType("varchar")
            .HasColumnOrder(2)
            .IsRequired()
            .HasMaxLength(70);

            this.Property(e => e.ProductLine)
            .HasColumnName("productLine")
            .HasColumnType("varchar")
            .HasColumnOrder(3)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(e => e.ProductScale)
            .HasColumnName("productScale")
            .HasColumnType("varchar")
            .HasColumnOrder(4)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(e => e.ProductVendor)
            .HasColumnName("productVendor")
            .HasColumnType("varchar")
            .HasColumnOrder(5)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(e => e.ProductDescription)
            .HasColumnName("productDescription")
            .HasColumnType("text")
            .HasColumnOrder(6)
            .IsRequired()
            .HasMaxLength(65535);

            this.Property(e => e.QuantityInStock)
            .HasColumnName("quantityInStock")
            .HasColumnType("smallint")
            .HasColumnOrder(7)
            .IsRequired();

            this.Property(e => e.BuyPrice)
            .HasColumnName("buyPrice")
            .HasColumnType("decimal")
            .HasColumnOrder(8)
            .IsRequired();

            this.Property(e => e.Msrp)
            .HasColumnName("MSRP")
            .HasColumnType("decimal")
            .HasColumnOrder(9)
            .IsRequired();
        }
    }
}