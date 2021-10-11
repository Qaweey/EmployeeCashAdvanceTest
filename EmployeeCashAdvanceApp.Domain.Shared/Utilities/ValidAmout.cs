using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCashAdvanceApp.Domain.Shared.Utilities
{
    public class ValidAmoutAttribute:ValidationAttribute
    {
        private readonly double allowedAmount;

        public ValidAmoutAttribute(double AllowedAmount)
        {
            allowedAmount = AllowedAmount;
        }
        public override bool IsValid(object value)
        {
            var stringval = value.ToString();
            var val = double.Parse(stringval);
            return  val<allowedAmount;
        }
    }
}
