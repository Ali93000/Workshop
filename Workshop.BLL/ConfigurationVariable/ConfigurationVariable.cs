using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.BLL.ConfigurationVariable
{
    public static class ConfigurationVariable
    {
        public static string APIURL
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("");
            }
        }
    }
}
