using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDrive.Views;
using Xamarin.Forms;

namespace TestDrive
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MasterDetailView();
            MainPage = new LoginView();
            //MainPage = new MasterDetailPageNavigation.MainPage();
        }

        protected override void OnStart()
        {
            MessagingCenter.Subscribe<Usuario>(this, "SucessoLogin",
                (usuario) =>
                {
                    //MainPage = new NavigationPage(new MasterDetailPageDemoPage(usuario));
                    MainPage = new MasterDetailPageDemoPage(usuario);
                });
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
