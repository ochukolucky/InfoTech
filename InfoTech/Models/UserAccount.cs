using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoTech
{
    public partial class UserAccount
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "username is required")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "password is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "enter your password again")]
        [Display(Name = "Retype password")]
        [DataType(DataType.Password)]
        [NotMapped]
        [Compare("Password", ErrorMessage = "confirmPassword does't match, type again !")]
        public string ConfirmPassword { get; set; }
    }
}
