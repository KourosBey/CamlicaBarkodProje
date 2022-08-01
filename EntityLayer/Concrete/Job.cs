using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Job
    {
        [Key]
        public int JobID { get; set; }
        public String? JobDescription { get; set; }
        public String? Solution { get; set; }
        public String? CurrentStatus { get; set; }
        public bool Emergency { get; set; }
        public int LogCallID { get; set; }
        public LogCall? LogCall { get; set; }

        public DateTime CreatedDay { get; set; }
        public DateTime UpdatedDay { get; set; }
       
       
    }
}
