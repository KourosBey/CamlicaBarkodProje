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
    public class CustomerManager : ICustomerService

    {
        ICustomerDal _jobDal;

        

        public CustomerManager(ICustomerDal
            jobDal)
        {
            _jobDal = jobDal;
        }



        public void Add(Customer job)
        {
            _jobDal.Insert(job);

        }

      

        public Customer GetById(int id)
        {
            return _jobDal.GetByID(id);
        }

        public List<Customer> GetList()
        {
            return _jobDal.GetListAll();
        }


        public void Remove(Customer customer)
        {
            _jobDal?.Delete(customer);
        }

       

        public void Update(Customer customer)
        {
            _jobDal?.Update(customer);
        }

    

   
    }
}
