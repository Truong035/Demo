using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi1.Models
{
  public  class WikiRequest
    {
        public long id { get; set;}
        public long image { get; set; }
        public bool? active { get; set; }
        public bool? deleted { get; set; }
        public bool? delete_uid { get; set; }
        public bool? delete_date { get; set; }
        public bool? write_uid { get; set; }
        public bool? write_date { get; set; }
        public bool? create_uid { get; set; }
        public bool? create_date { get; set; }
    }
}
