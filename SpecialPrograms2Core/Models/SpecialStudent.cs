using System.ComponentModel.DataAnnotations;

namespace SpecialProgramsCore.Models
{
    public class SpecialStudent
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [Required, MaxLength(15)]
        public string GuardianPhone { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdated { get; set; }

        [Required, MaxLength(10)]
        public string Gender { get; set; }
    }
}
