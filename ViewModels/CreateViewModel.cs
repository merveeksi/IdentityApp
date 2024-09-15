using System.ComponentModel.DataAnnotations;

namespace IdentityApp.ViewModels;

public class CreateViewModel
{
    [Required]
    public string FullName { get; set; } = string.Empty; 
       
    [Required]
    public string UserName { get; set; } = string.Empty; 
    
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
    
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Parola eşleşmiyor.")] //karşılaştırma yapar
    public string ConfirmPassword { get; set; } = string.Empty;
}