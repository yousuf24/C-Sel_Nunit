using Sel_CSharp002.DnD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sel_CSharp002.TestData.AzureAppConfig
{
    class AppConfigData
    {
        static AppSettingsClient applicationSettings;
        public static string salesforceUrl = "https://ct-wolterskluwer--ctttest.sandbox.lightning.force.com/lightning/page/home";
            //=> GetAppConfigData(AppConfigVariables.Environments.salesforceUrl,AppConfigVariables.Environments.sectionName);
        public static string engageUrl => GetAppConfigData(AppConfigVariables.Environments.engageUrl, AppConfigVariables.Environments.sectionName);
        public static string amazonUrl => GetAppConfigData(AppConfigVariables.Environments.amazonUrl, AppConfigVariables.Environments.sectionName);
        public static string flipkartUrl => GetAppConfigData(AppConfigVariables.Environments.flipkartUrl, AppConfigVariables.Environments.sectionName);

        private static string GetAppConfigData(string variableName,string sectionName)
        {
            applicationSettings = AppSettingsClientConfig.GetClient;
            return applicationSettings.GetAsync(sectionName, variableName).Result;
        }
    }
}
