using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookClub.Web.Models;
using BookClub.Core.Enums;
using BookClub.Data;
using BookClub.Data.Models;

namespace BookClub.Web.Controllers
{
    public class BooksController : BaseController
    {

        protected readonly ApplicationDbContext db;

        public BooksController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Edit()
        {
            var model = new BookEditViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BookEditViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                var newBook = new Book()
                {
                    Author = model.Author,
                    Description = model.Description,
                    Genre = model.Genre,
                    Publisher = model.Publisher,
                    Title = model.Title
                };

                db.Books.Add(newBook);
                await db.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
