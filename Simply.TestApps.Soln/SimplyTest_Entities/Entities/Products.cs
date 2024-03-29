using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimplyTest_Entities
{
    [Table("products", Schema = "classicmodels")]
    public class Products
    {
        /// <summary>
        /// Gets or Sets the productCode
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "productCode alan�na veri girilmelidir.")]
        [StringLength(15, ErrorMessage = "productCode alan� 15 karakterden uzun olamaz.")]
        [Column("productCode", Order = 1, TypeName = "varchar")]
        public string productCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the productName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "productName alan�na veri girilmelidir.")]
        [StringLength(70, ErrorMessage = "productName alan� 70 karakterden uzun olamaz.")]
        [Column("productName", Order = 2, TypeName = "varchar")]
        public string productName
        { get; set; }

        /// <summary>
        /// Gets or Sets the productLine
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "productLine alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "productLine alan� 50 karakterden uzun olamaz.")]
        [Column("productLine", Order = 3, TypeName = "varchar")]
        public string productLine
        { get; set; }

        /// <summary>
        /// Gets or Sets the productScale
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "productScale alan�na veri girilmelidir.")]
        [StringLength(10, ErrorMessage = "productScale alan� 10 karakterden uzun olamaz.")]
        [Column("productScale", Order = 4, TypeName = "varchar")]
        public string productScale
        { get; set; }

        /// <summary>
        /// Gets or Sets the productVendor
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "productVendor alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "productVendor alan� 50 karakterden uzun olamaz.")]
        [Column("productVendor", Order = 5, TypeName = "varchar")]
        public string productVendor
        { get; set; }

        /// <summary>
        /// Gets or Sets the productDescription
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "productDescription alan�na veri girilmelidir.")]
        [StringLength(65535, ErrorMessage = "productDescription alan� 65535 karakterden uzun olamaz.")]
        [Column("productDescription", Order = 6, TypeName = "text")]
        public string productDescription
        { get; set; }

        /// <summary>
        /// Gets or Sets the quantityInStock
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "quantityInStock alan�na veri girilmelidir.")]
        [Column("quantityInStock", Order = 7, TypeName = "smallint")]
        public short quantityInStock
        { get; set; }

        /// <summary>
        /// Gets or Sets the buyPrice
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "buyPrice alan�na veri girilmelidir.")]
        [Column("buyPrice", Order = 8, TypeName = "decimal")]
        public decimal buyPrice
        { get; set; }

        /// <summary>
        /// Gets or Sets the Msrp
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Msrp alan�na veri girilmelidir.")]
        [Column("MSRP", Order = 9, TypeName = "decimal")]
        public decimal Msrp
        { get; set; }

        [ForeignKey("productLine")]
        public virtual Productlines Productlines
        { get; set; }

        public virtual ICollection<Orderdetails> OrderdetailsList
        { get; set; }
    }
}