using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _dbContext;

        public BookRepository(LibraryDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Book GetById(int id)
        {
            return _dbContext.Books.FirstOrDefault(b => b.BookID == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _dbContext.Books.ToList();
        }

        public void Add(Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }

        public void Update(Book book)
        {
            var existingBook = _dbContext.Books.FirstOrDefault(b => b.BookID == book.BookID);
            if (existingBook != null) 
            {
                //Przykład
                existingBook.Category = book.Category;
                existingBook.Name = book.Name;
                //Zapis
                _dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var bookToDelete = _dbContext.Books.FirstOrDefault(b => b.BookID == id);
            if (bookToDelete != null) 
            {
                _dbContext.Books.Remove(bookToDelete);
                _dbContext.SaveChanges();
            }
        }

    }
}