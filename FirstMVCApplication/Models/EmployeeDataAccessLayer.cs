using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCApplication.Models
{
    public class EmployeeDataAccessLayer
    {
        string connectionString = "Data Source = PAL-PC; Initial Catalog = EmployeeDB; Integrated Security = true;";

        public IEnumerable<Employee> GetAllEmployees()
        {

        }

    }
}
