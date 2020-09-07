using BookClub.Core.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookClub.Web.Helpers
{
    public class Dropdowns
    {
        public static IEnumerable<SelectListItem> GetBookGenreDropDown()
        {
            var items = Enum.GetValues(typeof(BookGenre));
            var list = new List<SelectListItem>();
            foreach (BookGenre item in items)
            {
                list.Add(new SelectListItem() { Value = item.ToString(), Text = item.ToString() });
            }
            return list.OrderBy(x => x.Text).ToList();
        }
    }
}
