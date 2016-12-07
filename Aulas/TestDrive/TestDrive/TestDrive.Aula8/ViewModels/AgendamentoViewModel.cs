using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
        public AgendamentoViewModel(Veiculo veiculo)
        {
            this.Agendamento = new Agendamento();
            this.Agendamento.Veiculo = veiculo;

            AgendamentoCommand = new Command(() =>
            {
                MessagingCenter.Send<Agendamento>(this.Agendamento, "Agendamento");
            }, 
            () =>
                {
                    return true;
                    //!string.IsNullOrEmpty(this.Nome)
                    //&& !string.IsNullOrEmpty(this.Fone)
                    //&& !string.IsNullOrEmpty(this.Email);
                });
        }

        public Agendamento Agendamento { get; set; }

        public Veiculo Veiculo
        {
            get
            {
                return Agendamento.Veiculo;
            }
            set
            {
                Agendamento.Veiculo = value;
            }
        }

        public string Nome {
            get
            {
                return Agendamento.Nome;
            }
            set
            {
                Agendamento.Nome = value;
                OnPropertyChanged();
                ((Command)AgendamentoCommand).ChangeCanExecute();
            }
        }

        public string Fone
        {
            get
            {
                return Agendamento.Fone;
            }
            set
            {
                Agendamento.Fone = value;
                OnPropertyChanged();
                ((Command)AgendamentoCommand).ChangeCanExecute();
            }
        }

        public string Email
        {
            get
            {
                return Agendamento.Email;
            }
            set
            {
                Agendamento.Email = value;
                OnPropertyChanged();
                ((Command)AgendamentoCommand).ChangeCanExecute();
            }
        }

        public DateTime DataAgendamento
        {
            get
            {
                return Agendamento.DataAgendamento;
            }
            set
            {
                Agendamento.DataAgendamento = value;
                OnPropertyChanged();
                ((Command)AgendamentoCommand).ChangeCanExecute();
            }
        }

        public TimeSpan HoraAgendamento
        {
            get
            {
                return Agendamento.HoraAgendamento;
            }
            set
            {
                Agendamento.HoraAgendamento = value;
                OnPropertyChanged();
                ((Command)AgendamentoCommand).ChangeCanExecute();
            }
        }

        public DateTime DataHoraAgendamento
        {
            get
            {
                return new DateTime(DataAgendamento.Year, DataAgendamento.Month, DataAgendamento.Day,
                    HoraAgendamento.Hours, HoraAgendamento.Minutes, HoraAgendamento.Seconds);
            }
        }

        public ICommand AgendamentoCommand { get; set; }

        public async void SalvarAgendamento()
        {
            Aguarde = true;
            HttpClient client = new HttpClient();

            var dataHoraAgendamento
                = new DateTime(DataAgendamento.Year, DataAgendamento.Month, DataAgendamento.Day,
                DataAgendamento.Hour, DataAgendamento.Minute, DataAgendamento.Second);

            var SALVAR_AGENDAMENTO_URL = "https://aluracar.herokuapp.com/salvaragendamento";

            var json = JsonConvert.SerializeObject(new
            {
                nome = Nome,
                endereco = "xxxx",
                fone = Fone,
                email = Email,
                carro = Veiculo.Nome,
                preco = Veiculo.Preco,
                dataAgendamento = dataHoraAgendamento
            });

            try
            {
                var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

                var resposta = await client.PostAsync(SALVAR_AGENDAMENTO_URL, conteudo);
                if (resposta.IsSuccessStatusCode)
                {
                    MessagingCenter.Send<Agendamento>(this.Agendamento, "SucessoAgendamento");
                }
                else
                {
                    MessagingCenter.Send<Exception>(new ArgumentException(), "FalhaAgendamento");
                }
                Aguarde = false;
            }
            catch (Exception exc)
            {
                Aguarde = false;
                MessagingCenter.Send<Exception>(exc, "FalhaAgendamento");
            }
        }
    }
}
