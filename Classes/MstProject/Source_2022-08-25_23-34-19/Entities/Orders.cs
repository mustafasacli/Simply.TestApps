using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mst.Project.Entity
{
    [Table("orders", Schema = "classicmodels")]
    public class Orders
    {
        /// <summary>
        /// Gets or Sets the OrderNumber
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "OrderNumber alanưna veri girilmelidir.")]
        [Column("orderNumber", Order = 1, TypeName = "int")]
        public int OrderNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the OrderDate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "OrderDate alanưna veri girilmelidir.")]
        [Column("orderDate", Order = 2, TypeName = "date")]
        public DateTime OrderDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the RequiredDate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredDate alanưna veri girilmelidir.")]
        [Column("requiredDate", Order = 3, TypeName = "date")]
        public DateTime RequiredDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the ShippedDate
        /// </summary>
        [Column("shippedDate", Order = 4, TypeName = "date")]
        public DateTime? ShippedDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the Status
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Status alanưna veri girilmelidir.")]
        [StringLength(15, ErrorMessage = "Status alanư 15 karakterden uzun olamaz.")]
        [Column("status", Order = 5, TypeName = "varchar")]
        public string Status
        { get; set; }

        /// <summary>
        /// Gets or Sets the Comments
        /// </summary>
        [StringLength(65535, ErrorMessage = "Comments alanư 65535 karakterden uzun olamaz.")]
        [Column("comments", Order = 6, TypeName = "text")]
        public string Comments
        { get; set; }

        /// <summary>
        /// Gets or Sets the CustomerNumber
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "CustomerNumber alanưna veri girilmelidir.")]
        [Column("customerNumber", Order = 7, TypeName = "int")]
        public int CustomerNumber
        { get; set; }

        [ForeignKey("CustomerNumber")]
        public virtual Customers Customers
        { get; set; }

        public virtual ICollection<Orderdetails> OrderdetailsList
        { get; set; }
    }
}