using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWorkerService
    {
        void AddWorker(Worker Worker);
        void RemoveWorker(Worker Worker);
        void UpdateWorker(Worker Worker);
        List<Worker> GetList();
        Worker GetById(int id);



    }
}
