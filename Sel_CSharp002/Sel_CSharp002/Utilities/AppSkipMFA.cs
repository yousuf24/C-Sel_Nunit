using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sel_CSharp002.Utilities
{
    class AppSkipMFA
    {
        public bool IsSkipMFA;
        static IConfiguration config;

        public AppSkipMFA()
        {
            config = new ConfigurationBuilder().AddJsonFile(ProjectConstants.projectAppSettingsFileName).Build();
            if (config.GetSection("appSettings").Exists())
            {
                IsSkipMFA = Convert.ToBoolean(config["appSettings:IsSkipMFA"]);
            }
        }
        public string LoadAppUrl(string Url, bool IsSkipMFA)
        {
            if (config.GetSection("appSettings").Exists())
            {
                Url += config["appSettings:EngageMFA"];
            }
            return Url;
        }
    }
}
