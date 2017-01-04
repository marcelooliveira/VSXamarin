using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand EntrarCommand { get; private set; }

        public LoginViewModel()
        {
            EntrarCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(new Usuario(), "SucessoLogin");
            },
            () =>
            {
                return !string.IsNullOrEmpty(usuario)
                && !string.IsNullOrEmpty(senha);
            });
        }

        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
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
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }
    }
}
