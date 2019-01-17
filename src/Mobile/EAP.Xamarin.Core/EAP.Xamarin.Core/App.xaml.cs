using System;
using Autofac;
using EAP.Xamarin.Core.Services;
using EAP.Xamarin.Core.Utilities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EAP.Xamarin.Core
{
    public partial class App : Application
    {
        public App()
        {
            // for design time
        }

        public App(IDataService dataService)
        {
            if (dataService == null)
                throw new ArgumentNullException(nameof(dataService));

            try
            {

                InitializeComponent();
                AppContainer.Initialize((container) => container.RegisterInstance<IDataService>(dataService));
                MainPage = new MainPage();
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
