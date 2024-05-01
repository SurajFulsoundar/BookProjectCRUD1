using BookProjectCRUD1.Data;
using BookProjectCRUD1.Models;

namespace BookProjectCRUD1.Repository
{
    public class BookRepository : IBookRepository
    {
        ApplicationDbContext db;
        public BookRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddBook(Book book)
        {
            db.Books.Add(book);
            int result = db.SaveChanges();
            return result;
        }

        public int DeleteBook(int id)
        {
            int res = 0;
            var result = db.Books.Where(x => x.Id == id).FirstOrDefault();

            if(result != null)
            {
                db.Books.Remove(result);
                res = db.SaveChanges();
            }
            return res;
        }

        public IEnumerable<Book> GetAllBook()
        {
            return db.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            var res = db.Books.Where(option => option.Id == id).SingleOrDefault();
            return res;
        }

        public IEnumerable<Book> GetBookByTitle(string Author, string SearchBy)
        {
            IEnumerable<Book> result = null;

            if(SearchBy == "Title")
            {
                result = from b in db.Books
                         where b.Title.Contains(Author)
                         select b;
            }
            else if(SearchBy == "Author")
            {
                result = from b in db.Books
                         where b.Author.Contains(Author)
                         select b;
            }
            return result;

        }

        public int updateBook(Book book)
        {
            int res = 0;
            var result = db.Books.Where(option => option.Id == book.Id).FirstOrDefault();
            if(result != null)
            {
                result.Title = book.Title;
                result.Author = book.Author;
                result.PublicationYear = book.PublicationYear;
                res = db.SaveChanges() ;
            }
            return res;
        }
    }
}
