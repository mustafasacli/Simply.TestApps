using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mst.Project.EntityConfiguration
{
    public class ProductsConfigurations : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(e => e.ProductCode)

            builder.Property(e => e.ProductCode)
                .HasColumnName("productCode")
                .HasColumnType("varchar")
                .HasColumnOrder(1)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(e => e.ProductName)
                .HasColumnName("productName")
                .HasColumnType("varchar")
                .HasColumnOrder(2)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(e => e.ProductLine)
                .HasColumnName("productLine")
                .HasColumnType("varchar")
                .HasColumnOrder(3)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.ProductScale)
                .HasColumnName("productScale")
                .HasColumnType("varchar")
                .HasColumnOrder(4)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.ProductVendor)
                .HasColumnName("productVendor")
                .HasColumnType("varchar")
                .HasColumnOrder(5)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.ProductDescription)
                .HasColumnName("productDescription")
                .HasColumnType("text")
                .HasColumnOrder(6)
                .IsRequired()
                .HasMaxLength(65535);

            builder.Property(e => e.QuantityInStock)
                .HasColumnName("quantityInStock")
                .HasColumnType("smallint")
                .HasColumnOrder(7)
                .IsRequired();

            builder.Property(e => e.BuyPrice)
                .HasColumnName("buyPrice")
                .HasColumnType("decimal")
                .HasColumnOrder(8)
                .IsRequired();

            builder.Property(e => e.Msrp)
                .HasColumnName("MSRP")
                .HasColumnType("decimal")
                .HasColumnOrder(9)
                .IsRequired();
        }
    }
}