using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList.Extensions;

namespace LibraryManagementSystem.Controllers;

[Authorize] 
public class LibraryBranchController(LibraryContext context) : Controller
{
    public IActionResult ListAll(int page = 1, int pageSize = 13)
    {
        var branch = context.LibraryBranch
            .AsNoTracking()
            .OrderBy(b=>b.LibraryBranchId)
            .Select(b => new LibraryBranchViewModel {
            LibraryBranchId = b.LibraryBranchId,
            BranchName = b.BranchName,
        }).ToPagedList(page, pageSize);

        ViewData["ActivePage"] = "Branch";
        return View("AllBranches", branch);
    }
    public IActionResult Add()
    {
        ViewData["ActivePage"] = "Branch";
        return View("BranchForm", new LibraryBranch());
    }

    public IActionResult Edit(int id)
    {
        var branch = context.LibraryBranch.Find(id);
        if (branch == null)
        {
            return NotFound();
        }
        ViewData["ActivePage"] = "Branch";
        return View("BranchForm", branch);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var branch = context.LibraryBranch.Find(id);
        if (branch == null)
        {
            return NotFound();
        }
        context.LibraryBranch.Remove(branch);
        context.SaveChanges();
        ViewData["ActivePage"] = "Branch";
        return RedirectToAction(nameof(ListAll));
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Save(LibraryBranch branch)
    {
        ViewData["ActivePage"] = "Branch";
        if (ModelState.IsValid) 
        {
            if (branch.LibraryBranchId == 0) 
            {
                context.LibraryBranch.Add(branch); 
            }
            else
            {
                context.LibraryBranch.Update(branch);
            }
            context.SaveChanges();
            return RedirectToAction(nameof(ListAll));
        }
        return View("BranchForm", branch);
    }
    
    
    
}