using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_with_ADO_IN_mvcCore.Models
{
    public class Employee
    {
        // [Key]
        public int sr_No { get; set; } = 0;

        public string Emp_name { get; set; } = ""; 

        public string City { get; set; } = "";

        public string Country { get; set; } = "";

        public string Department { get; set; } = "";

        public string flag { get; set; } = "";
    }
}
