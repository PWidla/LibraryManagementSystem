using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagementSystem.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, bool searchByTitle = false, bool searchByAuthor = false, int? pageNumber)
        {
            var libraryContext = _context.Books.Include(b => b.Author).Include(b => b.Genre);

            ViewData["CurrentSort"] = sortOrder;
            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["YearSortParm"] = sortOrder == "Year" ? "year_release" : "Year";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var books = from b in libraryContext
                        select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();

                if (searchByTitle && searchByAuthor || !searchByTitle && !searchByAuthor)
                {
                    books = books.Where(b => b.Title.ToLower().Equals(searchString) ||
                                              b.Author.FirstName.ToLower().Equals(searchString) ||
                                              b.Author.LastName.ToLower().Equals(searchString));
                }
                else if (searchByTitle)
                {
                    books = books.Where(b => b.Title.ToLower().Equals(searchString));
                }
                else if (searchByAuthor)
                {
                    books = books.Where(b => b.Author.FirstName.ToLower().Equals(searchString) 
                                        || b.Author.LastName.ToLower().Equals(searchString));
                }

            }

            switch (sortOrder)
            {
                case "title_desc":
                    books = books.OrderByDescending(b => b.Title);
                    break;
                case "Year":
                    books = books.OrderBy(b => b.ReleaseYear);
                    break;
                case "year_desc":
                    books = books.OrderByDescending(b => b.ReleaseYear);
                    break;
                default:
                    books = books.OrderBy(b => b.Title);
                    break;
            }

            if (books.Count() == 0)
            {
                ViewBag.Message = "No results.";
            }

            int pageSize = 3;
            return View(await PaginatedList<Book>.CreateAsync(books.AsNoTracking(), pageNumber ?? 1, pageSize));
            //return View(await books.AsNoTracking().ToListAsync());
        }


        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        [Authorize(Policy = "RequireAdmin")]
        public IActionResult Create()
        {
            ViewData["AuthorID"] = new SelectList(_context.Authors, "ID", "FirstName");
            ViewData["GenreID"] = new SelectList(_context.Genres, "ID", "Name");
            return View();
        }

        // POST: Books/Create
        [Authorize(Policy = "RequireAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseYear,IsAvailable,GenreID,AuthorID")] Book book)
        {
            if (_context.Books.Any(g => g.Title == book.Title))
            {
                ModelState.AddModelError("Title", "A book with this title already exists");
            }

            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorID"] = new SelectList(_context.Authors, "ID", "FirstName", book.AuthorID);
            ViewData["GenreID"] = new SelectList(_context.Genres, "ID", "Name", book.GenreID);
            return View(book);
        }

        // GET: Books/Edit/5
        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["AuthorID"] = new SelectList(_context.Authors, "ID", "FirstName", book.AuthorID);
            ViewData["GenreID"] = new SelectList(_context.Genres, "ID", "Name", book.GenreID);
            return View(book);
        }

        // POST: Books/Edit/5
        [Authorize(Policy = "RequireAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseYear,IsAvailable,GenreID,AuthorID")] Book book)
        {
            if (_context.Books.Any(g => g.Title == book.Title && g.ID != book.ID))
            {
                ModelState.AddModelError("Title", "A book with this title already exists");
            }

            if (id != book.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorID"] = new SelectList(_context.Authors, "ID", "FirstName", book.AuthorID);
            ViewData["GenreID"] = new SelectList(_context.Genres, "ID", "Name", book.GenreID);
            return View(book);
        }

        // GET: Books/Delete/5
        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [Authorize(Policy = "RequireAdmin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'LibraryContext.Books'  is null.");
            }
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.ID == id);
        }
    }
}

