using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mst.Project.Entity
{
    [Table("productlines", Schema = "classicmodels")]
    public class Productlines
    {
        /// <summary>
        /// Gets or Sets the ProductLine
        /// </summary>
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ProductLine alanýna veri girilmelidir.")]
        [StringLength(50, ErrorMessage = "ProductLine alaný 50 karakterden uzun olamaz.")]
        [Column("productLine", Order = 1, TypeName = "varchar")]
        public string ProductLine
        { get; set; }

        /// <summary>
        /// Gets or Sets the TextDescription
        /// </summary>
        [StringLength(4000, ErrorMessage = "TextDescription alaný 4000 karakterden uzun olamaz.")]
        [Column("textDescription", Order = 2, TypeName = "varchar")]
        public string TextDescription
        { get; set; }

        /// <summary>
        /// Gets or Sets the HtmlDescription
        /// </summary>
        [StringLength(16777215, ErrorMessage = "HtmlDescription alaný 16777215 karakterden uzun olamaz.")]
        [Column("htmlDescription", Order = 3, TypeName = "mediumtext")]
        public string HtmlDescription
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