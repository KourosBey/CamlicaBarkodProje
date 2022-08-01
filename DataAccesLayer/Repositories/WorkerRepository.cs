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
    public class WorkerRepository : IWorkerDal
    {
        Context c = new Context();
        public void AddWorker(Worker worker)
        { using var c = new Context();
            c.Add(worker);
            c.SaveChanges();
        }

        public void Delete(Worker t)
        {
            throw new NotImplementedException();
        }

        public void DeleteWorker(Worker worker)
        {
            c.Remove(worker);
            c.SaveChanges();
        }

        public Worker? getByID(int? id)
        {
            return c.Worker?.Find(id);
        }

        public Worker GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Worker> GetListAll()
        {
            throw new NotImplementedException();
        }

        public List<Worker> Include(string p)
        {
            using var c = new Context();
            return c.Set<Worker>().Include(p).ToList();
        }

        public void Insert(Worker t)
        {
            throw new NotImplementedException();
        }

        public List<Worker> ListAllWorker()
        {
            using var c = new Context();
            return c.Worker.ToList();
        }

        public void Update(Worker t)
        {
            throw new NotImplementedException();
        }

        public void UpdateWorker(Worker worker)
        {
            using var c = new Context();
            c.Update(worker);
            c.SaveChanges();
        }
    }
}
