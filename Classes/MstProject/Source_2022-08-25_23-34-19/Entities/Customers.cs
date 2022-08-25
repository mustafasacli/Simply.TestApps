using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mst.Project.Entity
{
    [Table("customers", Schema = "classicmodels")]
    public class Customers
    {
        /// <summary>
        /// Gets or Sets the CustomerNumber
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "CustomerNumber alanýna veri girilmelidir.")]
        [Column("customerNumber", Order = 1, TypeName = "int")]
        public int CustomerNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the CustomerName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "CustomerName alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "CustomerName alaný 50 karakterden uzun olamaz.")]
        [Column("customerName", Order = 2, TypeName = "varchar")]
        public string CustomerName
        { get; set; }

        /// <summary>
        /// Gets or Sets the ContactLastName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "ContactLastName alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "ContactLastName alaný 50 karakterden uzun olamaz.")]
        [Column("contactLastName", Order = 3, TypeName = "varchar")]
        public string ContactLastName
        { get; set; }

        /// <summary>
        /// Gets or Sets the ContactFirstName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "ContactFirstName alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "ContactFirstName alaný 50 karakterden uzun olamaz.")]
        [Column("contactFirstName", Order = 4, TypeName = "varchar")]
        public string ContactFirstName
        { get; set; }

        /// <summary>
        /// Gets or Sets the Phone
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "Phone alaný 50 karakterden uzun olamaz.")]
        [Column("phone", Order = 5, TypeName = "varchar")]
        public string Phone
        { get; set; }

        /// <summary>
        /// Gets or Sets the AddressLine1
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "AddressLine1 alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "AddressLine1 alaný 50 karakterden uzun olamaz.")]
        [Column("addressLine1", Order = 6, TypeName = "varchar")]
        public string AddressLine1
        { get; set; }

        /// <summary>
        /// Gets or Sets the AddressLine2
        /// </summary>
        [StringLength(50, ErrorMessage = "AddressLine2 alaný 50 karakterden uzun olamaz.")]
        [Column("addressLine2", Order = 7, TypeName = "varchar")]
        public string AddressLine2
        { get; set; }

        /// <summary>
        /// Gets or Sets the City
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "City alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "City alaný 50 karakterden uzun olamaz.")]
        [Column("city", Order = 8, TypeName = "varchar")]
        public string City
        { get; set; }

        /// <summary>
        /// Gets or Sets the State
        /// </summary>
        [StringLength(50, ErrorMessage = "State alaný 50 karakterden uzun olamaz.")]
        [Column("state", Order = 9, TypeName = "varchar")]
        public string State
        { get; set; }

        /// <summary>
        /// Gets or Sets the PostalCode
        /// </summary>
        [StringLength(15, ErrorMessage = "PostalCode alaný 15 karakterden uzun olamaz.")]
        [Column("postalCode", Order = 10, TypeName = "varchar")]
        public string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the Country
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "Country alaný 50 karakterden uzun olamaz.")]
        [Column("country", Order = 11, TypeName = "varchar")]
        public string Country
        { get; set; }

        /// <summary>
        /// Gets or Sets the SalesRepEmployeeNumber
        /// </summary>
        [Column("salesRepEmployeeNumber", Order = 12, TypeName = "int")]
        public int? SalesRepEmployeeNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the CreditLimit
        /// </summary>
        [Column("creditLimit", Order = 13, TypeName = "decimal")]
        public decimal? CreditLimit
        { get; set; }

        [ForeignKey("SalesRepEmployeeNumber")]
        public virtual Employees Employees
        { get; set; }

        public virtual ICollection<Orders> OrdersList
        { get; set; }

        public virtual ICollection<Payments> PaymentsList
        { get; set; }
    }
}