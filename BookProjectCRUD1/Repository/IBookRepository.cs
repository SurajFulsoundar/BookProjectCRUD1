using BookProjectCRUD1.Models;

namespace BookProjectCRUD1.Repository
{
    public interface IBookRepository
    {
        int AddBook(Book book);
        IEnumerable<Book> GetBookByTitle(string Author,string SearchBy);
        IEnumerable<Book> GetAllBook();
        int DeleteBook(int id);
        Book GetBookById(int id);
        int updateBook(Book book);
    }
}
