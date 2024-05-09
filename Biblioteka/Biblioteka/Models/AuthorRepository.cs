using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _dbContext;

        public AuthorRepository(LibraryDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public void Add(Author author)
        {
            _dbContext.Authors.Add(author);
        }

        public void AddBookToAuthor(int authorId, Book book)
        {
            var author = _dbContext.Authors.FirstOrDefault(a => a.AuthorID == authorId);
            if (author != null) 
            {
                author.Books.Add(book);
            }
        }

        public void Delete(int id)
        {
            var authorToDelete = _dbContext.Authors.FirstOrDefault(a => a.AuthorID == id);
            if (authorToDelete != null) 
            {
                _dbContext.Authors.Remove(authorToDelete);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Author> GetAll()
        {
            return _dbContext.Authors.ToList();
        }

        public IEnumerable<Book> GetBooksByAuthorId(int authorId)
        {
            return _dbContext.Authors
                .Where(a => a.AuthorID == authorId)
                .SelectMany(a => a.Books)
                .ToList();
        }

        public Author GetById(int id)
        {
            return _dbContext.Authors.FirstOrDefault(a => a.AuthorID == id);
        }

        public void RemoveBookFromAuthor(int authorId, int bookId)
        {
            var author = _dbContext.Authors.FirstOrDefault(a => a.AuthorID == authorId);

            if (author != null) 
            {
                var bookToRemoveFromAuthor = author.Books.FirstOrDefault(b => b.BookID == bookId);
                if (bookToRemoveFromAuthor != null) 
                { 
                    author.Books.Remove(bookToRemoveFromAuthor);
                    _dbContext.SaveChanges();
                }
            }
        }

        public void Update(Author author)
        {
            var existingAuthor = _dbContext.Authors.FirstOrDefault(a => a.AuthorID == author.AuthorID);
            if (existingAuthor != null) 
            {
                //Przykład
                existingAuthor.Surname = author.Surname;
                _dbContext.SaveChanges();
            }
        }
    }
}