using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestDrive
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!(entEmail.Text == "aluno@alura.com.br" 
                && entPassword.Text == "alura123"))
            {
                DisplayAlert("Opa!", "Email ou senha incorreta", "Ok");
            }
            else
            {
                Navigation.PushAsync(new ListagemModelos());
            }
        }
    }
}
