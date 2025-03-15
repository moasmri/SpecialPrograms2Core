using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpecialProgramsCore.Models
{
    public class SpecialHalqa
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        // 🔹 المفتاح الخارجي لبرنامج الحلقة
        [ForeignKey("HalqaProgram")]
        public int ProgramId { get; set; }
        public virtual HalqaProgram HalqaProgram { get; set; } // ✅ علاقة الربط

        // 🔹 المفتاح الخارجي لنوع الجلسة
        [ForeignKey("SessionType")]
        public int SessionTypeId { get; set; }
        public virtual SessionType SessionType { get; set; } // ✅ علاقة الربط

        // 🔹 المفتاح الخارجي لوقت الجلسة
        [ForeignKey("SessionTime")]
        public int SessionTimeId { get; set; }
        public virtual SessionTime SessionTime { get; set; } // ✅ علاقة الربط

        public int? UserId { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdated { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Required]
        public int Gender { get; set; }
    }
}
