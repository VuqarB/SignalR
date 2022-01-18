using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.ViewModel.Account
{
    public class RegisterVM
    {
        [Required, MaxLength(255)]
  
        public string UserName { get; set; }
        [Required, MaxLength(255)]
       
        public string FullName { get; set; }
        [Required,MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required, MaxLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, MaxLength(255)]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Your password and confirm password do not match")]
        public string ConfirmPassword { get; set; }


    }
}
