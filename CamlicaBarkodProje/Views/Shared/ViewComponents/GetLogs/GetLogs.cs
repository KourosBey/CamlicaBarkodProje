using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CamlicaBarkodProje.Views.Shared.ViewComponents.GetLogs
{
    [ViewComponent]
    public class GetLogs : ViewComponent
    {
        JobManager jm = new JobManager(new EFJobsRepository());
        LogCallManager lcm = new LogCallManager(new EFLogCallRepository());
        public IViewComponentResult Invoke()
        {
            var logs = lcm.GetList().Where(x => x.IsJob == false);

            return View(logs);
        }

    }

}
