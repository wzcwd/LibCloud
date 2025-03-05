using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "LibraryBranches",
                columns: table => new
                {
                    LibraryBranchId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BranchName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryBranches", x => x.LibraryBranchId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false),
                    YearPublished = table.Column<int>(type: "INTEGER", nullable: false),
                    ISBN = table.Column<string>(type: "TEXT", nullable: false),
                    LibraryBranchId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_LibraryBranches_LibraryBranchId",
                        column: x => x.LibraryBranchId,
                        principalTable: "LibraryBranches",
                        principalColumn: "LibraryBranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Name" },
                values: new object[,]
                {
                    { 1, "Charles Dickens" },
                    { 2, "Lewis Carroll" },
                    { 3, "Agatha Christie" },
                    { 4, "J.K. Rowling" },
                    { 5, "Paulo Coelho" },
                    { 6, "Dan Brown" },
                    { 7, "J.D. Salinger" },
                    { 8, "Charles Dickens" },
                    { 9, "George Eliot" },
                    { 10, "F. Scott Fitzgerald" },
                    { 11, "Truman Capote" },
                    { 12, "Aldous Huxley" },
                    { 13, "Fyodor Dostoevsky" },
                    { 14, "J.P. Donleavy" },
                    { 15, "Johanna Spyri" },
                    { 16, "Lucy Maud Montgomery" },
                    { 17, "Harper Lee" },
                    { 18, "E.B. White" },
                    { 19, "Antoine de Saint-Exupéry" },
                    { 20, "J.R.R. Tolkien" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John Doe" },
                    { 2, "jane.smith@example.com", "Jane Smith" },
                    { 3, "michael.brown@example.com", "Michael Brown" },
                    { 4, "emily.davis@example.com", "Emily Davis" },
                    { 5, "david.johnson@example.com", "David Johnson" },
                    { 6, "sophia.lee@example.com", "Sophia Lee" },
                    { 7, "william.harris@example.com", "William Harris" },
                    { 8, "olivia.clark@example.com", "Olivia Clark" },
                    { 9, "james.martinez@example.com", "James Martinez" },
                    { 10, "ava.rodriguez@example.com", "Ava Rodriguez" },
                    { 11, "liam.wilson@example.com", "Liam Wilson" },
                    { 12, "isabella.anderson@example.com", "Isabella Anderson" },
                    { 13, "benjamin.thomas@example.com", "Benjamin Thomas" },
                    { 14, "charlotte.taylor@example.com", "Charlotte Taylor" },
                    { 15, "ethan.moore@example.com", "Ethan Moore" },
                    { 16, "amelia.jackson@example.com", "Amelia Jackson" },
                    { 17, "alexander.white@example.com", "Alexander White" },
                    { 18, "mia.harris@example.com", "Mia Harris" },
                    { 19, "lucas.martin@example.com", "Lucas Martin" },
                    { 20, "zoe.lee@example.com", "Zoe Lee" }
                });

            migrationBuilder.InsertData(
                table: "LibraryBranches",
                columns: new[] { "LibraryBranchId", "BranchName" },
                values: new object[,]
                {
                    { 1, "Vancouver Public Library Central Branch" },
                    { 2, "Vancouver Public Library Kitsilano Branch" },
                    { 3, "Vancouver Public Library Mount Pleasant Branch" },
                    { 4, "Vancouver Public Library Renfrew Branch" },
                    { 5, "Vancouver Public Library Dunbar Branch" },
                    { 6, "Vancouver Public Library Kerrisdale Branch" },
                    { 7, "Vancouver Public Library Main Branch" },
                    { 8, "Vancouver Public Library Marpole Branch" },
                    { 9, "Vancouver Public Library Hastings Branch" },
                    { 10, "Vancouver Public Library Collingwood Branch" },
                    { 11, "Vancouver Public Library Point Grey Branch" },
                    { 12, "Vancouver Public Library Fraserview Branch" },
                    { 13, "Vancouver Public Library Strathcona Branch" },
                    { 14, "Vancouver Public Library Renfrew-Collingwood Branch" },
                    { 15, "Vancouver Public Library Sunrise Branch" },
                    { 16, "Vancouver Public Library Oakridge Branch" },
                    { 17, "Vancouver Public Library Hastings-Sunrise Branch" },
                    { 18, "Vancouver Public Library South Hill Branch" },
                    { 19, "Vancouver Public Library Renfrew-Branch" },
                    { 20, "Vancouver Public Library Queen Elizabeth Branch" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "ISBN", "LibraryBranchId", "Title", "YearPublished" },
                values: new object[,]
                {
                    { 1, 1, "978-3-16-148410-0", 1, "A Tale of Two Cities", 2024 },
                    { 2, 2, "978-3-16-148410-1", 2, "Alice's Adventures in Wonderland", 2024 },
                    { 3, 3, "978-3-16-148410-2", 3, "And Then There Were None", 2023 },
                    { 4, 4, "978-3-16-148410-3", 4, "Harry Potter and the Philosopher's Stone", 1998 },
                    { 5, 5, "978-3-16-148410-4", 5, "The Alchemist ", 1996 },
                    { 6, 6, "978-3-16-148410-5", 6, "The Da Vinci Code", 1997 },
                    { 7, 7, "978-3-16-148410-6", 7, "The Catcher in the Rye", 2024 },
                    { 8, 8, "978-3-16-148410-7", 8, "Great Expectations", 2025 },
                    { 9, 9, "978-3-16-148410-8", 9, "Middlemarch", 2003 },
                    { 10, 10, "978-3-16-148410-9", 10, "The Great Gatsby", 2008 },
                    { 11, 11, "978-3-16-148410-10", 11, "Cold Blood ", 2009 },
                    { 12, 12, "978-3-16-148410-11", 12, "Brave New World ", 2018 },
                    { 13, 13, "978-3-16-148410-12", 13, "Crime and Punishment", 2013 },
                    { 14, 14, "978-3-16-148410-13", 14, "The Ginger Man", 2011 },
                    { 15, 15, "978-3-16-148410-14", 15, "Heidi", 2020 },
                    { 16, 16, "978-3-16-148410-15", 16, "Anne of Green Gables", 1957 },
                    { 17, 17, "978-3-16-148410-16", 17, "To Kill a Mockingbird", 1953 },
                    { 18, 18, "978-3-16-148410-17", 18, "Charlotte's Web", 1830 },
                    { 19, 19, "978-3-16-148410-18", 19, "The Little Prince ", 1999 },
                    { 20, 20, "978-3-16-148410-19", 20, "The Hobbit", 2888 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LibraryBranchId",
                table: "Books",
                column: "LibraryBranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "LibraryBranches");
        }
    }
}
