using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCashAdvanceApp.Domain.Shared.Constants
{
    public class Constants
    {
        public static string DB_CONNECTION => Settings.Get("DbConnection");

    }
}