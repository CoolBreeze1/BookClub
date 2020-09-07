using BookClub.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookClub.Data.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set;}
        public string Author { get; set;}
        public string Description { get; set;}
        public string Publisher { get; set;}
        public BookGenre Genre { get; set;}

    }
}
