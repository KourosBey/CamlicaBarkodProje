using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WorkerManager : IWorkerService
    {
        IWorkerDal _WorkerDal;
        public WorkerManager(IWorkerDal WorkerDal)
        {
            _WorkerDal = WorkerDal;
        }



        public void AddWorker(Worker Worker)
        {
            _WorkerDal.Insert(Worker);

        }

        public Worker GetById(int id)
        {
            return _WorkerDal.GetByID(id);
        }

        public List<Worker> GetList()
        {
            return _WorkerDal.GetListAll();
        }

        
        public void RemoveWorker(Worker Worker)
        {
            _WorkerDal?.Delete(Worker);
        }

        public void UpdateWorker(Worker Worker)
        {
            _WorkerDal?.Update(Worker);
        }

        
    }
}
