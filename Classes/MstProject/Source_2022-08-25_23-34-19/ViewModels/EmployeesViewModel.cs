using System.ComponentModel.DataAnnotations;

namespace Mst.Project.ViewModel
{
    public class EmployeesViewModel
    {
        /// <summary>
        /// Gets or Sets the EmployeeNumber
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "EmployeeNumber alanýna veri girilmelidir.")]
        public int EmployeeNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastName alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "LastName alaný 50 karakterden uzun olamaz.")]
        public string LastName
        { get; set; }

        /// <summary>
        /// Gets or Sets the FirstName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "FirstName alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "FirstName alaný 50 karakterden uzun olamaz.")]
        public string FirstName
        { get; set; }

        /// <summary>
        /// Gets or Sets the Extension
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Extension alanýna veri girilmelidir.")]
        [StringLength(10, ErrorMessage = "Extension alaný 10 karakterden uzun olamaz.")]
        public string Extension
        { get; set; }

        /// <summary>
        /// Gets or Sets the Email
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email alanýna veri girilmelidir.")]
        [StringLength(100, ErrorMessage = "Email alaný 100 karakterden uzun olamaz.")]
        public string Email
        { get; set; }

        /// <summary>
        /// Gets or Sets the OfficeCode
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "OfficeCode alanýna veri girilmelidir.")]
        [StringLength(10, ErrorMessage = "OfficeCode alaný 10 karakterden uzun olamaz.")]
        public string OfficeCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the ReportsTo
        /// </summary>
        public int? ReportsTo
        { get; set; }

        /// <summary>
        /// Gets or Sets the JobTitle
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "JobTitle alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "JobTitle alaný 50 karakterden uzun olamaz.")]
        public string JobTitle
        { get; set; }
    }
}