using System;
using TinyNavigationHelper.Abstraction;
using Weather.ViewModels;
using Weather.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Bootstrapper.Init();
            
            NavigationHelper.Current.SetRootView("MainView", true);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
