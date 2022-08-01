using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public String? CustomerName { get; set; }
        public String? CustomerAdress { get; set; }
        public String? CustomerNumber { get; set; }

       
    }
}
