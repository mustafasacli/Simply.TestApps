using System.ComponentModel.DataAnnotations;

namespace Mst.Project.ViewModel
{
    public class OrderdetailsViewModel
    {
        /// <summary>
        /// Gets or Sets the OrderNumber
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "OrderNumber alanýna veri girilmelidir.")]
        public int OrderNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the ProductCode
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ProductCode alanýna veri girilmelidir.")]
        [StringLength(15, ErrorMessage = "ProductCode alaný 15 karakterden uzun olamaz.")]
        public string ProductCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the QuantityOrdered
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "QuantityOrdered alanýna veri girilmelidir.")]
        public int QuantityOrdered
        { get; set; }

        /// <summary>
        /// Gets or Sets the PriceEach
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "PriceEach alanýna veri girilmelidir.")]
        public decimal PriceEach
        { get; set; }

        /// <summary>
        /// Gets or Sets the OrderLineNumber
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "OrderLineNumber alanýna veri girilmelidir.")]
        public short OrderLineNumber
        { get; set; }
    }
}