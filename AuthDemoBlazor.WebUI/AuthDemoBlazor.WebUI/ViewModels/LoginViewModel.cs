using System.ComponentModel.DataAnnotations;

namespace AuthDemoBlazor.WebUI.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

    }
}
