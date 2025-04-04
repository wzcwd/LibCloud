using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    
    [Required(ErrorMessage = "Customer name is required")]
    public string Name { get; set; } = "Unknown Customer";
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email format")] 
    public string Email { get; set; } 

} 