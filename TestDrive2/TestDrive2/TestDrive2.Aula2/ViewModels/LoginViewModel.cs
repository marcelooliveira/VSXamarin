using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestDrive2;
using Xamarin.Forms;

namespace TestDrive.ViewModels
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
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://aluracar.herokuapp.com");
                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("email", "joao@alura.com.br"),
                        new KeyValuePair<string, string>("senha", "alura123")
                    });
                    var result = await client.PostAsync("/login", content);
                    string resultContent = result.Content.ReadAsStringAsync().Result;
                    LoginResult loginResult = JsonConvert.DeserializeObject<LoginResult>(resultContent);
                    MessagingCenter.Send<Usuario>(loginResult.usuario, "SucessoLogin");
                }
            }
            catch (Exception exc)
            {
                MessagingCenter.Send<Exception>(exc, "FalhaLogin");
            }
            Aguarde = false;
        }
    }
}
