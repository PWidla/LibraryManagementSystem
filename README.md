# Library Management System

This is a simple library management system built using .NET 6. It allows users to manage books, authors, genres, and book listings. The application uses two databases: `Library.db` for the library-related data and `Application.db` for user authentication and authorization.

## Requirements

- .NET 6
- SQLite

## Installation

1. Clone the repository: `git clone https://github.com/PWidla/LibraryManagementSystem.git`
2. In Package Manager Console run the migrations:
- Add-Migration add init -context ApplicationDbContext
- Add-Migration init -context LibraryContext

3. Initialize the database: 
- Update-Database update -context ApplicationDbContext`
- Update-Database update -context LibraryContext`

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
