using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace CamlicaBarkodProje.Controllers
{
    public class LoginController : Controller
    {
        WorkerManager wm = new WorkerManager(new EFWorkerRepository());
       
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            
            var values = wm.GetList();

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                RedirectToAction("Index","Login");
            }
            ClaimsIdentity? identity = null;
            bool isAuthenticate = false;
            foreach (var value in values)
            {
                if (value.Username == username && value.Password == password)
                {
                    

                        if (value.WorkerID == value.WorkerID && value.AuthorityID == 1)
                        {
                            identity = new ClaimsIdentity(new[]
                            {
                                new Claim(ClaimTypes.Name,username),
                                new Claim(ClaimTypes.Role,"Yönetici")

                            }, CookieAuthenticationDefaults.AuthenticationScheme);
                            isAuthenticate = true;

                            if (isAuthenticate)
                            {

                                

                                var principal = new ClaimsPrincipal(identity);
                                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                                return RedirectToAction("Index", "Job");
                            }

                        }

                        if (value.WorkerID == value.WorkerID && value.AuthorityID == 2)
                        {
                            identity = new ClaimsIdentity(new[]
                            {
                                new Claim(ClaimTypes.Name,username),
                                new Claim(ClaimTypes.Role,"Personel")

                            }, CookieAuthenticationDefaults.AuthenticationScheme);
                            isAuthenticate = true;
                            if (isAuthenticate)
                            {



                                var principal = new ClaimsPrincipal(identity);
                                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                                return RedirectToAction("Index", "Job");
                            }

                        }


                        
                    

                   
                }
          
            }
            return RedirectToAction("Index","Login");
        }
    }
}
