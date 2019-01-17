using System;
using System.Threading.Tasks;
using EAP.Xamarin.Core.Services;

namespace EAP.Xamarin.Service
{
    public class EAPService : IDataService
    {
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
