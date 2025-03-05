using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models;

public class LibraryBranch
{
    [Key]
    public int LibraryBranchId { get; set; }
    
    [Required(ErrorMessage = "Branch name is required")]
    public string BranchName { get; set; }

}