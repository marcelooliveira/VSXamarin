using GalaSoft.MvvmLight.Messaging;
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
                    return
                    !string.IsNullOrEmpty(this.Nome)
                    && !string.IsNullOrEmpty(this.Fone)
                    && !string.IsNullOrEmpty(this.Email);
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

        public ICommand AgendamentoCommand { get; set; }

        public async void SalvarAgendamento()
        {
            HttpClient client = new HttpClient();

            var dataHoraAgendamento
                = new DateTime(DataAgendamento.Year, DataAgendamento.Month, DataAgendamento.Day,
                DataAgendamento.Hour, DataAgendamento.Minute, DataAgendamento.Second);

            var SALVAR_AGENDAMENTO_URL = "";
//                string.Format(
//"https://aluracar.herokuapp.com/salvarpedido?carro={0}&email={1}&endereco={2}&nome={3}&preco={4}&dataAgendamento={5}"
//, Veiculo.nome, email, fone, nome, Veiculo.preco, dataHoraAgendamento.ToString("yyyy/MM/dd"));

            try
            {
                var httpResponseMessage = await client.GetAsync(SALVAR_AGENDAMENTO_URL);
                if (httpResponseMessage.IsSuccessStatusCode)
                    MessagingCenter.Send<Agendamento>(this.Agendamento, "SucessoAgendamento");
                else
                    MessagingCenter.Send<HttpContent>(httpResponseMessage.Content, "FalhaAgendamentoHttpContent");
            }
            catch (Exception exc)
            {
                MessagingCenter.Send<Exception>(exc, "FalhaAgendamento");
            }
        }
    }
}
