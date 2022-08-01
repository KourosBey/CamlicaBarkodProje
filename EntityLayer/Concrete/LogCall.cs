using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class LogCall
    {
        [Key]
        public int LogCallID { get; set; }
        public String? CallInfo { get; set; }
        public DateTime CreateCallTime { get; set; }
        public int CustomerID { get; set; }
        public Customer? Customer { get; set; }

        public int WorkerID { get; set; }
        public Worker? Worker { get; set; }
        public bool IsJob   { get; set; }


    }
}
