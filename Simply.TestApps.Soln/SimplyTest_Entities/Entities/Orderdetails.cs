using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimplyTest_Entities
{
    [Table("orderdetails", Schema = "classicmodels")]
    public class Orderdetails
    {
        /// <summary>
        /// Gets or Sets the orderNumber
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "orderNumber alan�na veri girilmelidir.")]
        [Column("orderNumber", Order = 1, TypeName = "int")]
        public int orderNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the productCode
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "productCode alan�na veri girilmelidir.")]
        [StringLength(15, ErrorMessage = "productCode alan� 15 karakterden uzun olamaz.")]
        [Column("productCode", Order = 2, TypeName = "varchar")]
        public string productCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the quantityOrdered
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "quantityOrdered alan�na veri girilmelidir.")]
        [Column("quantityOrdered", Order = 3, TypeName = "int")]
        public int quantityOrdered
        { get; set; }

        /// <summary>
        /// Gets or Sets the priceEach
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "priceEach alan�na veri girilmelidir.")]
        [Column("priceEach", Order = 4, TypeName = "decimal")]
        public decimal priceEach
        { get; set; }

        /// <summary>
        /// Gets or Sets the orderLineNumber
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "orderLineNumber alan�na veri girilmelidir.")]
        [Column("orderLineNumber", Order = 5, TypeName = "smallint")]
        public short orderLineNumber
        { get; set; }

        [ForeignKey("orderNumber")]
        public virtual Orders Orders
        { get; set; }

        [ForeignKey("productCode")]
        public virtual Products Products
        { get; set; }
    }
}