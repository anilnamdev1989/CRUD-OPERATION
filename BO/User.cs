using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class User
    {
        [Required(ErrorMessage = "Email  is Required")]
        [RegularExpression(@"^\S+@\S+\.\S+$", ErrorMessage = "Please enter valid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password  is Required")]
        public string Password { get; set; }
    }
}
