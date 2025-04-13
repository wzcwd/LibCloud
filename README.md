# LibCloud: A Library Management System

## 1. Introduction

The **Library Management System** is an ASP.NET Core MVC project designed to manage books, authors, customers, and library branches. It allows users to perform CRUD (Create, Read, Update, Delete) operations on the library's database. The system uses SQLite as its database and Entity Framework Core for data management.

The system integrates robust authentication features using ASP.NET Core Identity, including user registration, login/logout, and account management. It also supports social media authentication via Google and Facebook, allowing users to sign in with their existing accounts.

## Features

- **Manage Books/Authors/Customers/Library Branches**
- **User Registration and Identity Management**
- **Social Media Authentication (Google, Facebook)**
- **Global Exception Handling**

## Technologies Used

The project is developed using the following technologies:
- **ASP.NET Core MVC 9.0** - Web framework for building the application.
- **Entity Framework Core (EF Core) 9.0.2** - ORM for database interactions.
- **SQLite** - Lightweight relational database.
- **Bootstrap** - Responsive UI design.
- **X.PagedList.Mvc.Core 10.5.7** - Pagination support for the views.
- **Microsoft.AspNetCore.Identity.EntityFrameworkCore 9.0.0** – Identity management.
- **Microsoft.AspNetCore.Authentication.Facebook 9.0.0** – Social network login for Facebook.
- **Microsoft.AspNetCore.Authentication.Google 9.0.0** – Social network login for Google.
- **SendGrid 9.29.3** – Email service for verification code

## 2. Getting Started

1. **Apply Database Migrations:**
   Run the following commands to create new database:
   ```sh
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```
2. **Run the Application:**
   Start the application using the following command: please run the app with https to enable third-party authentication
   ```sh
   dotnet run --launch-profile https
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

## 4. Social Media Authentication Setup

To enable Google and Facebook login, add the following configuration to your `appsettings.Development.json` file:

```json
"Authentication": {
  "Google": {
      "ClientId": "395476307861-8rqmfg3ub34ndggqobpetag3t7d3i7ib.apps.googleusercontent.com",
      "ClientSecret": "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"
  },
  "Facebook": {
      "AppId": "1631978974101896",
      "AppSecret": "401cbd26ea0c31bff3bfef3d0fdc1766" 
  }
}
```
Replace the placeholders with your actual id and secret


Alternatively, You can use the .NET Secret Manager to securely store your credentials during development:

```sh
dotnet user-secrets set "Authentication:Google:ClientId" "<your-client-id>"
dotnet user-secrets set "Authentication:Google:ClientSecret" "<your-client-secret>"
dotnet user-secrets set "Authentication:Facebook:AppId" "<your-app-id>"
dotnet user-secrets set "Authentication:Facebook:AppSecret" "<your-app-secret>"
```

