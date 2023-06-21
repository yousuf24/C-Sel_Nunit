using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sel_CSharp002.DnD
{
    public interface IParameterValidator
    {
        bool VerifyIfNullOrEmpty(string inputparameter, string message);
    }
    public class ParameterValidator : IParameterValidator
    {
        public bool VerifyIfNullOrEmpty(string inputparameter, string message)
        {
            if(string.IsNullOrEmpty(inputparameter))
                throw new NotImplementedException();
            return true;
        }
    }
    class AppSettingsClient : IAppSettingsClient, ITryAppSettingsClient, ITypeAppSettingsClient
    {
        private readonly IAppSettingsClient _restClient;
        private DefaultContext defaultContext;

        private IParameterValidator Validator { get; set; } = new ParameterValidator();

        public AppSettingsClient(): this(new DefaultContext())
        {

        }
        public AppSettingsClient(IClientContext context)
        {
            //_restClient = new AppSettingRestClient(context);
            //TODO:
        }

        public AppSettingsClient(DefaultContext defaultContext)
        {
            this.defaultContext = defaultContext;
        }

        public Task<string> GetAsync(string section, string key)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSecretAsync(string secretName, string section = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetSectionAsync<T>(string section)
        {
            throw new NotImplementedException();
        }

        public bool TryGetAsync(string sectionName, string key, string keyValue)
        {
            throw new NotImplementedException();
        }

        public bool TryGetSecretAsync(string sectionName, string section, out string secret)
        {
            throw new NotImplementedException();
        }

        public bool TryGetSectionAsync<T>(string sectionName, out T keyValue)
        {
            throw new NotImplementedException();
        }
    }
    public interface IAppSettingsClient: ITryAppSettingsClient, ITypeAppSettingsClient
    {
        Task<String> GetAsync(string section, string key);
        Task<String> GetSecretAsync(string secretName, string section=null);
        Task<T> GetSectionAsync<T>(string section);
    }
    public interface ITryAppSettingsClient
    {
        bool TryGetAsync(string sectionName, string key, string keyValue);
        bool TryGetSecretAsync(string sectionName, string section,out string secret);
        bool TryGetSectionAsync<T>(string sectionName, out T keyValue);
    }
    public interface ITypeAppSettingsClient
    {

    }
    public interface IClientContext
    {
        string EnvironmentalPrefix { get; set; }
        string AppSettingsServiceUrl { get; set; }
        string AppName { get; set; }
        string AppSettingsServiceSubscriptionkey { get; set; }
    }
    internal class DefaultContext : IClientContext
    {
public string EnvironmentalPrefix { get ; set ; }
        public string AppSettingsServiceUrl { get; set; }
        public string AppName { get; set; }
        public string AppSettingsServiceSubscriptionkey { get; set; }

        public DefaultContext()

        {
            string text = "appsettings.json";
            if(!File.Exists(text))
            {
                throw new FileNotFoundException(text);
            }
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            Initialize(config);
        }
        public DefaultContext(IConfiguration config)
        {
            Initialize(config);
        }
        private void Initialize(IConfiguration config)
        {
            string text = config["appSettings:appName"];
            string text2 = config["appSettings:serviceUrl"];
            string text3 = config["appSettings:serviceSubscriptionkey"];
            string environmentalPrefix = config["appSettings:env"];
            AppName = text;
            AppSettingsServiceUrl = text2;
            AppSettingsServiceSubscriptionkey = text3;
            EnvironmentalPrefix = environmentalPrefix;
        }
    }



}
#if false
---------
LOG
----------
#endif
