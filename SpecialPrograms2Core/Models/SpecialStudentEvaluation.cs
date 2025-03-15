using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SpecialPrograms2Core.Models
{
    public class SpecialStudentEvaluation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("SpecialStudent")]
        public int StudentId { get; set; }

        [ForeignKey("SpecialHalqa")]
        public int HalqaId { get; set; }

        [ForeignKey("User")]
        public int TeacherId { get; set; }

        public int StartSurahId { get; set; }
        public int StartAyah { get; set; }
        public int EndSurahId { get; set; }
        public int EndAyah { get; set; }

        public decimal TotalLines { get; set; }
        public decimal TotalPages { get; set; }
        public decimal TotalParts { get; set; }

        public DateTime EvaluationDate { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }

        [Required, MaxLength(20)]
        public string AttendanceStatus { get; set; }

        public byte EvaluationScore { get; set; }
        public int ReviewScore { get; set; }

        [Required, MaxLength(20)]
        public string LessonStatus { get; set; }

        public SpecialStudent Student { get; set; }
        public SpecialHalqa Halqa { get; set; }
    }
}
