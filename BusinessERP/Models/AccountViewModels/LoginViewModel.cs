﻿using System.ComponentModel.DataAnnotations;

namespace BusinessERP.Models.AccountViewModels
{
    public class LoginViewModel
    {
        public string Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
 
        public string TenancyName { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
