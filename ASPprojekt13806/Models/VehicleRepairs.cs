using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASPprojekt13806.Models
{
    public class VehicleRepairs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int RepairDate { get; set; }

        public int VehicleId { get; set; }
        public Vehicles Vehicle { get; set; }
    }
}
