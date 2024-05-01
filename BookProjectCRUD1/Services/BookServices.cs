using BookProjectCRUD1.Models;
using BookProjectCRUD1.Repository;

namespace BookProjectCRUD1.Services
{
    public class BookServices : IBookServices
    {
        private readonly IBookRepository repo;

        public BookServices(IBookRepository repo)
        {
            this.repo = repo;
        }
        public int AddBook(Book book)
        {
            return repo.AddBook(book);
        }

        public int DeleteBook(int id)
        {
            return repo.DeleteBook(id);
        }

        public IEnumerable<Book> GetAllBook()
        {
            return repo.GetAllBook();
        }

        public Book GetBookById(int id)
        {
            return repo.GetBookById(id);
        }

        public IEnumerable<Book> GetBookByTitle(string Author, string SearchBy)
        {
            return repo.GetBookByTitle(Author, SearchBy);
        }

        public int updateBook(Book book)
        {
            return repo.updateBook(book);
        }
    }
}
