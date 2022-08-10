using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimplyTest_Entities
{
    [Table("payments", Schema = "classicmodels")]
    public class Payments
    {
        /// <summary>
        /// Gets or Sets the customerNumber
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "customerNumber alan�na veri girilmelidir.")]
        [Column("customerNumber", Order = 1, TypeName = "int")]
        public int customerNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the checkNumber
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "checkNumber alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "checkNumber alan� 50 karakterden uzun olamaz.")]
        [Column("checkNumber", Order = 2, TypeName = "varchar")]
        public string checkNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the paymentDate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "paymentDate alan�na veri girilmelidir.")]
        [Column("paymentDate", Order = 3, TypeName = "date")]
        public DateTime paymentDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the Amount
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Amount alan�na veri girilmelidir.")]
        [Column("amount", Order = 4, TypeName = "decimal")]
        public decimal Amount
        { get; set; }

        [ForeignKey("customerNumber")]
        public virtual Customers Customers
        { get; set; }
    }
}