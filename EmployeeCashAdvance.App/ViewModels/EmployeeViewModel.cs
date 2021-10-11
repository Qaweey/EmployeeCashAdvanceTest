using EmployeeCashAdvanceApp.Domain.Models;
using EmployeeCashAdvanceApp.Domain.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCashAdvance.App.ViewModels
{
    public class EmployeeCreateViewModel
    {
        [Required(ErrorMessage ="Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage ="Please enter the correct mail format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter the amount ")]
        [ValidAmout(AllowedAmount:50000,ErrorMessage ="Invalid amount, The amount should be less than 50000")]
        public string Amount { get; set; }
       [Required(ErrorMessage ="Please choose your department")]
        public int DepartmentId { get; set; }
    }
}
