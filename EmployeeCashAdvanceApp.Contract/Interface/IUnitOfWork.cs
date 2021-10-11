using EmployeeCashAdvanceApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCashAdvanceApp.Contract.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Department> Departments { get; }
        IGenericRepository<EmployeeDetails> Employeedetails { get; }
        Task Save();
    }
}
