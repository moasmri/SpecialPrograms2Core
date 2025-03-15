using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SpecialProgramsCore.Models
{
    public class SpecialHalqatStudent
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("SpecialStudent")]
        public int StudentId { get; set; }

        [ForeignKey("SpecialHalqa")]
        public int HalqaId { get; set; }

        public DateTime? AssignedDate { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }

        public DateTime? UnassignedDate { get; set; }

        public int? MovedToHalqa { get; set; }
        public DateTime? MovedDate { get; set; }

        public int? AssignedBy { get; set; }
        public DateTime? LastUpdated { get; set; }

        public SpecialStudent Student { get; set; }
        public SpecialHalqa Halqa { get; set; }
    }
}
