﻿using System.ComponentModel.DataAnnotations;

namespace SpecialPrograms2Core.Models
{
    public class SessionTime
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string TimeName { get; set; } // (فجر / ظهر / عصر / مغرب / عشاء)

        public bool IsActive { get; set; } = true;
    }

}
