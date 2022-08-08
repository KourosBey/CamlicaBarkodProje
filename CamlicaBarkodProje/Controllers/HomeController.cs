using BusinessLayer.Concrete;
using CamlicaBarkodProje.Models;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.SharedModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using ef6 = System.Data.Entity;

namespace CamlicaBarkodProje.Controllers
{


    public class HomeController : Controller
    {



        private readonly ILogger<HomeController> _logger;
        LogCallManager lcm = new LogCallManager(new EFLogCallRepository());
        JobManager jm = new JobManager(new EFJobsRepository());
        WorkerManager wm = new WorkerManager(new EFWorkerRepository());
        CustomManager custom = new CustomManager();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize(Roles = "Yönetici")]



        public IActionResult Index(string tarihString)
        {
            List<int> addWorkerID = new List<int>();

            List<SelectListItem> slcList = new List<SelectListItem>();
            slcList.Add(new SelectListItem { Value = "0", Text = "Tümü" });
            slcList.Add(new SelectListItem { Value = "1", Text = "Gün" });
            slcList.Add(new SelectListItem { Value = "2", Text = "Ay" });
            slcList.Add(new SelectListItem { Value = "3", Text = "Yıl" });





            if (tarihString == "" || tarihString == null) { tarihString = "Default"; }

            var tarihliVerideneme = custom.workerStatusWithDate(tarihString);




            ViewBag.tarihliVerideneme = tarihliVerideneme;
            ViewBag.dayNight = slcList;







            return View();
        }
        [Authorize(Roles = "Yönetici")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}