using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Drawing.Drawing2D;

namespace ASPprojekt13806.Models
{
    public class Vehicles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int BrandId { get; set; }
        public Brands Brand { get; set; }
        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Categories Category { get; set; }
        [Required]
        public string Model { get; set; }
        [StringLength(20)]
        [AllowNull]
        public string Image { get; set; } = "noimage.png";
        public int Year { get; set; }
    }
}
