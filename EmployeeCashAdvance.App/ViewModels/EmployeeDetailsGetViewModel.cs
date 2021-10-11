using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCashAdvance.App.ViewModels
{
    public class EmployeeDetailsGetViewModel
    {
        public string Name { get; set; }


        
       
        public string Email { get; set; }

        public string Amount { get; set; }

        public bool IsApproved { get; set; }
        public string Department { get; set; }
        public string Status
        {
            get
            {
                if (IsApproved == true)
                {
                    return "APPROVED";
                }
                return "NOT APPROVED";
            }
        }
    }
}
