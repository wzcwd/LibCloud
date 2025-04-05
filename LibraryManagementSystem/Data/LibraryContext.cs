using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data;

public class LibraryContext : IdentityDbContext<User>
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<LibraryBranch> LibraryBranch { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seeding initial Data
        modelBuilder.Entity<Author>().HasData(
            new Author { AuthorId = 1, Name = "Charles Dickens" },
            new Author { AuthorId = 2, Name = "Lewis Carroll" },
            new Author { AuthorId = 3, Name = "Agatha Christie" },
            new Author { AuthorId = 4, Name = "J.K. Rowling" },
            new Author { AuthorId = 5, Name = "Paulo Coelho" },
            new Author { AuthorId = 6, Name = "Dan Brown" },
            new Author { AuthorId = 7, Name = "J.D. Salinger" },
            new Author { AuthorId = 8, Name = "Charles Dickens" },
            new Author { AuthorId = 9, Name = "George Eliot" },
            new Author { AuthorId = 10, Name = "F. Scott Fitzgerald" },
            new Author { AuthorId = 11, Name = "Truman Capote" },
            new Author { AuthorId = 12, Name = "Aldous Huxley" },
            new Author { AuthorId = 13, Name = "Fyodor Dostoevsky" },
            new Author { AuthorId = 14, Name = "J.P. Donleavy" },
            new Author { AuthorId = 15, Name = "Johanna Spyri" },
            new Author { AuthorId = 16, Name = "Lucy Maud Montgomery" },
            new Author { AuthorId = 17, Name = "Harper Lee" },
            new Author { AuthorId = 18, Name = "E.B. White" },
            new Author { AuthorId = 19, Name = "Antoine de Saint-Exupéry" },
            new Author { AuthorId = 20, Name = "J.R.R. Tolkien" }
        );
        modelBuilder.Entity<Customer>().HasData(
            new Customer { CustomerId = 1, Name = "John Doe", Email = "john.doe@example.com" },
            new Customer { CustomerId = 2, Name = "Jane Smith", Email = "jane.smith@example.com" },
            new Customer { CustomerId = 3, Name = "Michael Brown", Email = "michael.brown@example.com" },
            new Customer { CustomerId = 4, Name = "Emily Davis", Email = "emily.davis@example.com" },
            new Customer { CustomerId = 5, Name = "David Johnson", Email = "david.johnson@example.com" },
            new Customer { CustomerId = 6, Name = "Sophia Lee", Email = "sophia.lee@example.com" },
            new Customer { CustomerId = 7, Name = "William Harris", Email = "william.harris@example.com" },
            new Customer { CustomerId = 8, Name = "Olivia Clark", Email = "olivia.clark@example.com" },
            new Customer { CustomerId = 9, Name = "James Martinez", Email = "james.martinez@example.com" },
            new Customer { CustomerId = 10, Name = "Ava Rodriguez", Email = "ava.rodriguez@example.com" },
            new Customer { CustomerId = 11, Name = "Liam Wilson", Email = "liam.wilson@example.com" },
            new Customer { CustomerId = 12, Name = "Isabella Anderson", Email = "isabella.anderson@example.com" },
            new Customer { CustomerId = 13, Name = "Benjamin Thomas", Email = "benjamin.thomas@example.com" },
            new Customer { CustomerId = 14, Name = "Charlotte Taylor", Email = "charlotte.taylor@example.com" },
            new Customer { CustomerId = 15, Name = "Ethan Moore", Email = "ethan.moore@example.com" },
            new Customer { CustomerId = 16, Name = "Amelia Jackson", Email = "amelia.jackson@example.com" },
            new Customer { CustomerId = 17, Name = "Alexander White", Email = "alexander.white@example.com" },
            new Customer { CustomerId = 18, Name = "Mia Harris", Email = "mia.harris@example.com" },
            new Customer { CustomerId = 19, Name = "Lucas Martin", Email = "lucas.martin@example.com" },
            new Customer { CustomerId = 20, Name = "Zoe Lee", Email = "zoe.lee@example.com" }
        );

        modelBuilder.Entity<LibraryBranch>().HasData(
            new LibraryBranch { LibraryBranchId = 1, BranchName = "Vancouver Public Library Central Branch" },
            new LibraryBranch { LibraryBranchId = 2, BranchName = "Vancouver Public Library Kitsilano Branch" },
            new LibraryBranch { LibraryBranchId = 3, BranchName = "Vancouver Public Library Mount Pleasant Branch" },
            new LibraryBranch { LibraryBranchId = 4, BranchName = "Vancouver Public Library Renfrew Branch" },
            new LibraryBranch { LibraryBranchId = 5, BranchName = "Vancouver Public Library Dunbar Branch" },
            new LibraryBranch { LibraryBranchId = 6, BranchName = "Vancouver Public Library Kerrisdale Branch" },
            new LibraryBranch { LibraryBranchId = 7, BranchName = "Vancouver Public Library Main Branch" },
            new LibraryBranch { LibraryBranchId = 8, BranchName = "Vancouver Public Library Marpole Branch" },
            new LibraryBranch { LibraryBranchId = 9, BranchName = "Vancouver Public Library Hastings Branch" },
            new LibraryBranch { LibraryBranchId = 10, BranchName = "Vancouver Public Library Collingwood Branch" },
            new LibraryBranch { LibraryBranchId = 11, BranchName = "Vancouver Public Library Point Grey Branch" },
            new LibraryBranch { LibraryBranchId = 12, BranchName = "Vancouver Public Library Fraserview Branch" },
            new LibraryBranch { LibraryBranchId = 13, BranchName = "Vancouver Public Library Strathcona Branch" },
            new LibraryBranch
                { LibraryBranchId = 14, BranchName = "Vancouver Public Library Renfrew-Collingwood Branch" },
            new LibraryBranch { LibraryBranchId = 15, BranchName = "Vancouver Public Library Sunrise Branch" },
            new LibraryBranch { LibraryBranchId = 16, BranchName = "Vancouver Public Library Oakridge Branch" },
            new LibraryBranch { LibraryBranchId = 17, BranchName = "Vancouver Public Library Hastings-Sunrise Branch" },
            new LibraryBranch { LibraryBranchId = 18, BranchName = "Vancouver Public Library South Hill Branch" },
            new LibraryBranch { LibraryBranchId = 19, BranchName = "Vancouver Public Library Renfrew-Branch" },
            new LibraryBranch { LibraryBranchId = 20, BranchName = "Vancouver Public Library Queen Elizabeth Branch" }
        );


        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                BookId = 1, Title = "A Tale of Two Cities", AuthorId = 1, YearPublished = 2024, LibraryBranchId = 1,
                ISBN = "978-3-16-148410-0"
            },
            new Book
            {
                BookId = 2, Title = "Alice's Adventures in Wonderland", AuthorId = 2, YearPublished = 2024,
                LibraryBranchId = 2, ISBN = "978-3-16-148410-1"
            },
            new Book
            {
                BookId = 3, Title = "And Then There Were None", AuthorId = 3, YearPublished = 2023, LibraryBranchId = 3,
                ISBN = "978-3-16-148410-2"
            },
            new Book
            {
                BookId = 4, Title = "Harry Potter and the Philosopher's Stone", AuthorId = 4, YearPublished = 1998,
                LibraryBranchId = 4, ISBN = "978-3-16-148410-3"
            },
            new Book
            {
                BookId = 5, Title = "The Alchemist ", AuthorId = 5, YearPublished = 1996, LibraryBranchId = 5,
                ISBN = "978-3-16-148410-4"
            },
            new Book
            {
                BookId = 6, Title = "The Da Vinci Code", AuthorId = 6, YearPublished = 1997, LibraryBranchId = 6,
                ISBN = "978-3-16-148410-5"
            },
            new Book
            {
                BookId = 7, Title = "The Catcher in the Rye", AuthorId = 7, YearPublished = 2024, LibraryBranchId = 7,
                ISBN = "978-3-16-148410-6"
            },
            new Book
            {
                BookId = 8, Title = "Great Expectations", AuthorId = 8, YearPublished = 2025, LibraryBranchId = 8,
                ISBN = "978-3-16-148410-7"
            },
            new Book
            {
                BookId = 9, Title = "Middlemarch", AuthorId = 9, YearPublished = 2003, LibraryBranchId = 9,
                ISBN = "978-3-16-148410-8"
            },
            new Book
            {
                BookId = 10, Title = "The Great Gatsby", AuthorId = 10, YearPublished = 2008, LibraryBranchId = 10,
                ISBN = "978-3-16-148410-9"
            },
            new Book
            {
                BookId = 11, Title = "Cold Blood ", AuthorId = 11, YearPublished = 2009, LibraryBranchId = 11,
                ISBN = "978-3-16-148410-10"
            },
            new Book
            {
                BookId = 12, Title = "Brave New World ", AuthorId = 12, YearPublished = 2018, LibraryBranchId = 12,
                ISBN = "978-3-16-148410-11"
            },
            new Book
            {
                BookId = 13, Title = "Crime and Punishment", AuthorId = 13, YearPublished = 2013, LibraryBranchId = 13,
                ISBN = "978-3-16-148410-12"
            },
            new Book
            {
                BookId = 14, Title = "The Ginger Man", AuthorId = 14, YearPublished = 2011, LibraryBranchId = 14,
                ISBN = "978-3-16-148410-13"
            },
            new Book
            {
                BookId = 15, Title = "Heidi", AuthorId = 15, YearPublished = 2020, LibraryBranchId = 15,
                ISBN = "978-3-16-148410-14"
            },
            new Book
            {
                BookId = 16, Title = "Anne of Green Gables", AuthorId = 16, YearPublished = 1957, LibraryBranchId = 16,
                ISBN = "978-3-16-148410-15"
            },
            new Book
            {
                BookId = 17, Title = "To Kill a Mockingbird", AuthorId = 17, YearPublished = 1953, LibraryBranchId = 17,
                ISBN = "978-3-16-148410-16"
            },
            new Book
            {
                BookId = 18, Title = "Charlotte's Web", AuthorId = 18, YearPublished = 1830, LibraryBranchId = 18,
                ISBN = "978-3-16-148410-17"
            },
            new Book
            {
                BookId = 19, Title = "The Little Prince ", AuthorId = 19, YearPublished = 1999, LibraryBranchId = 19,
                ISBN = "978-3-16-148410-18"
            },
            new Book
            {
                BookId = 20, Title = "The Hobbit", AuthorId = 20, YearPublished = 2888, LibraryBranchId = 20,
                ISBN = "978-3-16-148410-19"
            }
        );
    }

    public static async Task CreateUser(IServiceProvider serviceProvider)
    {
        UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        String username = "admin";
        String password = "Aa123456";
        String rolename = "Admin";
        String email = "admin@example.com";

        if (await roleManager.FindByNameAsync(rolename) == null)
        {
            await roleManager.CreateAsync(new IdentityRole(rolename));
        }

        if (await userManager.FindByNameAsync(username) == null)
        {
            User user = new User()
            {
                UserName = username,
                Email = email,
                EmailConfirmed = true,
            };
            IdentityResult result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, rolename);
            }
        }
    }
}