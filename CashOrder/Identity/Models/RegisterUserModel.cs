﻿using System.ComponentModel.DataAnnotations;

namespace CashOrder.Identity.Models
{
    public class RegisterUserModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
