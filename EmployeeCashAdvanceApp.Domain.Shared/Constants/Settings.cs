using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCashAdvanceApp.Domain.Shared.Constants
{
    public class Settings
    {
        private static Dictionary<string, string> MySettings;

        public static void Initiate(Dictionary<string, string> mySettings) => MySettings = mySettings;

        public static string Get(string key) => MySettings is null ? "" : MySettings.ContainsKey(key) ? MySettings[key] : "";
    }
}
