using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSApp.Classes
{
    public class AppSetting
    {
        public static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
        }
    }
}
