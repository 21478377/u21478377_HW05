using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw5.Models
{
    public class Books //from book table
    {
        public int bookId { get; set; }
        public string name { get; set; }
        public int pagecount { get; set; }
        public int point { get; set; }
        public int authorId { get; set; }
        public int typeId { get; set; }
    }
}
