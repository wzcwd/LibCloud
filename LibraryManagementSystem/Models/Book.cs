using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models;

public class Book
{
    [Key]
    public int BookId { get; set; }
    
    [Required(ErrorMessage = "Title is required")]
    [StringLength(100, ErrorMessage = "Exceed the maximum length")]
    public string Title { get; set; } = "Unknown Title";
    
    [Required(ErrorMessage = "Author is required")]
    public int AuthorId { get; set; }
    
    [Range(1000, 9999, ErrorMessage = "Illegal year input")]
    public int YearPublished { get; set; } 
    
    [Required(ErrorMessage = "ISBN is required")]
    public string ISBN { get; set; } 
    
    [Required(ErrorMessage = "Library branch is required")]
    public int LibraryBranchId { get; set; }
    
    public virtual LibraryBranch? LibraryBranch { get; set; }
    
    public virtual Author? Author { get; set; }

}