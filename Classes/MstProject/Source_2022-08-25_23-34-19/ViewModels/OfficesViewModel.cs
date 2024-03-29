using System.ComponentModel.DataAnnotations;

namespace Mst.Project.ViewModel
{
    public class OfficesViewModel
    {
        /// <summary>
        /// Gets or Sets the OfficeCode
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "OfficeCode alan�na veri girilmelidir.")]
        [StringLength(10, ErrorMessage = "OfficeCode alan� 10 karakterden uzun olamaz.")]
        public string OfficeCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the City
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "City alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "City alan� 50 karakterden uzun olamaz.")]
        public string City
        { get; set; }

        /// <summary>
        /// Gets or Sets the Phone
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "Phone alan� 50 karakterden uzun olamaz.")]
        public string Phone
        { get; set; }

        /// <summary>
        /// Gets or Sets the AddressLine1
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "AddressLine1 alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "AddressLine1 alan� 50 karakterden uzun olamaz.")]
        public string AddressLine1
        { get; set; }

        /// <summary>
        /// Gets or Sets the AddressLine2
        /// </summary>
        [StringLength(50, ErrorMessage = "AddressLine2 alan� 50 karakterden uzun olamaz.")]
        public string AddressLine2
        { get; set; }

        /// <summary>
        /// Gets or Sets the State
        /// </summary>
        [StringLength(50, ErrorMessage = "State alan� 50 karakterden uzun olamaz.")]
        public string State
        { get; set; }

        /// <summary>
        /// Gets or Sets the Country
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "Country alan� 50 karakterden uzun olamaz.")]
        public string Country
        { get; set; }

        /// <summary>
        /// Gets or Sets the PostalCode
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "PostalCode alan�na veri girilmelidir.")]
        [StringLength(15, ErrorMessage = "PostalCode alan� 15 karakterden uzun olamaz.")]
        public string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the Territory
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Territory alan�na veri girilmelidir.")]
        [StringLength(10, ErrorMessage = "Territory alan� 10 karakterden uzun olamaz.")]
        public string Territory
        { get; set; }
    }
}