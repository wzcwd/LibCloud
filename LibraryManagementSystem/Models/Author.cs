using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models;

public class Author
{
    [Key]
    public int AuthorId { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Exceed the maximum length")]
    [MinLength(1, ErrorMessage = "Author name cannot be empty")]
    public string Name { get; set; } = "Unknown Author";

}