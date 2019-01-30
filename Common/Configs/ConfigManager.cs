using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Configs
{
    public static class ConfigManager
    {
        public static AppSetting GetAppSetting(string key)
        {
            return new AppSetting(ConfigurationManager.AppSettings[key]);
        }
    }
}
