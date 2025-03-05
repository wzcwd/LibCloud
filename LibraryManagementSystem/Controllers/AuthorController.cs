using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;

namespace LibraryManagementSystem.Controllers;

public class AuthorController(LibraryContext context) : Controller
{
    public IActionResult ListAll(int page = 1, int pageSize = 12)
    {
        var authors = context.Authors
            .OrderBy(a => a.AuthorId)
            .ToList();

        var viewModel = authors.Select(a => new AuthorViewModel
        {
            AuthorId = a.AuthorId,
            AuthorName = a.Name
        }).ToPagedList(page, pageSize);

        ViewData["ActivePage"] = "Author";
        return View("AllAuthors", viewModel);
    }
    
    public IActionResult Search(string searchString, int page = 1, int pageSize = 12)
    {
        // Deal with case transformation
        var searchLower = string.IsNullOrEmpty(searchString) ? "" : searchString.ToLower();
        var author = context.Authors
            .Where(a => a.Name.ToLower().Contains(searchLower))
            .OrderBy(a => a.AuthorId)
            .Select(a=> new AuthorViewModel
            {
                AuthorId = a.AuthorId,
                AuthorName = a.Name
            }).ToPagedList(page, pageSize);
        
        ViewData["ActivePage"] = "Author";
        return View("AllAuthors", author);
    }
    
    
    
    

    public IActionResult Delete(int id)
    {
        var author = context.Authors.Find(id);
        if (author == null)
        {
            return NotFound();
        }

        context.Authors.Remove(author);
        context.SaveChanges();
        ViewData["ActivePage"] = "Author";
        return RedirectToAction("ListAll");
    }

    public IActionResult Edit(int id)
    {
        var author = context.Authors.Find(id);
        ViewData["ActivePage"] = "Author";
        return View("AuthorForm", author);
    }

    public IActionResult Add()
    {
        ViewData["ActivePage"] = "Author";
        return View("AuthorForm", new Author());
    }
    
    
    [HttpPost]
    public IActionResult Save(Author author)
    {
        ViewData["ActivePage"] = "Author";
        if (ModelState.IsValid)
        {
            if (author.AuthorId == 0)
            {
                context.Authors.Add(author);
            }
            else
            {
                context.Authors.Update(author);
            }
            context.SaveChanges();
            return RedirectToAction("ListAll");
        }
        return View("AuthorForm", author);
    }
}