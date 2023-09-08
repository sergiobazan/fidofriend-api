﻿using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Request
{
    public class UserLogin
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
