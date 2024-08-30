using System.ComponentModel.DataAnnotations;

namespace IdentityApp.ViewModels;

public class EditViewModel
{
    public string? Id { get; set; }
    public string? FullName { get; set; } = string.Empty; 
    
    [EmailAddress]
    public string? Email { get; set; } = string.Empty;
    
    [DataType(DataType.Password)]
    public string? Password { get; set; } = string.Empty;
    
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Parola eşleşmiyor.")] //karşılaştırma yapar
    public string? ConfirmPassword { get; set; } = string.Empty;
    
}