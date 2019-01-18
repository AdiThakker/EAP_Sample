using System.IO;
using Android.App;
using Newtonsoft.Json;

namespace EAP.Xamarin.Core.Droid
{
    /// <summary>
    /// AppConfigurationService Class for App.Config
    /// </summary>
    public class AppConfiguration
    {
        private Configuration configuration;

        private string ServiceUriDefault = "";

        public AppConfiguration()
        {
            Initialize();
        }

        public string GetConnectionUri()
        {
            return (!string.IsNullOrEmpty(configuration.ServiceUri)) ? ServiceUriDefault : configuration.ServiceUri;
        }

        private void Initialize()
        {
            using (var asset = Application.Context.Assets.Open("Config.json"))
            {
                using (var streamReader = new StreamReader(asset))
                {
                    var file = streamReader.ReadToEndAsync().Result;
                    configuration = JsonConvert.DeserializeObject<Configuration>(file);
                }
            }
        }

        private class Configuration
        {
            public string ServiceUri { get; set; }
        }
    }
}