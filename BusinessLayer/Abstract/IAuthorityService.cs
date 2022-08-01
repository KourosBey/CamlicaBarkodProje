using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthorityService
    {
        void AddAuth(Authority auth);
        void RemoveAuth(Authority auth);
        void UpdateAuth(Authority auth);
        List<Authority> GetList();
        Authority GetById(int id);

        
    }
}
