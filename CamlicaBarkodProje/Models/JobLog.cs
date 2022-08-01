using EntityLayer.Concrete;

namespace CamlicaBarkodProje.Models
{
    public class JobLogcall
    {
       public IEnumerable<Job>? Jobs { get; set; }
       public IEnumerable<LogCall>? Logs { get; set; }

    }
}
