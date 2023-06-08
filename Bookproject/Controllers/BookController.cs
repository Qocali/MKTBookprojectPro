using LookProject.DAL;
using LookProject.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Lookproject.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext db;
        public BookController()
        {
            var db =new AppDbContext();
        }

        // GET: Book
        public ActionResult Index()
        {
            var books = db.Books.ToList();
            return View(books);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            var book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            var book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
