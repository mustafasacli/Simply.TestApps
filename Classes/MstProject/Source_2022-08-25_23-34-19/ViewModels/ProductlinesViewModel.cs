using System.ComponentModel.DataAnnotations;

namespace Mst.Project.ViewModel
{
    public class ProductlinesViewModel
    {
        /// <summary>
        /// Gets or Sets the ProductLine
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ProductLine alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "ProductLine alaný 50 karakterden uzun olamaz.")]
        public string ProductLine
        { get; set; }

        /// <summary>
        /// Gets or Sets the TextDescription
        /// </summary>
        [StringLength(4000, ErrorMessage = "TextDescription alaný 4000 karakterden uzun olamaz.")]
        public string TextDescription
        { get; set; }

        /// <summary>
        /// Gets or Sets the HtmlDescription
        /// </summary>
        [StringLength(16777215, ErrorMessage = "HtmlDescription alaný 16777215 karakterden uzun olamaz.")]
        public string HtmlDescription
        { get; set; }

        /// <summary>
        /// Gets or Sets the Image
        /// </summary>
        public byte[] Image
        { get; set; }
    }
}