using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_02_Inhertiance.Models
{
    internal class Employee
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public int? Age { get; set; }

        public string Address { get; set; }
    }
}
