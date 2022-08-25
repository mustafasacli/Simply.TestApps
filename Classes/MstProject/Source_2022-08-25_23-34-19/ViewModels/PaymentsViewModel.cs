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
        [Required(AllowEmptyStrings = false, ErrorMessage = "CustomerNumber alanýna veri girilmelidir.")]
        public int CustomerNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the CheckNumber
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "CheckNumber alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "CheckNumber alaný 50 karakterden uzun olamaz.")]
        public string CheckNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the PaymentDate
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "PaymentDate alanýna veri girilmelidir.")]
        public DateTime PaymentDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the Amount
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Amount alanýna veri girilmelidir.")]
        public decimal Amount
        { get; set; }
    }
}