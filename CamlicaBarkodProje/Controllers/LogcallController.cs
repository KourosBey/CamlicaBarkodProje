using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace CamlicaBarkodProje.Controllers
{
    public class LogcallController : Controller
    {
        LogCallManager lcm = new LogCallManager(new EFLogCallRepository());
        WorkerManager wrm = new WorkerManager(new EFWorkerRepository());
        CustomerManager crm = new CustomerManager(new EFCustomerRepository());


        [Authorize(Roles = "Yönetici,Personel")]
        public IActionResult Index()
        {
         


         
            var logcalls = lcm.LogcallInclude("Customer");

            List<SelectListItem> WorkerToLog = (from x in wrm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WorkerName,
                                                    Value = x.WorkerID.ToString()
                                                }).ToList();

            List<SelectListItem> CustomerToLog = (from x in crm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CustomerName,
                                                      Value = x.CustomerID.ToString()
                                                  }).ToList();
            ViewBag.wr = WorkerToLog;
            ViewBag.cr = CustomerToLog;

            return View(logcalls);
        }
        [Authorize(Roles = "Yönetici,Personel")]
        [HttpGet]
        public IActionResult LogsAdd()
        {
            var logcalls = lcm.LogcallInclude("Customer");
            List<SelectListItem> WorkerToLog = (from x in wrm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WorkerName,
                                                    Value = x.WorkerID.ToString()
                                                }).ToList();

            List<SelectListItem> CustomerToLog = (from x in crm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CustomerName,
                                                      Value = x.CustomerID.ToString()
                                                  }).ToList();



            ViewBag.wr = WorkerToLog;
            ViewBag.cr = CustomerToLog;
            return View();




        }

        [Authorize(Roles = "Yönetici,Personel")]
        [HttpPost]
        public IActionResult LogsAdd(LogCall l)
        {

            l.CreateCallTime = DateTime.Now;
            lcm.AddLogCall(l);

            return RedirectToAction("Index", "LogCall");

        }
        [HttpPost]
        public IActionResult SaveLogs(LogCall l)
        {

            var newJob = lcm.GetById(l.LogCallID);
            newJob.CallInfo = l.CallInfo;
            var w = JsonConvert.SerializeObject(l);
            lcm.UpdateLogCall(newJob);
            return RedirectToAction("Index", "Job");
        }
        [HttpGet]
        public ActionResult DeleteLog(int id)
        {
            var Logz = lcm.GetById(id);
            lcm.RemoveLogCall(Logz);
            
            return RedirectToAction("Index", "Logcall");


        }

        public IActionResult GetLogcallsJson(int id)
        {
            var getJsonID = JsonConvert.SerializeObject(lcm.GetById(id));
            return Json(getJsonID);




        }
        public IActionResult CustomerAdd()
        {         
            return View();
        }
        [HttpPost]
        public IActionResult CustomerAdd(Customer customer)
        {
            var cstm = customer;
            crm.Add(customer);
            return RedirectToAction("Index", "Logcall");


        }
    }
}
