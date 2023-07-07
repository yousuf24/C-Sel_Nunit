using Sel_CSharp002.DnD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sel_CSharp002.TestData.AzureKeyVaults
{
    class KeyValutsData
    {
        static AppSettingsClient applicationSettings;


        public static string sftestServiceManagerUserName = "mohammad.yousuf@wolterskluwer.com.ctttest";//=> GetVaultsData(KeyVaultsVariables.sftestServiceManagerUserName, KeyVaultsVariables.sectionName);
        public static string sftestServiceManagerPassword = "Wk@Apr23";//=> GetVaultsData(KeyVaultsVariables.sftestServiceManagerPassword, KeyVaultsVariables.sectionName);
        public static string amazonUserID => GetVaultsData(KeyVaultsVariables.amazonUserID, KeyVaultsVariables.sectionName);
        public static string amazonPassword => GetVaultsData(KeyVaultsVariables.amazonPassword, KeyVaultsVariables.sectionName);
        public static string flipKartUserId => GetVaultsData(KeyVaultsVariables.flipKartUserId, KeyVaultsVariables.sectionName);
        public static string flipKartPassword => GetVaultsData(KeyVaultsVariables.flipKartPassword, KeyVaultsVariables.sectionName);

        private static string GetVaultsData(string secretName,string sectionName)
        {
            string data;
            applicationSettings = AppSettingsClientConfig.GetClient;
            applicationSettings.TryGetSecretAsync(secretName, sectionName, out data);
            return data;
        }

    }
}
