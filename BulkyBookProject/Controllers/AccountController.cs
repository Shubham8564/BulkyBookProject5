using BulkyBookProject.Model;
using BulkyBookProject.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BulkyBookProject.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _DB;
        public AccountController(ApplicationDbContext DB)
        {
            _DB = DB;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Registration(RegestrationModel obj)
        {
            try
            {
            var val = _DB.Categories.Where(c => c.EmailAddress == obj.EmailAddress).FirstOrDefault();

            if (val != null)
            {
                TempData["EmailAddress"] = "Email Address Already Registered................!";
            }
            else
            {
                Category obje = new Category();
                obje.Name = obj.Name;
                obje.EmailAddress = obj.EmailAddress;
                obje.PhoneNumber = obj.PhoneNumber;
                obje.Gender = obj.Gender;
                obje.Address = obj.Address;
                obje.Password = obj.Password;
                obje.CreatedDateTime = obj.CreatedDateTime;

                
                    if (obj.Id == 0)
                    {
                        _DB.Categories.Add(obje);
                        _DB.SaveChanges();
              
                    }
            }
                TempData["Message"] = "Registration Successfully Completed.....!";
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(RegestrationModel obj)
        {
            //if (obj.EmployeeType == "User")
            //{

                var val = _DB.Categories.Where(c => c.EmailAddress == obj.EmailAddress).FirstOrDefault();

                if (val == null)
                {
                    TempData["Email"] = "Email is Invalid................!";
                }

                else
                {
                    if (val.EmailAddress == obj.EmailAddress && val.Password == obj.Password)
                    {

                        var Claims = new[] { new Claim(ClaimTypes.Name, val.EmailAddress), new Claim(ClaimTypes.Email, val.Password) };
                        var identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            IsPersistent = true
                        };

                        HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(identity),
                            authProperties);
                        TempData.Remove("UserId");
                        TempData.Remove("EmailAdd");

                        TempData["EmailAdd"] = val.EmailAddress;
                        TempData["Id"] = val.Id;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["Password"] = "Password is Invalid................!";
                    }
                }
           // }
           
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(null, null);
            TempData.Remove("UserId");
            TempData.Remove("EmailAdd");
            TempData.Remove("AdminID");
            TempData.Remove("EmailAddress");
            return RedirectToAction("Login");
        }
    }
}
