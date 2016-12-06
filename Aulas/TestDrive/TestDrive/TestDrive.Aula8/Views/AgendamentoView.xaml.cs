using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoViewModel ViewModel { get; set; }
        public AgendamentoView(Veiculo veiculo)
        {
            this.ViewModel = new AgendamentoViewModel(veiculo);

            InitializeComponent();
            this.BindingContext = this.ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento", async (msg) =>
            {
                var resposta = await DisplayAlert("Salvar Agendamento",
                    "Deseja mesmo salvar o agendamento?", "Sim", "Não");
                if (resposta)
                    this.ViewModel.SalvarAgendamento();
            });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento", (msg) =>
            {
                DisplayAlert("Agendamento", "Agendamento salvo com sucesso!", "Ok");
            });

            MessagingCenter.Subscribe<Exception>(this, "FalhaAgendamento", (msg) =>
            {
                DisplayAlert("Agendamento", "Falha ao tentar agendar test drive! Verifique os dados e tente novamente mais tarde!", "Ok");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "FalhaAgendamento");
        }
    }
}