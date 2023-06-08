using LookProject.DAL;
using LookProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Lookproject.Controllers
{
    public class StoreController : Controller
    {
        private readonly AppDbContext _dbContext;
       public StoreController(AppDbContext dbContext)
        {
            var _dbContext = new AppDbContext();
        }

        // GET: Book
        public ActionResult Index()
        {
            var Stores = _dbContext.Stores.ToList();
            return View(Stores);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            ViewBag.Books = new MultiSelectList(_dbContext.Books, "Id", "Name");
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Store store, int[] bookid)
        {
            if (ModelState.IsValid)
            {
                var listbook=new List<BookStore>();
               foreach(var i in bookid)
                {
                    listbook.Add(_dbContext.BookStore.FirstOrDefault(x => x.Id == bookid[i]));
                }
                store.Book = listbook;
                _dbContext.Stores.Add(store);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(store);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            var story = _dbContext.Stores.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }

            return View(story);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(Store store)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Stores.Add(store);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(store);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            var store = _dbContext.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }

            return View(store);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("DeleteConfirm")]
        public ActionResult DeleteConfirm(int id)
        {
            var store = _dbContext.Stores.Find(id);
            _dbContext.Stores.Remove(store);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }
    }
}
