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
        [Required(AllowEmptyStrings = false, ErrorMessage = "officeCode alan�na veri girilmelidir.")]
        [StringLength(10, ErrorMessage = "officeCode alan� 10 karakterden uzun olamaz.")]
        [Column("officeCode", Order = 1, TypeName = "varchar")]
        public string officeCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the City
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "City alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "City alan� 50 karakterden uzun olamaz.")]
        [Column("city", Order = 2, TypeName = "varchar")]
        public string City
        { get; set; }

        /// <summary>
        /// Gets or Sets the Phone
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "Phone alan� 50 karakterden uzun olamaz.")]
        [Column("phone", Order = 3, TypeName = "varchar")]
        public string Phone
        { get; set; }

        /// <summary>
        /// Gets or Sets the addressLine1
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "addressLine1 alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "addressLine1 alan� 50 karakterden uzun olamaz.")]
        [Column("addressLine1", Order = 4, TypeName = "varchar")]
        public string addressLine1
        { get; set; }

        /// <summary>
        /// Gets or Sets the addressLine2
        /// </summary>
        [StringLength(50, ErrorMessage = "addressLine2 alan� 50 karakterden uzun olamaz.")]
        [Column("addressLine2", Order = 5, TypeName = "varchar")]
        public string addressLine2
        { get; set; }

        /// <summary>
        /// Gets or Sets the State
        /// </summary>
        [StringLength(50, ErrorMessage = "State alan� 50 karakterden uzun olamaz.")]
        [Column("state", Order = 6, TypeName = "varchar")]
        public string State
        { get; set; }

        /// <summary>
        /// Gets or Sets the Country
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country alan�na veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "Country alan� 50 karakterden uzun olamaz.")]
        [Column("country", Order = 7, TypeName = "varchar")]
        public string Country
        { get; set; }

        /// <summary>
        /// Gets or Sets the postalCode
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "postalCode alan�na veri girilmelidir.")]
        [StringLength(15, ErrorMessage = "postalCode alan� 15 karakterden uzun olamaz.")]
        [Column("postalCode", Order = 8, TypeName = "varchar")]
        public string postalCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the Territory
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Territory alan�na veri girilmelidir.")]
        [StringLength(10, ErrorMessage = "Territory alan� 10 karakterden uzun olamaz.")]
        [Column("territory", Order = 9, TypeName = "varchar")]
        public string Territory
        { get; set; }

        public virtual ICollection<Employee> EmployeesList
        { get; set; }
    }
}