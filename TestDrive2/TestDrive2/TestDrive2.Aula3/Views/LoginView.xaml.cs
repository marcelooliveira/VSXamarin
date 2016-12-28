using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.ViewModels;
using TestDrive.Views;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<LoginException>(this, "FalhaLogin",
                (msg) =>
                {
                    DisplayAlert("Login", "Erro ao validar usuário e senha!", "Ok");
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<LoginException>(this, "FalhaLogin");
        }
    }
}
