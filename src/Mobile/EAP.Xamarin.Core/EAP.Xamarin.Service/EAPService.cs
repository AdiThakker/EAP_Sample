using System;
using System.Threading.Tasks;
using EAP.Xamarin.Core.Services;

namespace EAP.Xamarin.Service
{
    public class EAPService : IDataService
    {
        private readonly string ConnectionUri;

        public EAPService(string uri)
        {
            if (string.IsNullOrEmpty(uri))
                throw new ArgumentNullException(nameof(uri));

            ConnectionUri = uri;
        }

        public Task<string> GetServiceFriendlyNameAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetServiceUrlAsync()
        {
            throw new NotImplementedException();
        }
    }
}
