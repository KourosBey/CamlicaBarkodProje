using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ILogCallService
    {
        void AddLogCall(LogCall LogCall);
        void RemoveLogCall(LogCall LogCall);
        void UpdateLogCall(LogCall LogCall);
        List<LogCall> GetList();
        LogCall GetById(int id);
    }
}
