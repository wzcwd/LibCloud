using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models.ViewModels.Account;

public class PasswordViewModel
{

    [Required(ErrorMessage = "Current password is required.")]
    [DataType(DataType.Password)]
    public string CurrentPassword { get; set; }


    [Required(ErrorMessage = "New password is required.")]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; }


    [Required(ErrorMessage = "Please confirm the new password.")]
    [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }

    public string? Email { get; set; }
}