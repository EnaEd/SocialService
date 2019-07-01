using System.ComponentModel.DataAnnotations;

namespace SocialService.ServiceLogic.ViewModels
{
    public class LoginView
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "RememberMe?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
