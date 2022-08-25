using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mst.Project.EntityConfiguration
{
    public class EmployeesConfigurations : IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder.HasKey(e => e.EmployeeNumber)

            builder.Property(e => e.EmployeeNumber)
                .HasColumnName("employeeNumber")
                .HasColumnType("int")
                .HasColumnOrder(1)
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasColumnName("lastName")
                .HasColumnType("varchar")
                .HasColumnOrder(2)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.FirstName)
                .HasColumnName("firstName")
                .HasColumnType("varchar")
                .HasColumnOrder(3)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Extension)
                .HasColumnName("extension")
                .HasColumnType("varchar")
                .HasColumnOrder(4)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasColumnType("varchar")
                .HasColumnOrder(5)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.OfficeCode)
                .HasColumnName("officeCode")
                .HasColumnType("varchar")
                .HasColumnOrder(6)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.ReportsTo)
                .HasColumnName("reportsTo")
                .HasColumnType("int")
                .HasColumnOrder(7)
                .IsOptional();

            builder.Property(e => e.JobTitle)
                .HasColumnName("jobTitle")
                .HasColumnType("varchar")
                .HasColumnOrder(8)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}