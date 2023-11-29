using AppV2.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppV2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Properties["IsLoggedIn"] = false;
            Properties["codeUsr"] = "";

            MainPage = new PageLogin();
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
