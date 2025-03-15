using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SpecialProgramsCore.Models
{
    public class HalqaAuditLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int HalqaId { get; set; }

        [Required, MaxLength(50)]
        public string ActionType { get; set; } // (إنشاء، تعديل، حذف، تغيير حالة)

        [Required]
        public int PerformedBy { get; set; }

        [Required]
        public DateTime ActionDate { get; set; }

        [ForeignKey("HalqaId")]
        public virtual SpecialHalqa SpecialHalqa { get; set; }
    }
}
