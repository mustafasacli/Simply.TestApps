using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimplyTest_Entities
{
    [Table("customers", Schema = "classicmodels")]
    [Serializable]
    public class Customers
    {
        /// <summary>
        /// Gets or Sets the customerNumber
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "customerNumber alan�na veri girilmelidir.")]
        [Column("customerNumber", Order = 1, TypeName = "int")]
        public int CustomerNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the customerName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "customerName alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "customerName alan� 50 karakterden uzun olamaz.")]
        [Column("customerName", Order = 2, TypeName = "varchar")]
        public string CustomerName
        { get; set; }

        /// <summary>
        /// Gets or Sets the contactLastName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "contactLastName alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "contactLastName alan� 50 karakterden uzun olamaz.")]
        [Column("contactLastName", Order = 3, TypeName = "varchar")]
        public string ContactLastName
        { get; set; }

        /// <summary>
        /// Gets or Sets the contactFirstName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "contactFirstName alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "contactFirstName alan� 50 karakterden uzun olamaz.")]
        [Column("contactFirstName", Order = 4, TypeName = "varchar")]
        public string ContactFirstName
        { get; set; }

        /// <summary>
        /// Gets or Sets the Phone
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "Phone alan� 50 karakterden uzun olamaz.")]
        [Column("phone", Order = 5, TypeName = "varchar")]
        public string Phone
        { get; set; }

        /// <summary>
        /// Gets or Sets the addressLine1
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "addressLine1 alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "addressLine1 alan� 50 karakterden uzun olamaz.")]
        [Column("addressLine1", Order = 6, TypeName = "varchar")]
        public string AddressLine1
        { get; set; }

        /// <summary>
        /// Gets or Sets the addressLine2
        /// </summary>
        [StringLength(50, ErrorMessage = "addressLine2 alan� 50 karakterden uzun olamaz.")]
        [Column("addressLine2", Order = 7, TypeName = "varchar")]
        public string AddressLine2
        { get; set; }

        /// <summary>
        /// Gets or Sets the City
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "City alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "City alan� 50 karakterden uzun olamaz.")]
        [Column("city", Order = 8, TypeName = "varchar")]
        public string City
        { get; set; }

        /// <summary>
        /// Gets or Sets the State
        /// </summary>
        [StringLength(50, ErrorMessage = "State alan� 50 karakterden uzun olamaz.")]
        [Column("state", Order = 9, TypeName = "varchar")]
        public string State
        { get; set; }

        /// <summary>
        /// Gets or Sets the postalCode
        /// </summary>
        [StringLength(15, ErrorMessage = "postalCode alan� 15 karakterden uzun olamaz.")]
        [Column("postalCode", Order = 10, TypeName = "varchar")]
        public string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the Country
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "Country alan� 50 karakterden uzun olamaz.")]
        [Column("country", Order = 11, TypeName = "varchar")]
        public string Country
        { get; set; }

        /// <summary>
        /// Gets or Sets the salesRepEmployeeNumber
        /// </summary>
        [Column("salesRepEmployeeNumber", Order = 12, TypeName = "int")]
        public int? SalesRepEmployeeNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the creditLimit
        /// </summary>
        [Column("creditLimit", Order = 13, TypeName = "decimal")]
        public decimal? CreditLimit
        { get; set; }

        //[ForeignKey("salesRepEmployeeNumber")]
        //public virtual Employee Employees
        //{ get; set; }

        //public virtual ICollection<Orders> OrdersList
        //{ get; set; }

        //public virtual ICollection<Payments> PaymentsList
        //{ get; set; }
    }
}