using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCashAdvanceApp.Domain.Models
{
  public   class Department
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int  DepartmentId { get; set; }
    
        [StringLength(300)]
        public string  DepartmentName { get; set; }
        [StringLength(300)]
        public string  HODName { get; set; }
        [StringLength(300)]
        public string  HODEmail{ get; set; }
        public string Id { get; set; }
        [ForeignKey(nameof(Id))]
        public EmployeeDetails Employeedetails{ get; set; }
    }
}
