using Sel_CSharp002.DnD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sel_CSharp002.TestData.AzureKeyVaults
{
    class AzureKeyValutsData
    {
        static AppSettingsClient applicationSettings;


        public static string sftestServiceManagerUserName => GetVaultsData(AzureKeyVaultsVariables.sftestServiceManagerUserName, AzureKeyVaultsVariables.sectionName);
        public static string sftestServiceManagerPassword => GetVaultsData(AzureKeyVaultsVariables.sftestServiceManagerPassword, AzureKeyVaultsVariables.sectionName);
        public static string amazonUserID => GetVaultsData(AzureKeyVaultsVariables.amazonUserID, AzureKeyVaultsVariables.sectionName);
        public static string amazonPassword => GetVaultsData(AzureKeyVaultsVariables.amazonPassword, AzureKeyVaultsVariables.sectionName);
        public static string flipKartUserId => GetVaultsData(AzureKeyVaultsVariables.flipKartUserId, AzureKeyVaultsVariables.sectionName);
        public static string flipKartPassword => GetVaultsData(AzureKeyVaultsVariables.flipKartPassword, AzureKeyVaultsVariables.sectionName);

        private static string GetVaultsData(string secretName,string sectionName)
        {
            string data;
            applicationSettings = AppSettingsClientConfig.GetClient;
            applicationSettings.TryGetSecretAsync(secretName, sectionName, out data);
            return data;
        }

    }
}
