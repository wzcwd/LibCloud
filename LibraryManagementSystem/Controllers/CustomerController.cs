using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList.Extensions;

namespace LibraryManagementSystem.Controllers;

[Authorize] 
public class CustomerController(LibraryContext context) : Controller
{
    public IActionResult ListAll(int page = 1, int pageSize = 12)
    {
        var customer = context.Customers
            .AsNoTracking()
            .OrderBy(c => c.CustomerId)
            .Select(c => new CustomerViewModel
            {
                CustomerId = c.CustomerId,
                CustomerName = c.Name,
                Email = c.Email,
            }).ToPagedList(page, pageSize);

        ViewData["ActivePage"] = "Customer";
        return View("AllCustomer", customer);
    }

    public IActionResult Search(string searchString, int page = 1, int pageSize = 12)
    {
            // Deal with case transformation
            var searchLower = string.IsNullOrEmpty(searchString) ? "" : searchString.ToLower();
            var customers = context.Customers
                .Where(c => c.Email.ToLower().Contains(searchLower))
                .OrderBy(c => c.CustomerId)
                .Select(c=> new CustomerViewModel
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.Name,
                    Email = c.Email,
                }).ToPagedList(page, pageSize);
            ViewData["ActivePage"] = "Customer";
            return View("AllCustomer", customers);
    }
    
    
    public IActionResult Add()
    {
        ViewData["ActivePage"] = "Customer";
        return View("CustomerForm", new Customer());
    }

    public IActionResult Edit(int id)
    {
        var customer = context.Customers.Find(id);
        if (customer == null)
        {
            return NotFound();
        }
        ViewData["ActivePage"] = "Customer";
        return View("CustomerForm", customer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var customer = context.Customers.Find(id);
        if (customer == null)
        {
            return NotFound();
        }
        context.Customers.Remove(customer);
        context.SaveChanges();
        ViewData["ActivePage"] = "Customer";
        return RedirectToAction("ListAll");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Save(Customer customer)
    {
        ViewData["ActivePage"] = "Customer";
        if (ModelState.IsValid)
        {
            if (customer.CustomerId == 0)
            {
                context.Customers.Add(customer);
            }
            else
            {
                context.Customers.Update(customer);
            }
            context.SaveChanges();
            return RedirectToAction("ListAll");
        }
        return View("CustomerForm", customer);
    }
    
    
}