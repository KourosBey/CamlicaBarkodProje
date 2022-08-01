using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.SharedModels;

namespace DataAccesLayer.Abstract
{
    public interface IJobDal : IGenericDal<Job>
    {
        public List<Job> IncludeAll();
       
    }
}
