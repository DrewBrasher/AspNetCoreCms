using System.ComponentModel.DataAnnotations;

namespace AspNetCoreCms.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
