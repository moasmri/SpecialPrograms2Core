using System.ComponentModel.DataAnnotations;

namespace SpecialPrograms2Core.ViewModels
{
    public class HalqaViewModel
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int ProgramId { get; set; }

        [Required]
        public int SessionTypeId { get; set; }

        [Required]
        public int SessionTimeId { get; set; }

        public string Description { get; set; }

        [Required]
        public int Gender { get; set; }

        public string Status { get; set; }
    }
}