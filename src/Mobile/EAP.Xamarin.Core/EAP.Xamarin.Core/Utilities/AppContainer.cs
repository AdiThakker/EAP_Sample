using System;
using Autofac;

namespace EAP.Xamarin.Core.Utilities
{
    public static class AppContainer
    {
        private static IContainer appContainer;

        public static void Initialize(Action<ContainerBuilder> registration)
        {
            var builder = new ContainerBuilder();

            registration(builder);

            appContainer = builder.Build();
        }

        public static TType Resolve<TType>() => appContainer.Resolve<TType>();
    }
}
