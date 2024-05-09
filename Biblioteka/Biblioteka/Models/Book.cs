using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Biblioteka.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Name { get; set; }
        public int AuthorID { get; set; }        public virtual Author Author {get; set;}        public string Year { get; set; }        public string Category { get; set; }        public decimal Rating { get; set; }    }
}