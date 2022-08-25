using System.ComponentModel.DataAnnotations;

namespace Mst.Project.ViewModel
{
    public class ProductsViewModel
    {
        /// <summary>
        /// Gets or Sets the ProductCode
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ProductCode alanýna veri girilmelidir.")]
        [StringLength(15, ErrorMessage = "ProductCode alaný 15 karakterden uzun olamaz.")]
        public string ProductCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the ProductName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "ProductName alanýna veri girilmelidir.")]
        [StringLength(70, ErrorMessage = "ProductName alaný 70 karakterden uzun olamaz.")]
        public string ProductName
        { get; set; }

        /// <summary>
        /// Gets or Sets the ProductLine
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "ProductLine alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "ProductLine alaný 50 karakterden uzun olamaz.")]
        public string ProductLine
        { get; set; }

        /// <summary>
        /// Gets or Sets the ProductScale
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "ProductScale alanýna veri girilmelidir.")]
        [StringLength(10, ErrorMessage = "ProductScale alaný 10 karakterden uzun olamaz.")]
        public string ProductScale
        { get; set; }

        /// <summary>
        /// Gets or Sets the ProductVendor
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "ProductVendor alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "ProductVendor alaný 50 karakterden uzun olamaz.")]
        public string ProductVendor
        { get; set; }

        /// <summary>
        /// Gets or Sets the ProductDescription
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "ProductDescription alanýna veri girilmelidir.")]
        [StringLength(65535, ErrorMessage = "ProductDescription alaný 65535 karakterden uzun olamaz.")]
        public string ProductDescription
        { get; set; }

        /// <summary>
        /// Gets or Sets the QuantityInStock
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "QuantityInStock alanýna veri girilmelidir.")]
        public short QuantityInStock
        { get; set; }

        /// <summary>
        /// Gets or Sets the BuyPrice
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "BuyPrice alanýna veri girilmelidir.")]
        public decimal BuyPrice
        { get; set; }

        /// <summary>
        /// Gets or Sets the Msrp
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Msrp alanýna veri girilmelidir.")]
        public decimal Msrp
        { get; set; }
    }
}