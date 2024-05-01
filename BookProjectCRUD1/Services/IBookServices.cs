using BookProjectCRUD1.Models;

namespace BookProjectCRUD1.Services
{
    public interface IBookServices
    {
        int AddBook(Book book);
        IEnumerable<Book> GetBookByTitle(string Author, string SearchBy);
        IEnumerable<Book> GetAllBook();
        int DeleteBook(int id);
        Book GetBookById(int id);
        int updateBook(Book book);
    }
}
