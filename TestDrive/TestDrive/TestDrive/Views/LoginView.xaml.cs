using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!(entEmail.Text == "aluno@alura.com.br"
                && entPassword.Text == "alura123"))
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    DisplayAlert("Opa!", "Email ou senha incorreta", "Ok");
                });
            }
            else
            {
                Navigation.PushAsync(new ListagemView());
            }
        }
    }
}
