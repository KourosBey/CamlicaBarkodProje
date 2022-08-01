using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using CamlicaBarkodProje.Models;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace CamlicaBarkodProje.Controllers
{
    public class JobController : Controller
    {

        JobManager jm = new JobManager(new EFJobsRepository());
        LogCallManager lcm = new LogCallManager(new EFLogCallRepository());

        [Authorize(Roles="Yönetici,Personel")]
        public ActionResult Index()
        {
            List<SelectListItem> LogCalltoJob = (from x in lcm.GetList().Where(x => x.IsJob == false)
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CallInfo,
                                                     Value = x.LogCallID.ToString()
                                                 }).ToList();

            ViewBag.cv = LogCalltoJob;
            var values = jm.JobInclude();
            
            return View(values);
            
            
            
        }
        [Authorize(Roles = "Yönetici,Personel")]
        [HttpGet]

        public ActionResult Index( Job jobGet)




        {

            List<SelectListItem> LogCalltoJob = (from x in lcm.GetList().Where(x => x.IsJob == false)
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CallInfo,
                                                     Value = x.LogCallID.ToString()
                                                 }).ToList();

            ViewBag.cv = LogCalltoJob;

            if (jobGet.LogCallID==0)
            {
                var valuez = jm.JobInclude();

                return View(valuez);

            }
           // Logcall çekilmesi ve bunun aktarılması gerekiyor araştır. Viewbag - Tempdata - viewdata kontrol et
            IEnumerable<Job> values;
            
            if (jobGet.JobID !=0 && jm.GetById(jobGet.JobID)!= null )
            {
                
                values = jm.GetList().Where(x => x.JobID == jobGet.JobID || x.LogCallID == jobGet.LogCallID || jobGet.Emergency==x.Emergency  );
                if (values != null)
                {
                    JobLogcall model = new JobLogcall();
                    ViewBag.sv = values;
                    model.Jobs = values;
                }
            }
           
            else
            {
             
                    JobLogcall model = new JobLogcall();
                    values = jm.GetList();
                if (values == null) { 
                    model.Jobs = values;
                    model.Logs = lcm.GetList();
                    }
                
            }

            return View(values);

        }
        [Authorize(Roles = "Yönetici,Personel")]
        [HttpPost]
        public ActionResult Save(Job job)
        {
            job.UpdatedDay = DateTime.Now;
            jm.UpdateJob(job);
            
            return RedirectToAction("Index","Job");


        }
         public IActionResult SaveJsonJob ( Job job)
        {
            var newJob = jm.GetById(job.JobID); 
            
            newJob.UpdatedDay = DateTime.Now;
            newJob.CurrentStatus = job.CurrentStatus;
            newJob.Solution = job.Solution;
            newJob.JobDescription = job.JobDescription;
            var w = JsonConvert.SerializeObject(job);
            jm.UpdateJob(newJob);
          
            return RedirectToAction("Index", "Job");

        }
        

        [Authorize(Roles = "Yönetici,Personel")]
        public ActionResult Edit(int id)
        {
            var job = jm.GetById(id);

            return View(job);

        }
        [Authorize(Roles = "Yönetici,Personel")]
        public ActionResult Create(Job createJob)
        {
            if (createJob == null)
                return RedirectToAction("Index", "Job");
            else
                jm.AddJob(createJob);

            return RedirectToAction("Index", "Job");
        }
        [Authorize(Roles = "Yönetici,Personel")]
        public PartialViewResult Getjob()
        {
            return PartialView();

        }
        [Authorize(Roles = "Yönetici,Personel")]
        [HttpGet]
      
        public ActionResult Delete( int id)
        {
        var valu=lcm.GetById(jm.GetById(id).LogCallID);
           
            valu.IsJob = false;
            lcm.UpdateLogCall(valu);
            jm.RemoveJob(jm.GetById(id));
           

            return RedirectToAction("Index", "Job");
        }
        [Authorize(Roles = "Yönetici,Personel")]
        [HttpGet]
        public PartialViewResult JobList()
        {

            List<LogCall> logs = lcm.GetList().Where(x => (x.IsJob) == true).ToList();
            ViewBag.logs = logs;

            return PartialView();
        }
        [Authorize(Roles = "Yönetici,Personel")]
        [HttpGet]
        public ActionResult JobAdd()
        {
         

            List<SelectListItem> LogCalltoJob = (from x in  lcm.GetList().Where(x => x.IsJob == false )
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CallInfo,
                                                     Value = x.LogCallID.ToString()
                                                 }).ToList();

            ViewBag.cv = LogCalltoJob;

            return View();
        }
        [Authorize(Roles = "Yönetici,Personel")]
        [HttpPost]
        public IActionResult JobAdd(Job x)
        {
           
            try
            {
                x.CreatedDay = DateTime.Now;
                x.UpdatedDay = DateTime.Now;
                
                LogCall ourLogcall = lcm.GetById(x.LogCallID);
                ourLogcall.IsJob = true;
                lcm.UpdateLogCall(ourLogcall);

                List<SelectListItem> LogCalltoJob = (from z in lcm.GetList().Where(z => z.IsJob == false)
                                                     select new SelectListItem
                                                     {
                                                         Text = z.CallInfo,
                                                         Value = z.LogCallID.ToString()
                                                     }).ToList();

                ViewBag.cv = LogCalltoJob;


                jm.AddJob(x);


                return RedirectToAction("Index", "Job");
            }
            catch (NullReferenceException e) { throw e; }
           
            
           

           
        }

        public IActionResult GetJsonData()
        {
            var jsonJobData = JsonConvert.SerializeObject(jm.GetList());

            return Json(jsonJobData);
        }
      
        public IActionResult GetByIDJsonJob(int id)
        {
            var getJsonID = JsonConvert.SerializeObject(jm.GetById(id));
            return Json(getJsonID);


        }

       

    }
    }
