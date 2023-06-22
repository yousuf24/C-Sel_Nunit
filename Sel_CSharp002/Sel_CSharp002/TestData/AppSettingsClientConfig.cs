using Microsoft.Extensions.Configuration;
using Sel_CSharp002.DnD;
using Sel_CSharp002.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sel_CSharp002.TestData
{
    class AppSettingsClientConfig
    {
        static AppSettingsClient instance = null;
        public static string AppName { get; set; }
        public static AppSettingsClient GetClient
        {
            get
            {
                if (instance == null)
                    instance = Create();
                return instance;
            }
        }
        private static AppSettingsClient Create()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile(ProjectConstants.projectAppSettingsFileName).Build();
            var applicationSettings=new AppSettingsClient(config);

            if (config.GetSection("appSettings").Exists())
            {
                AppName = config["appSettings:appName"];
            }return applicationSettings;
        }
    }
}
