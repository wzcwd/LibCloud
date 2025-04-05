using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList.Extensions;

namespace LibraryManagementSystem.Controllers;

[Authorize] 
public class BookController(LibraryContext context) : Controller
{
    public IActionResult ListAll(int page = 1, int pageSize = 13)
    {
        var books = context.Books
            .Include(b => b.Author)
            .Include(b => b.LibraryBranch)
            .OrderBy(b => b.BookId)
            .ToList();

        var viewModel = books.Select(b => new BookViewModel
        {
            BookId = b.BookId,
            Title = b.Title,
            AuthorName = b.Author.Name,
        }).ToPagedList(page, pageSize);

        ViewData["ActivePage"] = "Book";
        return View("AllBooks", viewModel);
    }

    public IActionResult Details(int id)
    {
        var book = context.Books
            .Include(b => b.Author)
            .Include(b => b.LibraryBranch)
            .FirstOrDefault(b => b.BookId == id);
        ViewData["ActivePage"] = "Book";
        return View("Details", book);
    }

    public IActionResult Add()
    {
        var book = new Book(); // empty Object
        var libraryBranch = context.LibraryBranch.ToList();
        ViewBag.LibraryBranch = new SelectList(libraryBranch, "LibraryBranchId", "BranchName");
        ViewData["ActivePage"] = "Book";
        return View("BookForm", book);
    }

    public IActionResult Edit(int id)
    {
        var book = context.Books
            .Include(b => b.Author)
            .Include(b => b.LibraryBranch)
            .FirstOrDefault(b => b.BookId == id);

        if (book == null)
        {
            return NotFound();
        }

        var libraryBranch = context.LibraryBranch.ToList();
        ViewBag.LibraryBranch = new SelectList(libraryBranch,
            "LibraryBranchId", "BranchName", book.LibraryBranchId);
        ViewData["ActivePage"] = "Book";
        return View("BookForm", book);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var book = context.Books.Find(id);
        if (book == null)
        {
            return NotFound();
        }

        context.Books.Remove(book);
        context.SaveChanges();
        ViewData["ActivePage"] = "Book";
        return RedirectToAction("ListAll");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Save(Book book)
    {
        ViewData["ActivePage"] = "Book";
        // check if the AuthorId exists 
        if (!context.Authors.Any(a => a.AuthorId == book.AuthorId))
        {
            ModelState.AddModelError("AuthorId", "The AuthorId does not exist.");
            return View("BookForm", book); 
        }
        
        if (ModelState.IsValid)
        {
            if (book.BookId == 0) // add new book
            {
                context.Books.Add(book);
            }
            else // update book
            {
                context.Books.Update(book);
            }

            context.SaveChanges();
            return RedirectToAction("ListAll");
        }

        return View("BookForm", book);
    }
}