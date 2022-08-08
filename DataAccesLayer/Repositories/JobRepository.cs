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
    public class JobRepository : IGenericDal<Job>
    {
        readonly Context c = new();
        public void AddJobs(Job job)
        {
            using (var c = new Context())
            {
                c.Add(job);
                c.SaveChanges();
            }
        }

        public void Delete(Job t)
        {
            throw new NotImplementedException();
        }

        public void DeleteJobs(Job job)
        {
            c.Remove(job);
            c.SaveChanges();
        }

        public Job? getByID(int? id)
        {
            return c.Jobs?.Find(id);
        }

        public Job GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Job> GetListAll()
        {
            using (var c = new Context())
            {
                return c.Jobs.ToList();
            }
        }


        public void Insert(Job t)
        {
            throw new NotImplementedException();
        }



        public void Update(Job t)
        {
            using (var c = new Context())
            {
                c.Update(t);
                c.SaveChanges();
            }
        }



    }
}
