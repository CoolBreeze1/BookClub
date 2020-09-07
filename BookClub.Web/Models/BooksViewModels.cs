using BookClub.Core.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BookClub.Web.Models
{
    public class BookEditViewModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int GenreId { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }
    }
}
