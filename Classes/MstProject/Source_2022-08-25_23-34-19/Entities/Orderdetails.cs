using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mst.Project.Entity
{
    [Table("orderdetails", Schema = "classicmodels")]
    public class Orderdetails
    {
        /// <summary>
        /// Gets or Sets the OrderNumber
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "OrderNumber alanýna veri girilmelidir.")]
        [Column("orderNumber", Order = 1, TypeName = "int")]
        public int OrderNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the ProductCode
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ProductCode alanýna veri girilmelidir.")]
        [StringLength(15, ErrorMessage = "ProductCode alaný 15 karakterden uzun olamaz.")]
        [Column("productCode", Order = 2, TypeName = "varchar")]
        public string ProductCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the QuantityOrdered
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "QuantityOrdered alanýna veri girilmelidir.")]
        [Column("quantityOrdered", Order = 3, TypeName = "int")]
        public int QuantityOrdered
        { get; set; }

        /// <summary>
        /// Gets or Sets the PriceEach
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "PriceEach alanýna veri girilmelidir.")]
        [Column("priceEach", Order = 4, TypeName = "decimal")]
        public decimal PriceEach
        { get; set; }

        /// <summary>
        /// Gets or Sets the OrderLineNumber
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "OrderLineNumber alanýna veri girilmelidir.")]
        [Column("orderLineNumber", Order = 5, TypeName = "smallint")]
        public short OrderLineNumber
        { get; set; }

        [ForeignKey("OrderNumber")]
        public virtual Orders Orders
        { get; set; }

        [ForeignKey("ProductCode")]
        public virtual Products Products
        { get; set; }
    }
}