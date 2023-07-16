using mls7.Services;
using mls7.Views;
using mls7.Vistas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mls7
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
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
