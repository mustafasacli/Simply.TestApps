using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimplyTest_Entities
{
    [Table("productlines", Schema = "classicmodels")]
    public class Productlines
    {
        /// <summary>
        /// Gets or Sets the productLine
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "productLine alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "productLine alaný 50 karakterden uzun olamaz.")]
        [Column("productLine", Order = 1, TypeName = "varchar")]
        public string productLine
        { get; set; }

        /// <summary>
        /// Gets or Sets the textDescription
        /// </summary>
        [StringLength(4000, ErrorMessage = "textDescription alaný 4000 karakterden uzun olamaz.")]
        [Column("textDescription", Order = 2, TypeName = "varchar")]
        public string textDescription
        { get; set; }

        /// <summary>
        /// Gets or Sets the htmlDescription
        /// </summary>
        [StringLength(16777215, ErrorMessage = "htmlDescription alaný 16777215 karakterden uzun olamaz.")]
        [Column("htmlDescription", Order = 3, TypeName = "mediumtext")]
        public string htmlDescription
        { get; set; }

        /// <summary>
        /// Gets or Sets the Image
        /// </summary>
        [Column("image", Order = 4, TypeName = "mediumblob")]
        public byte[] Image
        { get; set; }

        public virtual ICollection<Products> ProductsList
        { get; set; }
    }
}