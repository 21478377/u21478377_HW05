using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw5.Models
{
    public class Borrows //from borrows table
    {
        public int borrowId { get; set; }
        public int studentId { get; set; }
        public int bookId { get; set; }
        public int takenDate { get; set; }
        public int broughtDate { get; set; }

       
    }
}
