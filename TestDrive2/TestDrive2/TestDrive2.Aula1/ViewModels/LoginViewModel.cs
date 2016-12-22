using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TestDrive2.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        const string URL_GET_LOGIN = "https://aluracar.herokuapp.com/login";

        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                OnPropertyChanged(nameof(Usuario));
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        private string senha;

        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                OnPropertyChanged(nameof(Senha));
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        private bool aguarde;
        public bool Aguarde
        {
            get { return aguarde; }
            set
            {
                aguarde = value;
                OnPropertyChanged();
            }
        }

        public ICommand EntrarCommand { get; private set; }

        public LoginViewModel()
        {
            EntrarCommand = new Command(async () =>
            {
                await DoLogin(new Login(usuario, senha));
            }, 
            () =>
            {
                return !string.IsNullOrEmpty(usuario)
                        && !string.IsNullOrEmpty(senha);
            });
        }

        private async Task DoLogin(Login login)
        {
            Aguarde = true;
            HttpClient cliente = new HttpClient();

            try
            {
                var resultado = 
                    await cliente.GetStringAsync(
                        string.Format("{0}?email={1}&senha={2}", 
                            URL_GET_LOGIN, 
                            login.Usuario, 
                            login.Senha)
                        );
                MessagingCenter.Send<Login>(login, "SucessoLogin");
            }
            catch (Exception exc)
            {
                MessagingCenter.Send<Exception>(exc, "FalhaLogin");
            }
            Aguarde = false;
        }
    }
}
