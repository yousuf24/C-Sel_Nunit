using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Sel_CSharp002.Utilities
{
    class App1
    {
        string AppUrl = string.Empty;
                
        IConfiguration config = new ConfigurationBuilder().AddJsonFile(ProjectConstants.projectAppSettingsFileName).Build();
        public string LoadApp(string appurl)
        {
            if(config.GetSection("appSettings").Exists())
            AppUrl = appurl + config["appSettings:CTCorpUrl"];

            return AppUrl;
        }


    }
}
