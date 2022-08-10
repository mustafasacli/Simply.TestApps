using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimplyTest_Entities
{
    [Table("orders", Schema = "classicmodels")]
    public class Orders
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
        /// Gets or Sets the orderDate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "orderDate alan�na veri girilmelidir.")]
        [Column("orderDate", Order = 2, TypeName = "date")]
        public DateTime orderDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the requiredDate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "requiredDate alan�na veri girilmelidir.")]
        [Column("requiredDate", Order = 3, TypeName = "date")]
        public DateTime requiredDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the shippedDate
        /// </summary>
        [Column("shippedDate", Order = 4, TypeName = "date")]
        public DateTime? shippedDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the Status
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Status alan�na veri girilmelidir.")]
        [StringLength(15, ErrorMessage = "Status alan� 15 karakterden uzun olamaz.")]
        [Column("status", Order = 5, TypeName = "varchar")]
        public string Status
        { get; set; }

        /// <summary>
        /// Gets or Sets the Comments
        /// </summary>
        [StringLength(65535, ErrorMessage = "Comments alan� 65535 karakterden uzun olamaz.")]
        [Column("comments", Order = 6, TypeName = "text")]
        public string Comments
        { get; set; }

        /// <summary>
        /// Gets or Sets the customerNumber
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "customerNumber alan�na veri girilmelidir.")]
        [Column("customerNumber", Order = 7, TypeName = "int")]
        public int customerNumber
        { get; set; }

        [ForeignKey("customerNumber")]
        public virtual Customers Customers
        { get; set; }

        public virtual ICollection<Orderdetails> OrderdetailsList
        { get; set; }
    }
}