using System;
using System.Threading.Tasks;
using EAP.Xamarin.Core.ViewModels.Base;

namespace EAP.Xamarin.Core.Services.Navigation
{
    public interface INavigationService
    {
        Task NavigateToAsync<TType>() where TType : BaseViewModel;

        Task NavigateToAsync<TType>(object param) where TType : BaseViewModel;


        Task NavigateToAsync(Type type);

        Task NavigateToAsync(Type type, object param);

        Task NavigateToPreviousView();
    }
}
