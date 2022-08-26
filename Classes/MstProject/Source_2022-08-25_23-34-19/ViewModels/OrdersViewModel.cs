using System;
using System.ComponentModel.DataAnnotations;

namespace Mst.Project.ViewModel
{
    public class OrdersViewModel
    {
        /// <summary>
        /// Gets or Sets the OrderNumber
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "OrderNumber alan�na veri girilmelidir.")]
        public int OrderNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the OrderDate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "OrderDate alan�na veri girilmelidir.")]
        public DateTime OrderDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the RequiredDate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredDate alan�na veri girilmelidir.")]
        public DateTime RequiredDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the ShippedDate
        /// </summary>
        public DateTime? ShippedDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the Status
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Status alan�na veri girilmelidir.")]
        [StringLength(15, ErrorMessage = "Status alan� 15 karakterden uzun olamaz.")]
        public string Status
        { get; set; }

        /// <summary>
        /// Gets or Sets the Comments
        /// </summary>
        [StringLength(65535, ErrorMessage = "Comments alan� 65535 karakterden uzun olamaz.")]
        public string Comments
        { get; set; }

        /// <summary>
        /// Gets or Sets the CustomerNumber
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "CustomerNumber alan�na veri girilmelidir.")]
        public int CustomerNumber
        { get; set; }
    }
}