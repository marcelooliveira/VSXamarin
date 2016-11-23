using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        public AgendamentoViewModel()
        {
            AgendamentoCommand = new Command(() =>
            {
                Messenger.Default.Send(new AgendamentoMessage(
                    this.Veiculo,
                    this.Nome,
                    this.Fone,
                    this.Email,
                    this.DataAgendamento,
                    this.HoraAgendamento));
            }, 
            () =>
                {
                    return
                    !string.IsNullOrEmpty(this.Nome)
                    && !string.IsNullOrEmpty(this.Fone)
                    && !string.IsNullOrEmpty(this.Email);
                });
        }

        public Veiculo Veiculo { get; set; }

        string nome;
        public string Nome {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
                OnPropertyChanged();
                ((Command)AgendamentoCommand).ChangeCanExecute();
            }
        }

        string fone;
        public string Fone
        {
            get
            {
                return fone;
            }
            set
            {
                fone = value;
                OnPropertyChanged();
                ((Command)AgendamentoCommand).ChangeCanExecute();
            }
        }

        string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged();
                ((Command)AgendamentoCommand).ChangeCanExecute();
            }
        }

        DateTime dataAgendamento;
        public DateTime DataAgendamento
        {
            get
            {
                return dataAgendamento;
            }
            set
            {
                dataAgendamento = value;
                OnPropertyChanged();
                ((Command)AgendamentoCommand).ChangeCanExecute();
            }
        }

        TimeSpan horaAgendamento;
        public TimeSpan HoraAgendamento
        {
            get
            {
                return horaAgendamento;
            }
            set
            {
                horaAgendamento = value;
                OnPropertyChanged();
                ((Command)AgendamentoCommand).ChangeCanExecute();
            }
        }

        public ICommand AgendamentoCommand { get; set; }
    }

    public class AgendamentoMessage
    {
        public AgendamentoMessage(
            Veiculo veiculo,
            string nome,
            string fone,
            string email,
            DateTime dataAgendamento,
            TimeSpan horaAgendamento)
        {
            this.Veiculo = veiculo;
            this.Nome = nome;
            this.Fone = fone;
            this.Email = email;
            this.DataAgendamento = dataAgendamento;
            this.HoraAgendamento = horaAgendamento;
        }

        public Veiculo Veiculo { get; set; }
        public string Nome { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }
        public DateTime DataAgendamento { get; set; }
        public TimeSpan HoraAgendamento { get; set; }
    }
}
