using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KnockoutJSTest.DAL;
using KnockoutJSTest.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;
using KnockoutJSTest.ViewModels;
using KnockoutJSTest.Services;
using KnockoutJSTest.Filters;

namespace KnockoutJSTest.Controllers
{
    public class AuthorsController : Controller
    {
        private AuthorService authorService;

        public AuthorsController()
        {
            authorService = new AuthorService();
            AutoMapper.Mapper.CreateMap<Author, AuthorViewModel>();
        }

        // GET: Authors
        [GenerateResultListFilterAttribute(typeof(Author), typeof(AuthorViewModel))]
        public ActionResult Index([Form] QueryOptions queryOptions)
        {
            var authors = authorService.Get(queryOptions);
            ViewData["QueryOptions"] = queryOptions;
            return View(authors);
        }

        // GET: Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var author = authorService.GetById(id.Value);
            return View(AutoMapper.Mapper.Map<Author, AuthorViewModel>(author));
        }

        // GET: Authors/Details/Jamie Munro
        [Route("Details/{name}")]
        public ActionResult GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var author = authorService.GetByName(name);

            return View(AutoMapper.Mapper.Map<Author, AuthorViewModel>(author));
        }

        // GET: Authors/Create
        [BasicAuthorization]
        public ActionResult Create()
        {
            return View("Form", new AuthorViewModel());
        }

        // GET: Authors/Edit/5
        [BasicAuthorization]
        [Route("Edit/{id:int:min(0)?}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var author = authorService.GetById(id.Value);
            return View("Form", AutoMapper.Mapper.Map<Author, AuthorViewModel>(author));
        }

        // GET: Authors/Delete/5
        [BasicAuthorization]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var author = authorService.GetById(id.Value);
            return View(AutoMapper.Mapper.Map<Author, AuthorViewModel>(author));
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [BasicAuthorization]
        public ActionResult DeleteConfirmed(int id)
        {
            var author = authorService.GetById(id);
            authorService.Delete(author);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                authorService.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
