using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICustomerService 
    {
        void Add(Customer customer);
        void Remove(Customer customer);
        void Update(Customer customer);
        List<Customer> GetList();
        Customer GetById(int id);
    }
}
