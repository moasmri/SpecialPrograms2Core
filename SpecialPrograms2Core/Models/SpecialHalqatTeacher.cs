using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SpecialProgramsCore.Models
{
    public class SpecialHalqatTeacher
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int TeacherId { get; set; }

        [ForeignKey("SpecialHalqa")]
        public int HalqaId { get; set; }

        public DateTime? AssignedDate { get; set; }
        public int? AssignedBy { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }

        public DateTime? UnassignedDate { get; set; }

        public SpecialHalqa Halqa { get; set; }
    }
}
