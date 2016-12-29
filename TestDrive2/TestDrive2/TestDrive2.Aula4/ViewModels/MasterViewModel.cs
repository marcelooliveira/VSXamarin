using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class MasterViewModel : BaseViewModel
    {
        public ICommand EditarPerfilCommand { get; private set; }
        public ICommand EditarCommand { get; private set; }
        public ICommand SalvarCommand { get; private set; }

        private Usuario usuario;
        public Usuario Usuario
        {
            get
            {
                return usuario;
            }
            private set
            {
                usuario = value;
                OnPropertyChanged(nameof(Nome));
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(Telefone));
                OnPropertyChanged(nameof(DataNascimento));
            }
        }

        private int tabIndex;

        public int TabIndex
        {
            get { return tabIndex; }
            set { tabIndex = value; }
        }


        public string Nome
        {
            get
            {
                return Usuario.nome;
            }
            set
            {
                Usuario.nome = value;
            }
        }

        public string Email
        {
            get { return Usuario.email; }
            set
            {
                Usuario.email = value;
            }
        }

        public string DataNascimento
        {
            get { return Usuario.dataNascimento; }
            set
            {
                Usuario.dataNascimento = value;
            }
        }

        public string Telefone
        {
            get { return Usuario.telefone; }
            set
            {
                Usuario.telefone = value;
            }
        }

        private bool exibirCard = true;
        public bool ExibirCard
        {
            get { return exibirCard; }
            private set
            {
                exibirCard = value;
                OnPropertyChanged(nameof(ExibirCard));
            }
        }

        private bool editando;
        public bool Editando
        {
            get { return editando; }
            private set
            {
                editando = value;
                OnPropertyChanged(nameof(Editando));
            }
        }

        public MasterViewModel(Usuario usuario)
        {
            this.Usuario = usuario;

            EditarPerfilCommand = new Command(() =>
            {
                ExibirCard = false;
                MessagingCenter.Send<Usuario>(usuario, "EditarPerfil");
            });

            EditarCommand = new Command(() =>
            {
                Editando = true;
            });

            SalvarCommand = new Command(() =>
            {
                Editando = false;
                ExibirCard = true;
                MessagingCenter.Send<Usuario>(usuario, "SucessoSalvarUsuario");
            });
        }
    }
}
