using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mst.Project.Entity
{
    [Table("products", Schema = "classicmodels")]
    public class Products
    {
        /// <summary>
        /// Gets or Sets the ProductCode
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ProductCode alan�na veri girilmelidir.")]
        [StringLength(15, ErrorMessage = "ProductCode alan� 15 karakterden uzun olamaz.")]
        [Column("productCode", Order = 1, TypeName = "varchar")]
        public string ProductCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the ProductName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "ProductName alan�na veri girilmelidir.")]
        [StringLength(70, ErrorMessage = "ProductName alan� 70 karakterden uzun olamaz.")]
        [Column("productName", Order = 2, TypeName = "varchar")]
        public string ProductName
        { get; set; }

        /// <summary>
        /// Gets or Sets the ProductLine
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "ProductLine alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "ProductLine alan� 50 karakterden uzun olamaz.")]
        [Column("productLine", Order = 3, TypeName = "varchar")]
        public string ProductLine
        { get; set; }

        /// <summary>
        /// Gets or Sets the ProductScale
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "ProductScale alan�na veri girilmelidir.")]
        [StringLength(10, ErrorMessage = "ProductScale alan� 10 karakterden uzun olamaz.")]
        [Column("productScale", Order = 4, TypeName = "varchar")]
        public string ProductScale
        { get; set; }

        /// <summary>
        /// Gets or Sets the ProductVendor
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "ProductVendor alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "ProductVendor alan� 50 karakterden uzun olamaz.")]
        [Column("productVendor", Order = 5, TypeName = "varchar")]
        public string ProductVendor
        { get; set; }

        /// <summary>
        /// Gets or Sets the ProductDescription
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "ProductDescription alan�na veri girilmelidir.")]
        [StringLength(65535, ErrorMessage = "ProductDescription alan� 65535 karakterden uzun olamaz.")]
        [Column("productDescription", Order = 6, TypeName = "text")]
        public string ProductDescription
        { get; set; }

        /// <summary>
        /// Gets or Sets the QuantityInStock
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "QuantityInStock alan�na veri girilmelidir.")]
        [Column("quantityInStock", Order = 7, TypeName = "smallint")]
        public short QuantityInStock
        { get; set; }

        /// <summary>
        /// Gets or Sets the BuyPrice
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "BuyPrice alan�na veri girilmelidir.")]
        [Column("buyPrice", Order = 8, TypeName = "decimal")]
        public decimal BuyPrice
        { get; set; }

        /// <summary>
        /// Gets or Sets the Msrp
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Msrp alan�na veri girilmelidir.")]
        [Column("MSRP", Order = 9, TypeName = "decimal")]
        public decimal Msrp
        { get; set; }

        [ForeignKey("ProductLine")]
        public virtual Productlines Productlines
        { get; set; }

        public virtual ICollection<Orderdetails> OrderdetailsList
        { get; set; }
    }
}