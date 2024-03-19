using BulkyBookProject.Model;
using BulkyBookProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookProject.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _DB;
        public UserController(ApplicationDbContext DB)
        {
            _DB = DB;
        }

        [HttpGet]
        public IActionResult GetDetail(int Id)
        {
            var res=_DB.Categories.Where(a => a.Id == Id).ToList();
            return View(res);
        }


        [HttpGet]
        public IActionResult EditDetail(int Id)
        {
            var data = _DB.Categories.Where(a => a.Id == Id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult EditDetail(Category obj)
        {
            _DB.Categories.Update(obj);
            _DB.SaveChanges();
            TempData["Message"] = "User Details Update Successfully....!";
            return RedirectToAction("GetDetail", "User" ,new { Id = obj.Id });
        }
    }
}
