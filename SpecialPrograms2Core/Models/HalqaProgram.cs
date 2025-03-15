using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpecialPrograms2Core.Data;

namespace SpecialPrograms2Core.Models
{
    public class HalqaProgram
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string ProgramName { get; set; }

        public bool IsActive { get; set; } = true;
    }
}