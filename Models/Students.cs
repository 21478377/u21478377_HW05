using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw5.Models
{
    public class Students //from student table
    {
        public int studentId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int point { get; set; }
        public int birthdate { get; set; }
        public string gender { get; set; }
        public string Class{ get; set;}

        //change below back
        //public string class { get;set;}


    }
}
