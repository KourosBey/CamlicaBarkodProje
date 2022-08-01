using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repositories
{
    public class LogCallRepository : IGenericDal<LogCall>
    {
        public void Delete(LogCall t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }

        public LogCall GetByID(int id)
        {
            using var c = new Context();
            return c.Set<LogCall>().Find(id)!;
        }

        public List<LogCall> GetListAll()
        {
            using var c = new Context();
            return c.Set<LogCall>().ToList();
        }

   

        public void Insert(LogCall t)
        {
            using var c = new Context();
            c.Add(t);
            c.SaveChanges();
        }

        public void Update(LogCall t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();
        }

       
    }
}
