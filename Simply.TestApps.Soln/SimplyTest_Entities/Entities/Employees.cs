using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimplyTest_Entities
{
    [Table("employees", Schema = "classicmodels")]
    public class Employee
    {
        /// <summary>
        /// Gets or Sets the employeeNumber
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "employeeNumber alanýna veri girilmelidir.")]
        [Column("employeeNumber", Order = 1, TypeName = "int")]
        public int employeeNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the lastName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "lastName alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "lastName alaný 50 karakterden uzun olamaz.")]
        [Column("lastName", Order = 2, TypeName = "varchar")]
        public string lastName
        { get; set; }

        /// <summary>
        /// Gets or Sets the firstName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "firstName alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "firstName alaný 50 karakterden uzun olamaz.")]
        [Column("firstName", Order = 3, TypeName = "varchar")]
        public string firstName
        { get; set; }

        /// <summary>
        /// Gets or Sets the Extension
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Extension alanýna veri girilmelidir.")]
        [StringLength(10, ErrorMessage = "Extension alaný 10 karakterden uzun olamaz.")]
        [Column("extension", Order = 4, TypeName = "varchar")]
        public string Extension
        { get; set; }

        /// <summary>
        /// Gets or Sets the Email
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email alanýna veri girilmelidir.")]
        [StringLength(100, ErrorMessage = "Email alaný 100 karakterden uzun olamaz.")]
        [Column("email", Order = 5, TypeName = "varchar")]
        public string Email
        { get; set; }

        /// <summary>
        /// Gets or Sets the officeCode
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "officeCode alanýna veri girilmelidir.")]
        [StringLength(10, ErrorMessage = "officeCode alaný 10 karakterden uzun olamaz.")]
        [Column("officeCode", Order = 6, TypeName = "varchar")]
        public string officeCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the reportsTo
        /// </summary>
        [Column("reportsTo", Order = 7, TypeName = "int")]
        public int? reportsTo
        { get; set; }

        /// <summary>
        /// Gets or Sets the jobTitle
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "jobTitle alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "jobTitle alaný 50 karakterden uzun olamaz.")]
        [Column("jobTitle", Order = 8, TypeName = "varchar")]
        public string jobTitle
        { get; set; }

        [ForeignKey("officeCode")]
        public virtual Offices Offices
        { get; set; }

        [ForeignKey("reportsTo")]
        public virtual Employee Employees
        { get; set; }

        public virtual ICollection<Customers> CustomersList
        { get; set; }

        public virtual ICollection<Employee> EmployeesList
        { get; set; }
    }
}