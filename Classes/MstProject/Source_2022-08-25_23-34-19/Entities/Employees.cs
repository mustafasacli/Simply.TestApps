using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mst.Project.Entity
{
    [Table("employees", Schema = "classicmodels")]
    public class Employees
    {
        /// <summary>
        /// Gets or Sets the EmployeeNumber
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "EmployeeNumber alan�na veri girilmelidir.")]
        [Column("employeeNumber", Order = 1, TypeName = "int")]
        public int EmployeeNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastName alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "LastName alan� 50 karakterden uzun olamaz.")]
        [Column("lastName", Order = 2, TypeName = "varchar")]
        public string LastName
        { get; set; }

        /// <summary>
        /// Gets or Sets the FirstName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "FirstName alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "FirstName alan� 50 karakterden uzun olamaz.")]
        [Column("firstName", Order = 3, TypeName = "varchar")]
        public string FirstName
        { get; set; }

        /// <summary>
        /// Gets or Sets the Extension
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Extension alan�na veri girilmelidir.")]
        [StringLength(10, ErrorMessage = "Extension alan� 10 karakterden uzun olamaz.")]
        [Column("extension", Order = 4, TypeName = "varchar")]
        public string Extension
        { get; set; }

        /// <summary>
        /// Gets or Sets the Email
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email alan�na veri girilmelidir.")]
        [StringLength(100, ErrorMessage = "Email alan� 100 karakterden uzun olamaz.")]
        [Column("email", Order = 5, TypeName = "varchar")]
        public string Email
        { get; set; }

        /// <summary>
        /// Gets or Sets the OfficeCode
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "OfficeCode alan�na veri girilmelidir.")]
        [StringLength(10, ErrorMessage = "OfficeCode alan� 10 karakterden uzun olamaz.")]
        [Column("officeCode", Order = 6, TypeName = "varchar")]
        public string OfficeCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the ReportsTo
        /// </summary>
        [Column("reportsTo", Order = 7, TypeName = "int")]
        public int? ReportsTo
        { get; set; }

        /// <summary>
        /// Gets or Sets the JobTitle
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "JobTitle alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "JobTitle alan� 50 karakterden uzun olamaz.")]
        [Column("jobTitle", Order = 8, TypeName = "varchar")]
        public string JobTitle
        { get; set; }

        [ForeignKey("OfficeCode")]
        public virtual Offices Offices
        { get; set; }

        [ForeignKey("ReportsTo")]
        public virtual Employees Employees
        { get; set; }

        public virtual ICollection<Customers> CustomersList
        { get; set; }

        public virtual ICollection<Employees> EmployeesList
        { get; set; }
    }
}