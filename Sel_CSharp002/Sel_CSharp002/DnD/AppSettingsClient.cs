using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sel_CSharp002.DnD;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Globalization;
using Microsoft.AspNetCore.WebUtilities;
//using UrlCombineLib;

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
    public class AppSettingsClient : IAppSettingsClient, ITryAppSettingsClient, ITypeAppSettingsClient
    {
        private readonly IAppSettingsRestClient _restClient;
        private DefaultContext defaultContext;

        private IParameterValidator Validator { get; set; } = new ParameterValidator();

        public AppSettingsClient() : this(new DefaultContext())
        {

        }
        public AppSettingsClient(IConfiguration config) : this(new DefaultContext(config))
        {

        }
        public AppSettingsClient(IClientContext context)
        {
            _restClient = new AppSettingsRestClient(context);

        }
        public AppSettingsClient(IAppSettingsRestClient restClient)
        {
            _restClient = restClient;
        }

        public AppSettingsClient(DefaultContext defaultContext)
        {
            this.defaultContext = defaultContext;
        }

        public Task<string> GetAsync(string section, string key)
        {
            return _restClient.GetAsync(section, key);
        }

        public Task<string> GetSecretAsync(string secretName, string section = null)
        {
            Validator.VerifyIfNullOrEmpty(secretName, "secretName");
            return _restClient.GetSecretAsync(secretName, section);
        }

        public Task<T> GetSectionAsync<T>(string section)
        {
            Validator.VerifyIfNullOrEmpty(section, "section");
            return _restClient.GetSectionAsync<T>(section);
        }

        public bool TryGetAsync(string sectionName, string key, out string keyValue)
        {
            keyValue = string.Empty;
            try
            {
                keyValue = GetAsync(sectionName, key).Result;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool TryGetSecretAsync(string secretName, string section, out string secret)
        {
            secret = string.Empty;
            try
            {
                secret = GetAsync(secretName, section).Result;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool TryGetSectionAsync<T>(string sectionName, out T section)
        {
            section = default(T);
            try
            {
                section = GetSectionAsync<T>(sectionName).Result;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public Task<T> GetAsync<T>(string section, string key)
        {
            T result = default(T);
            if (TryGetAsync(section, key, out var keyvalue))
            {
                result = TryParse<T>(keyvalue);
            } return Task.FromResult(result);
        }
        private static T TryParse<T>(string inValue)
            {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)converter.ConvertFromString(null, CultureInfo.InvariantCulture, inValue);
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
        bool TryGetAsync(string sectionName, string key, out string keyValue);
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
    public class DefaultContext : IClientContext
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
public class AppSettingsRestClient : IAppSettingsRestClient
{
    private readonly IClientContext clientcontext;
    public HttpClient HttpClient { get; }
    public AppSettingsRestClient(IClientContext clientcontext):this(clientcontext,new HttpClient()) { }
    public AppSettingsRestClient(IClientContext clientcontext,HttpClient client)
    {
        this.clientcontext = clientcontext;
        HttpClient = client;
        SetSecurityHeader();
    }
    public void HandleEx(AppSettingsClientException ex)
    {
        if(ex!=null && ex.InnerException?.Message.Contains("No such host is known")==true)
        {
            throw new AppSettingsClientException("ConfigService url does not exist or misconfigured:" + clientcontext.AppSettingsServiceUrl);
        }
        if (ex != null && ex.InnerException?.Message.Contains("401") == true)
        {
            throw new AppSettingsClientException("401 " + ex.Message);
        }
        if (ex != null && ex.InnerException?.Message.Contains("400") == true)
        {
            throw new AppSettingsClientException("400 " + ex.Message);
        }
        throw new AppSettingsClientException("500 " + ex.Message, ex);
    }
    public Task<string> GetAsync(string section, string key)
    {
        Task<string> task = null;
        return Task<string>.Factory.StartNew(delegate
        {
            string empty = string.Empty;
            string requestUrl = clientcontext.AppSettingsServiceUrl + "/secrets?applicationName=" + clientcontext.AppName + "&sectionName=" + section+"&keyName="+key;
            return ReadResponse(requestUrl);
        });
    }

    public Task<string> GetSecretAsync(string secretName, string section = null)
    {
        return Task<string>.Factory.StartNew(delegate
        {
            string empty = string.Empty;
            string requestUrl = clientcontext.AppSettingsServiceUrl + "/secrets?applicationName=" + clientcontext.AppName + "&secretName=" + secretName + "&sectionName=" + section;
            return ReadResponse(requestUrl);
        });
    }

    public Task<T> GetSectionAsync<T>(string section)
    {
        return Task<T>.Factory.StartNew(delegate
        {
            object obj = null;
            string requestUrl = clientcontext.AppSettingsServiceUrl + "/secrets?applicationName=" + clientcontext.AppName +  "&sectionName=" + section;
            string value= ReadResponse(requestUrl);
            obj = JsonConvert.DeserializeObject<T>(value);
            return (dynamic)obj;
        });
    }
    private string ReadResponse(string requestUrl)
    {
        string text = string.Empty;
        JObject jObject = null;
        try
        {
            HttpResponseMessage result = HttpClient.GetAsync(requestUrl).Result;
            text = result.Content.ReadAsStringAsync().Result;
            result.EnsureSuccessStatusCode();
            jObject = JsonConvert.DeserializeObject<JObject>(text);

        }
        catch (HttpRequestException innerException)
        {
            HandleEx(new AppSettingsClientException(text, innerException));
            throw;
        }
        return jObject["result"].ToString();
    }
    private void SetSecurityHeader()
    {
        if (!string.IsNullOrEmpty(clientcontext.AppSettingsServiceSubscriptionkey))
        {
            HttpClient.DefaultRequestHeaders.Add("Ocp-Apim-subscription-Key", clientcontext.AppSettingsServiceSubscriptionkey);
            HttpClient.DefaultRequestHeaders.Add("CT-API-Key", clientcontext.AppSettingsServiceSubscriptionkey);
        }
    }
}
public interface IAppSettingsRestClient
{
    Task<String> GetAsync(string section, string key);
    Task<T> GetSectionAsync<T>(string section);
    Task<String> GetSecretAsync(string secretName, string section = null);
}
[Serializable]
public class AppSettingsClientException: CTException
{
    public AppSettingsClientException()
    {

    }
    public AppSettingsClientException(string message): base(message)
    {

    }
    public AppSettingsClientException(string message,Exception innerException) : base(message,innerException)
    {

    }
    protected AppSettingsClientException(SerializationInfo serializationInfo,StreamingContext streamingContext)
    {

    }
}
[Serializable]
public class CTException : Exception
{
    public CTException()
    {

    }
    public CTException(string message)
    {

    }
    public CTException(string message,Exception innerException)
    {

    }
    public CTException(SerializationInfo serializationInfo, StreamingContext streamingContext):base(serializationInfo,streamingContext)
    {

    }


}
public class BlobRepository
{
    private AppSettingsClient appSettingsClient;
    private HttpClient httpClient;
    private string baseURL;
    private string appName;
    public BlobRepository(string _appName,AppSettingsClient _appsc)
    {
        appName = _appName;
        appSettingsClient = _appsc;
        baseURL = appSettingsClient.GetAsync("apiUrls","TestDataServiceUrl").Result;
        httpClient = new HttpClient();
    }
    public T GetData<T>(string fileName="",string testDataSection = "")
    {
        string requestUrl=BuildRequestURL(fileName, testDataSection);
        return ReadResponse<T>(requestUrl);
    }

    private T ReadResponse<T>(string requestUrl)
    {
        T val = default(T);
        try
        {
            HttpResponseMessage result = httpClient.GetAsync(requestUrl).Result;
            string result2 = result.Content.ReadAsStringAsync().Result;
            result.EnsureSuccessStatusCode();
            string value = JsonConvert.DeserializeObject<JObject>(result2)["result"].ToString();
            return JsonConvert.DeserializeObject<T>(value);
        }
        catch (Exception)
        {

            throw new Exception("Error getting test data");
        }
    }

    private string BuildRequestURL(string fileName, string testDataSection)
    {
        Dictionary<string, string> queryString = new Dictionary<string, string> 
        {
            ["appName"] = appName,
            ["fileName"] = fileName,
            ["testDataSection"] = testDataSection
        };
        return QueryHelpers.AddQueryString(UrlCombine.Combine(baseURL, "/TestData"), queryString);
    }
}
public static class UrlCombine
{
    public static string Combine(string baseUrl,string relativeUrl)
    {
        if (string.IsNullOrEmpty(baseUrl))
        {
            throw new ArgumentNullException("baseUrl");
        }
        if (string.IsNullOrEmpty(relativeUrl))
        {
            return baseUrl;
        }
        baseUrl = baseUrl.TrimEnd(new char[1] { '/' });
        relativeUrl = relativeUrl.TrimStart(new char[1] { '/' });
        return $"{baseUrl}/{relativeUrl}";
    }
    public static string Combine(string baseUrl,params string[] relativePaths)
    {
        if (string.IsNullOrEmpty(baseUrl))
        {
            throw new ArgumentNullException("baseUrl");
        }
        if (relativePaths.Length==0)
        {
            return baseUrl;
        }
        string baseUrl2 = Combine(baseUrl, relativePaths[0]);
        return Combine(baseUrl2, relativePaths.Skip(1).ToArray());
    }
}