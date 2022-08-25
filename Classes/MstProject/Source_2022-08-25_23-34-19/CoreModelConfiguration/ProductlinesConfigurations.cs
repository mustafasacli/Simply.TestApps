using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mst.Project.EntityConfiguration
{
    public class ProductlinesConfigurations : IEntityTypeConfiguration<Productlines>
    {
        public void Configure(EntityTypeBuilder<Productlines> builder)
        {
            builder.HasKey(e => e.ProductLine)

            builder.Property(e => e.ProductLine)
                .HasColumnName("productLine")
                .HasColumnType("varchar")
                .HasColumnOrder(1)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.TextDescription)
                .HasColumnName("textDescription")
                .HasColumnType("varchar")
                .HasColumnOrder(2)
                .IsOptional()
                .HasMaxLength(4000);

            builder.Property(e => e.HtmlDescription)
                .HasColumnName("htmlDescription")
                .HasColumnType("mediumtext")
                .HasColumnOrder(3)
                .IsOptional()
                .HasMaxLength(16777215);

            builder.Property(e => e.Image)
                .HasColumnName("image")
                .HasColumnType("mediumblob")
                .HasColumnOrder(4)
                .IsOptional();
        }
    }
}