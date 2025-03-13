using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_02_Inhertiance.Models
{
    internal class FullTimeEmployee : Employee
    {
        public decimal Salary { get; set; }

        public DateTime StartDate { get; set; }
    }
}
