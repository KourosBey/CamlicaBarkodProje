using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LogCallManager
    {
        ILogCallDal _LogCallDal;
        public LogCallManager(ILogCallDal LogCallDal)
        {
            _LogCallDal = LogCallDal;
        }

        public List<LogCall> LogcallInclude(String p)
        {
            
            return _LogCallDal.IncludeAll();
        }

      

        public void AddLogCall(LogCall LogCall)
        {
            _LogCallDal.Insert(LogCall);

        }

        public LogCall GetById(int id)
        {
            return _LogCallDal.GetByID(id);
        }

        public List<LogCall> GetList()
        {
            return _LogCallDal.GetListAll();
        }

        public void RemoveLogCall(LogCall LogCall)
        {
            _LogCallDal?.Delete(LogCall);
        }

        public void UpdateLogCall(LogCall LogCall)
        {
            _LogCallDal?.Update(LogCall);
        }
    }
}
