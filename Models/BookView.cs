using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw5.Models
{
    public class BookView
    {
        public long ID { get; set; }
        public Borrows Take { get; set; }
        public Books Read { get; set; }
        public Students Done { get; set; }


    }
}
