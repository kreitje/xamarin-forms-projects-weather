using Autofac;
using TinyNavigationHelper.Forms;
using Weather.Services;
using Weather.ViewModels;
using Weather.Views;
using Xamarin.Forms;

namespace Weather
{
    public class Bootstrapper
    {
        public static void Init()
        {
            var navigation = new FormsNavigationHelper();
            if (Device.Idiom == TargetIdiom.Phone)
            {
                navigation.RegisterView("MainView", typeof(MainView_Phone));
            }
            else
            {
                navigation.RegisterView("MainView", typeof(MainViewModel));
            }
            
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<OpenWeatherMapWeatherService>().As<IWeatherService>();
            containerBuilder.RegisterType<MainViewModel>();

            var container = containerBuilder.Build();
            Resolver.Initialize(container);
        }
    }
}