using BookProjectCRUD1.Models;
using BookProjectCRUD1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookProjectCRUD1.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookServices services;

        public BookController(IBookServices services)
        {
            this.services = services;
        }


        // GET: BookController
        public ActionResult Index()
        {
            var res = services.GetAllBook();
            return View(res);
        }
        [HttpPost]
        public ActionResult Index(string SearchText, string SearchBy)
        {
            var books = services.GetBookByTitle(SearchText, SearchBy);
            return View("Index", books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var res = services.GetBookById(id);
            return View(res);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                int res = services.AddBook(book);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            finally
            {
                RedirectToAction(nameof(Index));
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var res = services.GetBookById(id);
            return View(res);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            try
            {
                int res = services.updateBook(book);

                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var res = services.GetBookById(id);
            return View(res);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int res = services.DeleteBook(id);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }

        }
    }
}
