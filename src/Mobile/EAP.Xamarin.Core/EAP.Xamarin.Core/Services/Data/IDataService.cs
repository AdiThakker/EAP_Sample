using System.Threading.Tasks;

namespace EAP.Xamarin.Core.Services
{
    public interface IDataService
    {
        Task<string> GetServiceFriendlyNameAsync();

        Task<string> GetServiceUrlAsync();
    }
}
