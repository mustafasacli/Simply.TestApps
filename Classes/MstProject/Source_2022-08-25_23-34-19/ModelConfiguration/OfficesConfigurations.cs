using System.Data.Entity.ModelConfiguration;

namespace Mst.Project.EntityConfiguration
{
    public class OfficesConfigurations : EntityTypeConfiguration<Offices>
    {
        public OfficesConfigurations()
        {
            this.HasKey(p => p.OfficeCode)

            this.Property(e => e.OfficeCode)
            .HasColumnName("officeCode")
            .HasColumnType("varchar")
            .HasColumnOrder(1)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(e => e.City)
            .HasColumnName("city")
            .HasColumnType("varchar")
            .HasColumnOrder(2)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(e => e.Phone)
            .HasColumnName("phone")
            .HasColumnType("varchar")
            .HasColumnOrder(3)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(e => e.AddressLine1)
            .HasColumnName("addressLine1")
            .HasColumnType("varchar")
            .HasColumnOrder(4)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(e => e.AddressLine2)
            .HasColumnName("addressLine2")
            .HasColumnType("varchar")
            .HasColumnOrder(5)
            .IsOptional()
            .HasMaxLength(50);

            this.Property(e => e.State)
            .HasColumnName("state")
            .HasColumnType("varchar")
            .HasColumnOrder(6)
            .IsOptional()
            .HasMaxLength(50);

            this.Property(e => e.Country)
            .HasColumnName("country")
            .HasColumnType("varchar")
            .HasColumnOrder(7)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(e => e.PostalCode)
            .HasColumnName("postalCode")
            .HasColumnType("varchar")
            .HasColumnOrder(8)
            .IsRequired()
            .HasMaxLength(15);

            this.Property(e => e.Territory)
            .HasColumnName("territory")
            .HasColumnType("varchar")
            .HasColumnOrder(9)
            .IsRequired()
            .HasMaxLength(10);
        }
    }
}