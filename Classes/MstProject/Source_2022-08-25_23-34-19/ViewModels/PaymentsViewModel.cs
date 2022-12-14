using System;
using System.ComponentModel.DataAnnotations;

namespace Mst.Project.ViewModel
{
    public class PaymentsViewModel
    {
        /// <summary>
        /// Gets or Sets the CustomerNumber
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "CustomerNumber alanưna veri girilmelidir.")]
        public int CustomerNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the CheckNumber
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "CheckNumber alanưna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "CheckNumber alanư 50 karakterden uzun olamaz.")]
        public string CheckNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the PaymentDate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "PaymentDate alanưna veri girilmelidir.")]
        public DateTime PaymentDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the Amount
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Amount alanưna veri girilmelidir.")]
        public decimal Amount
        { get; set; }
    }
}