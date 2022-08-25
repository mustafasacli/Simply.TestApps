using System.ComponentModel.DataAnnotations;

namespace Mst.Project.ViewModel
{
    public class CustomersViewModel
    {
        /// <summary>
        /// Gets or Sets the CustomerNumber
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "CustomerNumber alanýna veri girilmelidir.")]
        public int CustomerNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the CustomerName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "CustomerName alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "CustomerName alaný 50 karakterden uzun olamaz.")]
        public string CustomerName
        { get; set; }

        /// <summary>
        /// Gets or Sets the ContactLastName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "ContactLastName alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "ContactLastName alaný 50 karakterden uzun olamaz.")]
        public string ContactLastName
        { get; set; }

        /// <summary>
        /// Gets or Sets the ContactFirstName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "ContactFirstName alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "ContactFirstName alaný 50 karakterden uzun olamaz.")]
        public string ContactFirstName
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
        /// Gets or Sets the City
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "City alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "City alaný 50 karakterden uzun olamaz.")]
        public string City
        { get; set; }

        /// <summary>
        /// Gets or Sets the State
        /// </summary>
        [StringLength(50, ErrorMessage = "State alaný 50 karakterden uzun olamaz.")]
        public string State
        { get; set; }

        /// <summary>
        /// Gets or Sets the PostalCode
        /// </summary>
        [StringLength(15, ErrorMessage = "PostalCode alaný 15 karakterden uzun olamaz.")]
        public string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the Country
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "Country alaný 50 karakterden uzun olamaz.")]
        public string Country
        { get; set; }

        /// <summary>
        /// Gets or Sets the SalesRepEmployeeNumber
        /// </summary>
        public int? SalesRepEmployeeNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the CreditLimit
        /// </summary>
        public decimal? CreditLimit
        { get; set; }
    }
}