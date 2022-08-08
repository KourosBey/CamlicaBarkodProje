using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Authority
    {
        [Key]
        public int AuthrorityID   { get; set; }
        public String? AuthorityName  { get; set; }

    }
}
