using System.Data.Entity.ModelConfiguration;

namespace Mst.Project.EntityConfiguration
{
    public class EmployeesConfigurations : EntityTypeConfiguration<Employees>
    {
        public EmployeesConfigurations()
        {
            this.HasKey(p => p.EmployeeNumber)

            this.Property(e => e.EmployeeNumber)
            .HasColumnName("employeeNumber")
            .HasColumnType("int")
            .HasColumnOrder(1)
            .IsRequired();

            this.Property(e => e.LastName)
            .HasColumnName("lastName")
            .HasColumnType("varchar")
            .HasColumnOrder(2)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(e => e.FirstName)
            .HasColumnName("firstName")
            .HasColumnType("varchar")
            .HasColumnOrder(3)
            .IsRequired()
            .HasMaxLength(50);

            this.Property(e => e.Extension)
            .HasColumnName("extension")
            .HasColumnType("varchar")
            .HasColumnOrder(4)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(e => e.Email)
            .HasColumnName("email")
            .HasColumnType("varchar")
            .HasColumnOrder(5)
            .IsRequired()
            .HasMaxLength(100);

            this.Property(e => e.OfficeCode)
            .HasColumnName("officeCode")
            .HasColumnType("varchar")
            .HasColumnOrder(6)
            .IsRequired()
            .HasMaxLength(10);

            this.Property(e => e.ReportsTo)
            .HasColumnName("reportsTo")
            .HasColumnType("int")
            .HasColumnOrder(7)
            .IsOptional();

            this.Property(e => e.JobTitle)
            .HasColumnName("jobTitle")
            .HasColumnType("varchar")
            .HasColumnOrder(8)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
}