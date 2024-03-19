using BulkyBookProject.Model;
using BulkyBookProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookProject.Controllers
{
    [Authorize]
    public class ManageBookController : Controller
    {

        private readonly ApplicationDbContext _DB;
        public ManageBookController(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        [HttpGet]
        public IActionResult AddBook(int Id)
        {
            TempData["UserId"]=Id;
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(BookModel obj)
        {
            _DB.Books.Add(obj);
            _DB.SaveChanges();
            TempData["Message"] = "Book Details Added Successfully....!";
            return RedirectToAction("BookDetail", "ManageBook", new { Id = obj.UserId });
        }

        [HttpGet]
        public IActionResult BookDetail(int Id) 
        {
            var res = _DB.Books.Where(a => a.UserId == Id).ToList();
            return View(res);
        }

        [HttpGet]
        public IActionResult EditBook(int? BookId)
        {
            var res = _DB.Books.Where(a => a.BookId == BookId).FirstOrDefault();
            return View(res);
        }

        [HttpPost]
        public IActionResult EditBook(BookModel obj)
        {
            _DB.Books.Update(obj);
            _DB.SaveChanges();
            TempData["Message"] = "Book Details Update Successfully....!";
            return RedirectToAction("BookDetail", "ManageBook", new { Id = obj.UserId });
        }

        [HttpGet]
        public IActionResult DeleteBook(int BookId,int UserId)
        {
            var rese = _DB.Books.Where(a => a.BookId == BookId).First();
            _DB.Books.Remove(rese);
            _DB.SaveChanges();
            TempData["Message"] = "Book Details Deleted Successfully....!";
            return RedirectToAction("BookDetail", "ManageBook", new { Id = UserId });
        }
    }
}
