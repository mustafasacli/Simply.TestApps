using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimplyTest_Entities
{
    [Table("offices", Schema = "classicmodels")]
    public class Offices
    {
        /// <summary>
        /// Gets or Sets the officeCode
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "officeCode alanýna veri girilmelidir.")]
        [StringLength(10, ErrorMessage = "officeCode alaný 10 karakterden uzun olamaz.")]
        [Column("officeCode", Order = 1, TypeName = "varchar")]
        public string officeCode
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
        /// Gets or Sets the addressLine1
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "addressLine1 alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "addressLine1 alaný 50 karakterden uzun olamaz.")]
        [Column("addressLine1", Order = 4, TypeName = "varchar")]
        public string addressLine1
        { get; set; }

        /// <summary>
        /// Gets or Sets the addressLine2
        /// </summary>
        [StringLength(50, ErrorMessage = "addressLine2 alaný 50 karakterden uzun olamaz.")]
        [Column("addressLine2", Order = 5, TypeName = "varchar")]
        public string addressLine2
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
        /// Gets or Sets the postalCode
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "postalCode alanýna veri girilmelidir.")]
        [StringLength(15, ErrorMessage = "postalCode alaný 15 karakterden uzun olamaz.")]
        [Column("postalCode", Order = 8, TypeName = "varchar")]
        public string postalCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the Territory
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Territory alanýna veri girilmelidir.")]
        [StringLength(10, ErrorMessage = "Territory alaný 10 karakterden uzun olamaz.")]
        [Column("territory", Order = 9, TypeName = "varchar")]
        public string Territory
        { get; set; }

        public virtual ICollection<Employee> EmployeesList
        { get; set; }
    }
}