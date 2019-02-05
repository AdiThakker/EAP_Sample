using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EAP.Xamarin.Core.ViewModels.Base;
using Xamarin.Forms;

namespace EAP.Xamarin.Core.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<Type, Type> ViewLookup = new Dictionary<Type, Type>();

        public NavigationService()
        {
            var types = this.GetType().Assembly.GetTypes();
            var models = types.Where(type => type.FullName.EndsWith("Model") && type.IsSubclassOf(typeof(BaseViewModel))).ToList();
            models.ForEach(model =>
            {
                var viewName = model.Name.TrimEnd(new char[] { 'M', 'o', 'd', 'e', 'l' });
                var viewType = types.FirstOrDefault(type => type.Name.Equals(viewName, StringComparison.InvariantCultureIgnoreCase));
                if (viewType != null)
                    ViewLookup.Add(model, viewType);
            });
        }

        public async Task NavigateToAsync<TType>() where TType : BaseViewModel
        {
            await NavigateAsync(typeof(TType), null);
        }

        public async Task NavigateToAsync<TType>(object param) where TType : BaseViewModel
        {
            await NavigateAsync(typeof(TType), param);
        }

        public async Task NavigateToAsync(Type type)
        {
            await NavigateAsync(type, null);
        }

        public async Task NavigateToAsync(Type type, object param)
        {
            await NavigateAsync(type, param);
        }

        public async Task NavigateToPreviousView()
        {
            await Navigation().PopAsync(true);
        }

        private NavigationPage Navigation() => ((MasterDetailPage)Application.Current.MainPage).Detail as NavigationPage;

        private async Task NavigateAsync(Type type, object param)
        {
            try
            {
                // navigate to view associated with the ViewModel
                if (!ViewLookup.TryGetValue(type, out Type viewType))
                    throw new InvalidOperationException($"No matching view found for: {type.Name}");

                // Avoid multiple instances
                if (Navigation().CurrentPage.GetType().Name.Equals(viewType.Name))
                    return;

                var page = Activator.CreateInstance(viewType) as Page;
                var pageModel = page.BindingContext as BaseViewModel;
                await Navigation().PushAsync(page);

                // Initialize State
                if (param != null)
                    await pageModel.InitializeAsync(param);
            }
            catch (Exception)
            {
                throw;
            }
        }

        Task INavigationService.NavigateToAsync<TType>()
        {
            throw new NotImplementedException();
        }

        Task INavigationService.NavigateToAsync<TType>(object param)
        {
            throw new NotImplementedException();
        }

        Task INavigationService.NavigateToAsync(Type type)
        {
            throw new NotImplementedException();
        }

        Task INavigationService.NavigateToAsync(Type type, object param)
        {
            throw new NotImplementedException();
        }

        Task INavigationService.NavigateToPreviousView()
        {
            throw new NotImplementedException();
        }
    }
}
