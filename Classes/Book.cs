using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4.Classes
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public Book() { }
        public Book(string _title, Author _author, Publisher _publisher)
        {
            Title = _title;
            Author = _author;
            Publisher = _publisher;
        }
    }
}
