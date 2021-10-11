using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCashAdvanceApp.Domain.Models
{
  public   class EmployeeDetails
    {
        public EmployeeDetails()
        {
            Id = Guid.NewGuid().ToString();
            IsApproved = false;
        }
        [Key]
        public string Id { get; set; }
        [StringLength(300)]
        public string  Name{ get; set; }
        
        
        
        [StringLength(300)]
        public string  Email { get; set; }

        public string Amount { get; set; }
        public bool IsApproved { get; set; }
        
        public Department Departments { get; set; }

    }
}
