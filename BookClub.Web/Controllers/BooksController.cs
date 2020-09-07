﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookClub.Web.Models;
using BookClub.Core.Enums;

namespace BookClub.Web.Controllers
{
    public class BooksController : BaseController
    {

        public IActionResult Edit()
        {
            var model = new BookEditViewModel() 
            {
                Genres = Helpers.Dropdowns.GetBookGenreDropDown()
            };
            return View(model);
        }

       
    }
}