using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows.Input;
using TestDrive.HttpClient;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class UsuarioViewModel : BaseViewModel
    {
        private const string URL_POST_AGENDAMENTO = @"https://aluracar.herokuapp.com/salvarpedido";

        public UsuarioViewModel(DetalheViewModel veiculo)
        {
            this.Titulo = veiculo.Modelo;
            IsRunning = false;

            FinalizarCommand = new Command(() =>
            {
                HttpClient<ResponseObject> client = new HttpClient<ResponseObject>();
                client.RequestCompleted +=
                (s, e) =>
                {
                    IsRunning = false;
                    Messenger.Default.Send(new FinalizarMessage());
                };

                client.RequestError += 
                (s, e) =>
                {
                    IsRunning = false;
                    Messenger.Default.Send(new ErroFinalizarMessage());
                };

                var requestObject = new RequestObject
                {
                    carro = veiculo.Modelo,
                    preco = veiculo.Preco,
                    email = email,
                    endereco = endereco,
                    nome = nome,
                    dataAgendamento = dataAgendamento
                };

                IsRunning = true;
                client.Request(RequestMethod.Post, URL_POST_AGENDAMENTO, requestObject);
            });
        }

        string titulo;
        public string Titulo
        {
            get { return titulo; }
            set
            {
                titulo = value;
                OnPropertyChanged();
            }
        }

        string nome;
        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DadosValidos));
            }
        }

        string endereco;
        public string Endereco
        {
            get { return endereco; }
            set
            {
                endereco = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DadosValidos));
            }
        }

        string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DadosValidos));
            }
        }

        DateTime dataAgendamento = DateTime.Today;
        public DateTime DataAgendamento
        {
            get { return dataAgendamento; }
            set
            {
                dataAgendamento = value;
                OnPropertyChanged();
            }
        }

        DateTime horaAgendamento;
        public DateTime HoraAgendamento
        {
            get { return horaAgendamento; }
            set
            {
                horaAgendamento = value;
                OnPropertyChanged();
            }
        }

        public ICommand FinalizarCommand { get; set; }

        public bool DadosValidos
        {
            get
            {
                return
                    !string.IsNullOrEmpty(nome)
                    && !string.IsNullOrEmpty(endereco)
                    && !string.IsNullOrEmpty(email);
            }
        }
    }

    public class FinalizarMessage { }

    public class ErroFinalizarMessage { }
}
