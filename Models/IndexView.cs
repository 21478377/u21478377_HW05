using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw5.Models
{
    public class IndexView
    {
        public long ID { get; set; }
        public Authors Title { get; set; }
        public Books Summary { get; set; }
        public Types Genre { get; set; }

    }
}
