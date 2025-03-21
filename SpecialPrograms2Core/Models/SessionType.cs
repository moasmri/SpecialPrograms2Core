﻿using System.ComponentModel.DataAnnotations;

namespace SpecialPrograms2Core.Models
{
    public class SessionType
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string TypeName { get; set; } // (حضورية / عن بعد)

        public bool IsActive { get; set; } = true;
    }
}