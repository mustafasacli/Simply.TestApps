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
        [Required(AllowEmptyStrings = false, ErrorMessage = "OrderNumber alanýna veri girilmelidir.")]
        public int OrderNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the OrderDate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "OrderDate alanýna veri girilmelidir.")]
        public DateTime OrderDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the RequiredDate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredDate alanýna veri girilmelidir.")]
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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Status alanýna veri girilmelidir.")]
        [StringLength(15, ErrorMessage = "Status alaný 15 karakterden uzun olamaz.")]
        public string Status
        { get; set; }

        /// <summary>
        /// Gets or Sets the Comments
        /// </summary>
        [StringLength(65535, ErrorMessage = "Comments alaný 65535 karakterden uzun olamaz.")]
        public string Comments
        { get; set; }

        /// <summary>
        /// Gets or Sets the CustomerNumber
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "CustomerNumber alanýna veri girilmelidir.")]
        public int CustomerNumber
        { get; set; }
    }
}