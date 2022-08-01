using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Repositories;
using EntityLayer.Concrete;
using EntityLayer.SharedModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EFJobsRepository : GenericRepository<Job>,IJobDal
    {
        public List<Job> IncludeAll()
        {
             Context c = new Context();
          
            return c.Jobs.Include(c => c.LogCall).ThenInclude(LogCall=>LogCall!.Customer).ToList();
        }
      
    }
}
