using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.Models.ViewModels;

public class BookViewModel
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string AuthorName { get; set; }
    

}
    