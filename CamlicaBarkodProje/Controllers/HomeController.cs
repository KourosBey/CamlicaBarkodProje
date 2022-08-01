using BusinessLayer.Concrete;
using CamlicaBarkodProje.Models;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.SharedModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CamlicaBarkodProje.Controllers
{
   

    public class HomeController : Controller
    {
       


        private readonly ILogger<HomeController> _logger;
        LogCallManager lcm = new LogCallManager(new EFLogCallRepository());
        JobManager jm = new JobManager(new EFJobsRepository());
        WorkerManager wm = new WorkerManager(new EFWorkerRepository());
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize(Roles = "Yönetici")]
        public IActionResult Index()
        {
            List<int> addWorkerID = new List<int>();
            var values = jm.JobInclude().ToList();
            var workeres = wm.GetList();
            List<JobPoint> wPoint = new List<JobPoint>();
            var perfectSQL = jm.SqlSorgusuJobPoint();


            ViewBag.wPoints = perfectSQL;




            return View(values);
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