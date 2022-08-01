using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Worker
    {
        [Key]
        public int WorkerID { get; set; }
        public String? WorkerName { get; set; }
        public String? Number   { get; set; }
        public String? Username  { get; set; }

        public int AuthorityID { get; set; }
        public Authority? Authority { get; set; }
        public String? Password { get; set; }
        public String? Email { get; set; }
        
  


    }
}
