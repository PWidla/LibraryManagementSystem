# Library Management System

This is a simple library management system built using .NET 6. It allows users to manage books, authors, genres, and book listings. The application uses two databases: `Library.db` for the library-related data and `Application.db` for user authentication and authorization.

## Requirements

- .NET 6
- SQLite

## Installation

1. Clone the repository: `git clone https://github.com/PWidla/LibraryManagementSystem.git`
2. Navigate to the project directory: `cd LibraryManagementSystem`
3. Run the migrations:
-dotnet ef migrations add init -context LibraryContext
-dotnet ef migrations add init -context ApplicationDbContext

Initialize the databases: `dotnet ef database update`

4. Run the application

## Configuration

- Connection string: `"Data Source=Library.db"`
- Admin user credentials: `Username: admin@admin.com`, `Password: Test123!`

## User Guide

After running the application, users can navigate to the following URLs to access the different functionalities:

- `/books` - View and manage books
- `/authors` - View and manage authors
- `/genres` - View and manage genres
- `/announcements` - View and manage book announcements
- `/identity/account/login` - Login page
- `/identity/account/register` - Registration page

To access the admin functionalities, log in using the admin credentials. The admin user has access to all the functionalities, while regular users can only view data.
