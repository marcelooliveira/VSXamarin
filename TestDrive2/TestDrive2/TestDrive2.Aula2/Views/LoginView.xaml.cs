using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Views;
using Xamarin.Forms;

namespace TestDrive2.Views
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

            MessagingCenter.Subscribe<Login>(this, "SucessoLogin", 
                (msg) =>
                {
                    Navigation.PushAsync(new ListagemView());
                });

            MessagingCenter.Subscribe<Exception>(this, "FalhaLogin",
                (msg) =>
                {
                    DisplayAlert("Login", "Erro ao validar usuário e senha!", "Ok");
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Login>(this, "SucessoLogin");
            MessagingCenter.Unsubscribe<Login>(this, "FalhaLogin");
        }
    }
}
