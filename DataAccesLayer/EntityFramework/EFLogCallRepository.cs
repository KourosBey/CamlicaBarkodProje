using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EFLogCallRepository : LogCallRepository, ILogCallDal
    {

        public List<LogCall> IncludeAll()
        {
            using var c = new Context();
            return c.Set<LogCall>().Include(c => c.Customer).Include(y => y.Worker).ToList();
        }

    }
}
