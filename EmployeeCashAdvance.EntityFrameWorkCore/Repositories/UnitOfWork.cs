using EmployeeCashAdvanceApp.Contract.Interface;
using EmployeeCashAdvanceApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCashAdvance.EntityFrameWorkCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IGenericRepository<Department> _departments;
        private IGenericRepository<EmployeeDetails> _employeedetails;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<Department> Departments => _departments ??= new GenericRepository<Department>(_context);
        public IGenericRepository<EmployeeDetails> Employeedetails => _employeedetails ??= new GenericRepository<EmployeeDetails>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }

}
