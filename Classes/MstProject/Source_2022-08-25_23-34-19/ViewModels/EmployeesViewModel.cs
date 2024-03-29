using System.ComponentModel.DataAnnotations;

namespace Mst.Project.ViewModel
{
    public class EmployeesViewModel
    {
        /// <summary>
        /// Gets or Sets the EmployeeNumber
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "EmployeeNumber alan�na veri girilmelidir.")]
        public int EmployeeNumber
        { get; set; }

        /// <summary>
        /// Gets or Sets the LastName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastName alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "LastName alan� 50 karakterden uzun olamaz.")]
        public string LastName
        { get; set; }

        /// <summary>
        /// Gets or Sets the FirstName
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "FirstName alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "FirstName alan� 50 karakterden uzun olamaz.")]
        public string FirstName
        { get; set; }

        /// <summary>
        /// Gets or Sets the Extension
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Extension alan�na veri girilmelidir.")]
        [StringLength(10, ErrorMessage = "Extension alan� 10 karakterden uzun olamaz.")]
        public string Extension
        { get; set; }

        /// <summary>
        /// Gets or Sets the Email
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email alan�na veri girilmelidir.")]
        [StringLength(100, ErrorMessage = "Email alan� 100 karakterden uzun olamaz.")]
        public string Email
        { get; set; }

        /// <summary>
        /// Gets or Sets the OfficeCode
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "OfficeCode alan�na veri girilmelidir.")]
        [StringLength(10, ErrorMessage = "OfficeCode alan� 10 karakterden uzun olamaz.")]
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
        [Required(AllowEmptyStrings = false, ErrorMessage = "JobTitle alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "JobTitle alan� 50 karakterden uzun olamaz.")]
        public string JobTitle
        { get; set; }
    }
}