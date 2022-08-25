using System.ComponentModel.DataAnnotations;

namespace Mst.Project.ViewModel
{
    public class OfficesViewModel
    {
        /// <summary>
        /// Gets or Sets the OfficeCode
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "OfficeCode alanýna veri girilmelidir.")]
        [StringLength(10, ErrorMessage = "OfficeCode alaný 10 karakterden uzun olamaz.")]
        public string OfficeCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the City
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "City alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "City alaný 50 karakterden uzun olamaz.")]
        public string City
        { get; set; }

        /// <summary>
        /// Gets or Sets the Phone
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "Phone alaný 50 karakterden uzun olamaz.")]
        public string Phone
        { get; set; }

        /// <summary>
        /// Gets or Sets the AddressLine1
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "AddressLine1 alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "AddressLine1 alaný 50 karakterden uzun olamaz.")]
        public string AddressLine1
        { get; set; }

        /// <summary>
        /// Gets or Sets the AddressLine2
        /// </summary>
        [StringLength(50, ErrorMessage = "AddressLine2 alaný 50 karakterden uzun olamaz.")]
        public string AddressLine2
        { get; set; }

        /// <summary>
        /// Gets or Sets the State
        /// </summary>
        [StringLength(50, ErrorMessage = "State alaný 50 karakterden uzun olamaz.")]
        public string State
        { get; set; }

        /// <summary>
        /// Gets or Sets the Country
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "Country alaný 50 karakterden uzun olamaz.")]
        public string Country
        { get; set; }

        /// <summary>
        /// Gets or Sets the PostalCode
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "PostalCode alanýna veri girilmelidir.")]
        [StringLength(15, ErrorMessage = "PostalCode alaný 15 karakterden uzun olamaz.")]
        public string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the Territory
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Territory alanýna veri girilmelidir.")]
        [StringLength(10, ErrorMessage = "Territory alaný 10 karakterden uzun olamaz.")]
        public string Territory
        { get; set; }
    }
}