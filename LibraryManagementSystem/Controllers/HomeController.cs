using System.Diagnostics;
using LibraryManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using X.PagedList.Extensions;

namespace LibraryManagementSystem.Controllers;
[Authorize] 
public class HomeController(LibraryContext context, ILogger<HomeController> logger) : Controller
{

    public IActionResult Index()
    {
        ViewData["ActivePage"] = "Home";
        return View();
    }

    public IActionResult Search(string searchString, string searchBy, int page = 1, int pageSize = 10)
    {
        var books = context.Books.AsQueryable();
        if (!string.IsNullOrEmpty(searchString))
        {
            // Deal with case transformation
            var searchLower = searchString.ToLower();  
            if (searchBy == "book")
            {
                books = books.Where(b => b.Title.ToLower().Contains(searchLower));
            }
            else if (searchBy == "author")
            {
                books = books.Where(b => b.Author.Name.ToLower().Contains(searchLower));
            }
        }
        var pagedBooks = books.Select(b=> new BookViewModel
        {
            BookId = b.BookId,
            Title = b.Title,
            AuthorName = b.Author.Name,
        }).ToPagedList(page, pageSize);
        ViewData["SearchString"] = searchString; // pass keyword to view
        ViewData["ActivePage"] = "Home";
        return View("Index",pagedBooks);
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
        var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        var exceptionMessage = feature?.Error.Message;

        var model = new ErrorViewModel
        {
            RequestId = requestId,
            ExceptionMessage = exceptionMessage,
        };
        return View(model);
    }
    
    public IActionResult HandleStatusCode(int code)
    {
        var viewModel = new ErrorViewModel
        {
            RequestId = HttpContext.TraceIdentifier,
            StatusCode = code
        };
        return View("Error", viewModel); 
    }
}