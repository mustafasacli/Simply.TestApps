using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mst.Project.Entity
{
    [Table("payments", Schema = "classicmodels")]
    public class Payments
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
        /// Gets or Sets the CheckNumber
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "CheckNumber alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "CheckNumber alaný 50 karakterden uzun olamaz.")]
        [Column("checkNumber", Order = 2, TypeName = "varchar")]
        public string CheckNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the PaymentDate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "PaymentDate alanýna veri girilmelidir.")]
        [Column("paymentDate", Order = 3, TypeName = "date")]
        public DateTime PaymentDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the Amount
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Amount alanýna veri girilmelidir.")]
        [Column("amount", Order = 4, TypeName = "decimal")]
        public decimal Amount
        { get; set; }

        [ForeignKey("CustomerNumber")]
        public virtual Customers Customers
        { get; set; }
    }
}