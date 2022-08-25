using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mst.Project.Entity
{
    [Table("offices", Schema = "classicmodels")]
    public class Offices
    {
        /// <summary>
        /// Gets or Sets the OfficeCode
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "OfficeCode alanýna veri girilmelidir.")]
        [StringLength(10, ErrorMessage = "OfficeCode alaný 10 karakterden uzun olamaz.")]
        [Column("officeCode", Order = 1, TypeName = "varchar")]
        public string OfficeCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the City
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "City alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "City alaný 50 karakterden uzun olamaz.")]
        [Column("city", Order = 2, TypeName = "varchar")]
        public string City
        { get; set; }

        /// <summary>
        /// Gets or Sets the Phone
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "Phone alaný 50 karakterden uzun olamaz.")]
        [Column("phone", Order = 3, TypeName = "varchar")]
        public string Phone
        { get; set; }

        /// <summary>
        /// Gets or Sets the AddressLine1
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "AddressLine1 alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "AddressLine1 alaný 50 karakterden uzun olamaz.")]
        [Column("addressLine1", Order = 4, TypeName = "varchar")]
        public string AddressLine1
        { get; set; }

        /// <summary>
        /// Gets or Sets the AddressLine2
        /// </summary>
        [StringLength(50, ErrorMessage = "AddressLine2 alaný 50 karakterden uzun olamaz.")]
        [Column("addressLine2", Order = 5, TypeName = "varchar")]
        public string AddressLine2
        { get; set; }

        /// <summary>
        /// Gets or Sets the State
        /// </summary>
        [StringLength(50, ErrorMessage = "State alaný 50 karakterden uzun olamaz.")]
        [Column("state", Order = 6, TypeName = "varchar")]
        public string State
        { get; set; }

        /// <summary>
        /// Gets or Sets the Country
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "Country alaný 50 karakterden uzun olamaz.")]
        [Column("country", Order = 7, TypeName = "varchar")]
        public string Country
        { get; set; }

        /// <summary>
        /// Gets or Sets the PostalCode
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "PostalCode alanýna veri girilmelidir.")]
        [StringLength(15, ErrorMessage = "PostalCode alaný 15 karakterden uzun olamaz.")]
        [Column("postalCode", Order = 8, TypeName = "varchar")]
        public string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the Territory
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Territory alanýna veri girilmelidir.")]
        [StringLength(10, ErrorMessage = "Territory alaný 10 karakterden uzun olamaz.")]
        [Column("territory", Order = 9, TypeName = "varchar")]
        public string Territory
        { get; set; }

        public virtual ICollection<Employees> EmployeesList
        { get; set; }
    }
}