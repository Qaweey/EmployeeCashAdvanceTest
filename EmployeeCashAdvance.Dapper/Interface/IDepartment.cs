using EmployeeCashAdvanceApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCashAdvance.Dapper.Interface
{
   public  interface IDepartment
    {
        public Task<IEnumerable<Department>> GetAll();
    }
}
