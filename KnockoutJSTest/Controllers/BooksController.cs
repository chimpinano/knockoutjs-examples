using KnockoutJSTest.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KnockoutJSTest.Controllers
{
    public class BooksController : Controller
    {
        private BookContext db = new BookContext();
        [Route("authors/{id}/books")]
        public ActionResult ByAuthor(int id)
        {
            var books = db.Books.Where(b => b.AuthorId == id);
            return View(books.ToList());
        }
    }
}