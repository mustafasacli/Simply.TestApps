using System.Data.Entity.ModelConfiguration;

namespace Mst.Project.EntityConfiguration
{
    public class ProductlinesConfigurations : EntityTypeConfiguration<Productlines>
    {
        public ProductlinesConfigurations()
        {
            this.HasKey(p => p.ProductLine)

            this.Property(e => e.ProductLine)
            .HasColumnName("productLine")
            .HasColumnType("varchar")
            .HasColumnOrder(1)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(e => e.TextDescription)
            .HasColumnName("textDescription")
            .HasColumnType("varchar")
            .HasColumnOrder(2)
            .IsOptional()
            .HasMaxLength(4000);

            this.Property(e => e.HtmlDescription)
            .HasColumnName("htmlDescription")
            .HasColumnType("mediumtext")
            .HasColumnOrder(3)
            .IsOptional()
            .HasMaxLength(16777215);

            this.Property(e => e.Image)
            .HasColumnName("image")
            .HasColumnType("mediumblob")
            .HasColumnOrder(4)
            .IsOptional();
        }
    }
}