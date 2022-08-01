using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using DataAccesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorityManager : IAuthorityService
    {
        IAuthorityDal _authDal;

        public AuthorityManager(IAuthorityDal authDal)
        {
            _authDal = authDal;
        }
        public void AddAuth(Authority auth)
        {
            _authDal.Insert(auth);
        }

       

        public Authority GetById(int id)
        {
            return _authDal.GetByID(id);
        }

        public List<Authority> GetList()
        {
            return _authDal.GetListAll();
        }

        public void RemoveAuth(Authority auth)
        {
            _authDal.Delete(auth);       }

        public void UpdateAuth(Authority auth)
        {
            _authDal.Update(auth); 
        }
    }
}
