# Luke's Library Management System

## 1. Introduction

The **Library Management System** is an ASP.NET Core MVC project designed to manage books, authors, customers, and library branches. It allows users to perform CRUD (Create, Read, Update, Delete) operations on the library's database. The system uses SQLite as its database and Entity Framework Core for data management.

## Features

- **Manage Books**
- **Manage Authors**
- **Manage Customers**
- **Manage Library Branches**

## Technologies Used

The project is developed using the following technologies:

- **ASP.NET Core MVC 9.0** - Web framework for building the application.
- **Entity Framework Core (EF Core) 9.0.2** - ORM for database interactions.
- **SQLite** - Lightweight relational database.
- **Bootstrap** - Responsive UI design
- **X.PagedList.Mvc.Core 10.5.7** - Pagination support for the views

## 2. Getting Started

1. **Apply Database Migrations:**
   Run the following commands to create new database:
   ```sh
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```
2. **Run the Application:**
   Start the application using the following command:
   ```sh
   dotnet run
   ```
## 3. Updating the Database

If you make changes to the database models, follow these steps:
1. **Add a new migration:**
   ```sh
   dotnet ef migrations add UpdateDatabase
   ```
2. **Apply the migration to update the database:**
   
   ```sh
   dotnet ef database update
   ```
