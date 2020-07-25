using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationZucc.Data.Entities
{
    public class Stream
    {
        public long StreamId { get; set; }
        public string Name { get; set; }
        public string StreamCode { get; set; }
        public bool IsActive { get; set; }
    }
}
