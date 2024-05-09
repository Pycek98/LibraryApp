using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteka.Models
{
    public interface IAuthorRepository
    {
        Author GetById(int id);
        IEnumerable<Author> GetAll();
        void Add(Author author);
        void Update(Author author);
        void Delete(int id);
        IEnumerable<Book> GetBooksByAuthorId(int authorId);
        void AddBookToAuthor(int authorId, Book book);
        void RemoveBookFromAuthor(int authorId, int bookId);
    }
}