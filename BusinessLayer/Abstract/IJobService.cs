using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IJobService
    {
        void AddJob(Job job);
        void RemoveJob(Job job);
        void UpdateJob(Job job);
        List<Job> GetList();
        Job GetById(int id);
        
    }
}
