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
    public class AuthorsController : Controller
    {
        private readonly LibraryContext _context;

        public AuthorsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Authors
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["LastNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "lastname_desc" : "";
            ViewData["FirstNameSortParm"] = sortOrder == "FirstName" ? "firstname_desc" : "FirstName";
            var authors = from a in _context.Authors
                           select a;
            switch (sortOrder)
            {
                case "lastname_desc":
                    authors = authors.OrderByDescending(a => a.LastName);
                    break;
                case "FirstName":
                    authors = authors.OrderBy(a => a.FirstName);
                    break;
                case "firstname_desc":
                    authors = authors.OrderByDescending(s => s.FirstName);
                    break;
                default:
                    authors = authors.OrderBy(s => s.LastName);
                    break;
            }
            return View(await authors.AsNoTracking().ToListAsync());
        }


        // GET: Authors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .FirstOrDefaultAsync(m => m.ID == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // GET: Authors/Create
        [Authorize(Policy = "RequireAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [Authorize(Policy = "RequireAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName")] Author author)
        {
            if (_context.Authors.Any(g => g.FirstName == author.FirstName && g.LastName == author.LastName))
            {
                ModelState.AddModelError("LastName", "An author with this data already exists");
            }

            if (ModelState.IsValid)
            {
                _context.Add(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Edit/5
        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        [Authorize(Policy = "RequireAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName")] Author author)
        {
            if (_context.Authors.Any(g => g.FirstName == author.FirstName && g.LastName == author.LastName && g.ID != author.ID))
            {
                ModelState.AddModelError("LastName", "An author with this data already exists");
            }

            if (id != author.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(author);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists(author.ID))
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
            return View(author);
        }

        // GET: Authors/Delete/5
        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .FirstOrDefaultAsync(m => m.ID == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Authors/Delete/5
        [Authorize(Policy = "RequireAdmin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Authors == null)
            {
                return Problem("Entity set 'LibraryContext.Authors'  is null.");
            }
            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id)
        {
          return _context.Authors.Any(e => e.ID == id);
        }
    }
}
